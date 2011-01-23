using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StrongChess.Model.Util;

namespace StrongChess.Model
{
    public struct DiagonalNW : IBoardUnit
    {
        int index;
        public int Index { get { return index; } }
        public Bitboard AsBoard { get { return masks[index]; } }

        public bool IsValid
        {
            get { return index >= 0 && index <= 14; }
        }

        public DiagonalNW(int index) : this() { this.index = index; }


        #region static
        static Bitboard[] masks = new Bitboard[15];
        static DiagonalNW()
        {
            var initial = Bitboard.With.H1.G2.F3.E4.D5.C6.B7.A8.Build();

            for (int i = 7; i >= 0; i--)
                masks[i] = initial.Shift(i - 7,  0);

            for (int i = 8; i < 15; i++)
                masks[i] = initial.Shift(0, i - 7);

        }
        public static implicit operator int(DiagonalNW diagonal)
        {
            return diagonal.index;
        }

        public static implicit operator DiagonalNW(int index)
        {
            return new DiagonalNW(index);
        }

        #endregion
    }
}
