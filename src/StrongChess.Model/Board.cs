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

            if (moving.GetPieceAt(move.From) == ChessPieces.Pawn)
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
                    (IPawns) new WhitePawns(locations) :
                    (IPawns) new BlackPawns(locations);

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

                Bitboard negative;
                if (move.To != Enpassant)
                    negative = ~move.To.AsBoard;
                else if (move.To.Rank == 6)
                    negative = ~(new Square(5, move.To.File).AsBoard);
                else 
                    negative = ~(new Square(4, move.To.File).AsBoard);

                notmoving = new Side(
                    notmoving.KingLocation,
                    new PieceSet<Queen>(notmoving.Queens.Locations & negative),
                    new PieceSet<Bishop>(notmoving.Bishops.Locations & negative),
                    new PieceSet<Knight>(notmoving.Knights.Locations & negative),
                    new PieceSet<Rook>(notmoving.Rooks.Locations & negative),
                    (IsWhiteTurn ?
                        (IPawns)new BlackPawns(notmoving.Pawns.Locations & negative)
                        :
                        (IPawns)new WhitePawns(notmoving.Pawns.Locations & negative)
                      )
                    );
            }
            else
            {
                throw new NotImplementedException(
                    string.Format("There is no support to {0} moves", moving.GetPieceAt(move.From))
                    );
            }

            var white = (this.IsWhiteTurn ? moving : notmoving);
            var black = (this.IsWhiteTurn ? notmoving : moving);
            
            return new Board(white, black, 0, !IsWhiteTurn, enpassant);
        }
        
    }
}
