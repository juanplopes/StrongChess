using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrongChess.Model
{
    public struct Rays
    {
        Square origin;
        public Rays(Square origin) : this() { this.origin = origin; }

        public Bitboard N { get { return masksN[origin]; } }
        public Bitboard S { get { return masksS[origin]; } }
        public Bitboard E { get { return masksE[origin]; } }
        public Bitboard W { get { return masksW[origin]; } }
        public Bitboard SE { get { return masksSE[origin]; } }
        public Bitboard SW { get { return masksSW[origin]; } }
        public Bitboard NE { get { return masksNE[origin]; } }
        public Bitboard NW { get { return masksNW[origin]; } }

        #region static
        static Bitboard[] masksN = new Bitboard[64];
        static Bitboard[] masksS = new Bitboard[64];
        static Bitboard[] masksE = new Bitboard[64];
        static Bitboard[] masksW = new Bitboard[64];
        static Bitboard[] masksSE = new Bitboard[64];
        static Bitboard[] masksNE = new Bitboard[64];
        static Bitboard[] masksNW = new Bitboard[64];
        static Bitboard[] masksSW = new Bitboard[64];

        static Rays()
        {
            for (Square sq = 0; sq < 64; sq++)
            {
                masksN[sq] = sq.File.AsBoard.Shift(sq.Rank, 0).Clear(sq);
                masksS[sq] = sq.File.AsBoard.Shift(sq.Rank - 7, 0).Clear(sq);

                masksE[sq] = sq.Rank.AsBoard.Shift(0, sq.File).Clear(sq);
                masksW[sq] = sq.Rank.AsBoard.Shift(0, sq.File - 7).Clear(sq);

                masksNE[sq] = sq.DiagonalNE.AsBoard.Shift(sq.Rank, sq.Rank).Clear(sq);
                masksSW[sq] = sq.DiagonalNE.AsBoard.Shift(sq.Rank - 7, sq.Rank - 7).Clear(sq);

                masksNW[sq] = sq.DiagonalNW.AsBoard.Shift(sq.Rank, -sq.Rank).Clear(sq);
                masksSE[sq] = sq.DiagonalNW.AsBoard.Shift(sq.Rank - 7, 7 - sq.Rank).Clear(sq);
            }
        }
        #endregion
    }
}
