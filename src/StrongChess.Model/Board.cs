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
        public IEnumerable<Move> AvaliableMoves { get; private set; }

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
            ComputeAvaliableMoves();
        }

        private void ComputeAvaliableMoves()
        {
            var moving = (this.IsWhiteTurn ? White : Black);
            var notmoving = (this.IsWhiteTurn ? Black : White);

            this.AvaliableMoves = moving.GetMoves(notmoving.Occupation.AsBoard,
                (Square?)Enpassant)
                .ToArray();
        }
        
        public static Board NewGame()
        {
            return new Board(
                Side.WhiteInitialPosition,
                Side.BlackInitialPosition
                );
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

            if (AvaliableMoves.Count(m => m == move) == 0)
                throw new InvalidMoveException(move, this);

            var piece = moving.GetPieceAt(move.From);
            switch (piece)
            {
                case ChessPieces.Pawn:
                    MakePawnMove(move, ref moving, notmoving);
                    enpassant = ComputeEnpassantSquare(move);
                    break;
                case ChessPieces.King:
                    moving = new Side(
                        move.To,
                        moving.Queens,
                        moving.Bishops,
                        moving.Knights,
                        moving.Rooks,
                        moving.Pawns
                        );
                    break;
                default:
                    moving = moving
                        .RemovePieces(move.From)
                        .AddPieces(piece, move.To.AsBoard);
                    break;
            }

            notmoving = notmoving.RemovePieces(
                GetCapturedSquare(move)
                );

            if (notmoving.Attacks(
                moving.KingLocation, 
                moving.Occupation.AsBoard
                ))
                throw new InvalidMoveException(move, this);

            var white = (this.IsWhiteTurn ? moving : notmoving);
            var black = (this.IsWhiteTurn ? notmoving : moving);
            
            return new Board(white, black, 0, !IsWhiteTurn, 
                enpassant);
        }

        private void MakePawnMove(Move move, 
            ref Side moving, 
            Side notmoving)
        {
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
