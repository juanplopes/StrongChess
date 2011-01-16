using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrongChess.Model.Sets
{
    public struct WhitePawns : IPawns
    {
        public Bitboard Bitboard { get; private set; }

        public WhitePawns(Bitboard bitboard)
            : this()
        {
            this.Bitboard = bitboard;
        }

        public static WhitePawns InitialPosition
        {
            get
            {
                return new WhitePawns(0xFFul << 8);
            }
        }

        public IEnumerable<Move> GetAllMoves(
            Bitboard notblockers,
            Bitboard enemies,
            Square? enpassant
            )
        {
            return this
                .GetMovesOneSquareForward(notblockers)
                .Union(this.GetMovesTwoSquaresForward(notblockers))
                .Union(this.GetCaptures(enemies, enpassant));
        }


        public IEnumerable<Move> GetMovesOneSquareForward()
        {
            return this.GetMovesOneSquareForward(Bitboard.Full);
        }

        public IEnumerable<Move> GetMovesTwoSquaresForward()
        {
            return this.GetMovesTwoSquaresForward(Bitboard.Full);
        }

        public IEnumerable<Move> GetMovesTwoSquaresForward
            (Bitboard notblockers)
        {
            var b = Bitboard.Intersect(new Rank(1));
            b = b.Shift(1, 0).Intersect(notblockers);
            b = b.Shift(1, 0).Intersect(notblockers);
            
            foreach(var to in b.GetSetSquares())
            {
                Square from = to - 16;
                b = b.Clear(to);
                yield return new Move(from, to);
            }
        }

        public IEnumerable<Move> GetCaptures
            (Bitboard enemies, Square? enpassant = null)
        {
            if (enpassant != null)
                enemies &= new Bitboard().Set((Square)enpassant);

            var bleft = Bitboard.Clear(new File(0)).Shift(1, -1).Intersect(enemies);
            var bright = Bitboard.Clear(new File(7)).Shift(1, 1).Intersect(enemies);

            return GetMoves(bleft, 7).Union(GetMoves(bright, 9));

        }

        public IEnumerable<Move> GetMovesOneSquareForward
            (Bitboard notblockers)
        {
            Bitboard b = (this.Bitboard << 8 & notblockers);
            return GetMoves(b, 8);
        }



        private IEnumerable<Move> GetMoves(Bitboard b, int offsetFrom)
        {
            foreach (var to in b.GetSetSquares())
            {
                Square from = to - offsetFrom;
                b = b.Clear(to);
                if (to >= 56)
                {
                    yield return new Move(from, to, MoveTypes.PawnToQueenPromotion);
                    yield return new Move(from, to, MoveTypes.PawnToRookPromotion);
                    yield return new Move(from, to, MoveTypes.PawnToBishopPromotion);
                    yield return new Move(from, to, MoveTypes.PawnToKnightPromotion);

                }
                else
                {
                    yield return new Move(from, to);
                }
            }
        }

        public bool IsValid
        {
            get
            {
                return this.Bitboard.BitCount <= 8 &&
                    this.Bitboard.IsClear(new Rank(0)) &&
                    this.Bitboard.IsClear(new Rank(7));
            }
        }


    }
}
