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

        public Board MakeMove(Square from, Square to, 
            MoveTypes type = MoveTypes.Normal)
        {
            return this.MakeMove(
                new Move(from, to, type)
                );
        }

        public Board MakeMove(Move move)
        {
            Square? enpassant = null;

            var moving = (this.IsWhiteTurn ? White : Black);
            var notmoving = (this.IsWhiteTurn ? Black : White);

            switch (moving.GetPieceAt(move.From))
            {
                case ChessPieces.Pawn:
                    MakePawnMove(move, ref moving, notmoving);
                    enpassant = ComputeEnpassantSquare(move);
                    break;
                case ChessPieces.Knight:
                    var isValid = moving.Knights.GetMoves(
                        moving.Occupation,
                        notmoving.Occupation
                        )
                        .Count(m => m == move) > 0;


                    if (!isValid)
                        throw new InvalidMoveException(move, this);

                    moving = moving
                        .RemovePieces(move.From)
                        .AddPieces(ChessPieces.Knight, move.To.AsBoard);
                    break;
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
            
            return new Board(white, black, 0, !IsWhiteTurn, 
                enpassant);
        }

        private void MakePawnMove(Move move, 
            ref Side moving, 
            Side notmoving)
        {
            EnsureValidPawnMove(move, moving, notmoving);

            var locations = moving.Pawns.Locations
                & (~move.From.AsBoard);

            if (move.Type == MoveTypes.Normal)
                locations |= move.To.AsBoard;
            else
                moving = moving.AddPieces(move.Type, move.To.AsBoard);

            IPawns pawns = IsWhiteTurn ?
                (IPawns)new WhitePawns(locations) :
                (IPawns)new BlackPawns(locations);

            moving = new Side(
                moving.KingLocation,
                moving.Queens,
                moving.Bishops,
                moving.Knights,
                moving.Rooks,
                pawns
                );
        }

        private void EnsureValidPawnMove(Move move, Side moving, Side notmoving)
        {
            var isvalid = moving.Pawns
                .GetAllMoves(~Occupation, notmoving.Occupation,
                this.Enpassant)
                .Count( m => m == move ) > 0;

            if (!isvalid)
                throw new InvalidMoveException(move, this);
        }

        private static Square? ComputeEnpassantSquare(Move move)
        {
            
            bool isPawnFirstTwoSquaresMove =
                (move.From.File == move.To.File &&
                Math.Abs(move.From.Rank - move.To.Rank) > 1);

            if (!isPawnFirstTwoSquaresMove) return null;
                
            return new Square(
                (move.From.Rank + move.To.Rank) / 2,
                move.From.File
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
