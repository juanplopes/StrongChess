using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrongChess.Model
{
    using StrongChess.Model.Sets;
    using StrongChess.Model.Pieces;
    using StrongChess.Model.Exceptions;
    using System.Diagnostics;

    public struct Board
    {
        public Side White { get; private set; }
        public Side Black { get; private set; }
        public int NoPawnMovesCount { get; private set; }
        public bool IsWhiteTurn { get; private set; }
        public Square? Enpassant { get; private set; }

        public Bitboard Occupation
        {
            get
            {
                return White.Occupation | Black.Occupation;
            }
        }

        public Board(Side white, Side black, 
            int noPawnMovesCount = 0, 
            bool isWhiteToMove = true,
            Square? enpassant = null)
            : this()
        {
            this.White = white;
            this.Black = black;
            this.NoPawnMovesCount = noPawnMovesCount;
            this.IsWhiteTurn = isWhiteToMove;
            this.Enpassant = enpassant;
        }
        
        public static Board NewGame()
        {
            var result = new Board();

            result.White = Side.WhiteInitialPosition;
            result.Black = Side.BlackInitialPosition;

            result.IsWhiteTurn = true;
            result.NoPawnMovesCount = 0;
            
            return result;
        }

        public Board MakeMove(Move move)
        {
            Square? enpassant = null;

            var moving = (this.IsWhiteTurn ? White : Black);
            var notmoving = (this.IsWhiteTurn ? Black : White);

            switch (moving.GetPieceAt(move.From))
            {
                case ChessPieces.Pawn:
                    MakePawnMove(move, ref enpassant, ref moving, ref notmoving);
                    break;
                case ChessPieces.King:
                case ChessPieces.Queen:
                case ChessPieces.Bishop:
                case ChessPieces.Knight:
                case ChessPieces.Rook:
                case ChessPieces.None:
                default:
                    throw new NotImplementedException(
                        string.Format("There is no support to {0} moves", 
                        moving.GetPieceAt(move.From))
                    );
            }

            notmoving = notmoving.RemovePieces(
                GetCapturedSquare(move)
                );

            var white = (this.IsWhiteTurn ? moving : notmoving);
            var black = (this.IsWhiteTurn ? notmoving : moving);
            
            return new Board(white, black, 0, !IsWhiteTurn, enpassant);
        }

        private void MakePawnMove(Move move, 
            ref Square? enpassant, 
            ref Side moving, 
            ref Side notmoving)
        {
            bool isPromotion =
                (move.To.Rank.Index == 7 || move.To.Rank.Index == 0);

            if (move.Type == MoveTypes.Normal && isPromotion)
                throw new InvalidMoveException(move, this);

            var isvalid = moving.Pawns
                .GetAllMoves(~Occupation, notmoving.Occupation,
                this.Enpassant)
                .Count(m => m.From == move.From && m.To == move.To)
                > 0;

            if (!isvalid)
                throw new InvalidMoveException(move, this);

            var locations = moving.Pawns.Locations
                & (~move.From.AsBoard);

            if (!isPromotion)
                locations |= move.To.AsBoard;

            IPawns pawns = IsWhiteTurn ?
                (IPawns)new WhitePawns(locations) :
                (IPawns)new BlackPawns(locations);

            if (move.From.File == move.To.File &&
                Math.Abs(move.From.Rank - move.To.Rank) > 1)
                enpassant = new Square(
                    (move.From.Rank + move.To.Rank) / 2,
                    move.From.File
                    );

            var queens = moving.Queens;
            if (move.Type == MoveTypes.PawnToQueenPromotion)
                queens = new PieceSet<Queen>(
                    moving.Queens.Locations |
                    move.To.AsBoard
                    );

            var bishops = moving.Bishops;
            if (move.Type == MoveTypes.PawnToBishopPromotion)
                bishops = new PieceSet<Bishop>(
                    moving.Bishops.Locations |
                    move.To.AsBoard
                    );

            var knights = moving.Knights;
            if (move.Type == MoveTypes.PawnToKnightPromotion)
                knights = new PieceSet<Knight>(
                    moving.Knights.Locations |
                    move.To.AsBoard
                    );

            var rooks = moving.Rooks;
            if (move.Type == MoveTypes.PawnToRookPromotion)
                rooks = new PieceSet<Rook>(
                    moving.Rooks.Locations |
                    move.To.AsBoard
                    );

            moving = new Side(
                moving.KingLocation,
                queens,
                bishops,
                knights,
                rooks,
                pawns
                );

            
            
        }

        private Square GetCapturedSquare(Move move)
        {
            if (move.To != Enpassant)
                return move.To;
            
            if (move.To.Rank == 6)
                return new Square(5, move.To.File);
            
            return new Square(4, move.To.File);
        }
        
    }
}
