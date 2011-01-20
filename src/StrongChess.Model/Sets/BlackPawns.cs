using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrongChess.Model.Sets
{
    public struct BlackPawns : IPawns
    {
        public Bitboard Locations { get; private set; }

        public BlackPawns(Bitboard locations)
            : this()
        {
            this.Locations = locations;
        }

        public bool IsValid
        {
            get
            {
                return this.Locations.BitCount <= 8 &&
                    this.Locations.IsClear(new Rank(0)) &&
                    this.Locations.IsClear(new Rank(7));
            }

        }

        public static BlackPawns InitialPosition
        {
            get
            {
                return new BlackPawns(0xFFul << 48);
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

        public IEnumerable<Move> GetCaptures
            (Bitboard enemies, Square? enpassant = null)
        {
            if (enpassant != null)
                enemies &= new Bitboard().Set((Square)enpassant);

            var bleft = Locations.Clear(new File(7)).Shift(-1, +1).Intersect(enemies);
            var bright = Locations.Clear(new File(0)).Shift(-1, -1).Intersect(enemies);

            return GetMoves(bleft, 7).Union(GetMoves(bright, 9));

        }

        public IEnumerable<Move> GetMovesOneSquareForward()
        {
            return this.GetMovesOneSquareForward(Bitboard.Full);
        }

        public IEnumerable<Move> GetMovesOneSquareForward
            (Bitboard notblockers)
        {
            Bitboard b = (this.Locations >> 8 & notblockers);
            return GetMoves(b, 8);
        }

        public IEnumerable<Move> GetMovesTwoSquaresForward()
        {
            return this.GetMovesTwoSquaresForward(Bitboard.Full);
        }


        public IEnumerable<Move> GetMovesTwoSquaresForward
            (Bitboard notblockers)
        {
            Bitboard b = Locations.Intersect(new Rank(6));
            b = b.Shift(-1, 0).Intersect(notblockers);
            b = b.Shift(-1, 0).Intersect(notblockers);
            foreach (var to in b.GetSettedSquares())
            {
                Square from = to + 16;
                b = b.Clear(to);
                yield return new Move(from, to);
            }
        }

        public Bitboard GetMoveBoard(Bitboard notblockers, Bitboard enemies, Square? enpassant)
        {
            var onesquarforward = (this.Locations >> 8 & notblockers);

            var twosquaresforward = Locations
                .Intersect(new Rank(6))
                .Shift(-1, 0).Intersect(notblockers)
                .Shift(-1, 0).Intersect(notblockers);

            return onesquarforward | twosquaresforward |
                GetCapturesMoveBoard(notblockers, enemies, enpassant);
        }

        public Bitboard GetCapturesMoveBoard(Bitboard notblockers, Bitboard enemies, Square? enpassant)
        {
            if (enpassant != null)
                enemies &= new Bitboard().Set((Square)enpassant);

            var bleft = Locations.Clear(new File(7)).Shift(-1, +1).Intersect(enemies);
            var bright = Locations.Clear(new File(0)).Shift(-1, -1).Intersect(enemies);
            return bleft | bright;
        }

        private IEnumerable<Move> GetMoves(Bitboard b, int offsetFrom)
        {
            foreach (var to in b.GetSettedSquares())
            {
                Square from = to + offsetFrom;
                b = b.Clear(to);
                if (to <= 7)
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
    }
}
