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
        public ulong Bitmask { get { return masks[index]; } }
        public Bitboard AsBoard { get { return Bitmask; } }

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

            masks[7] = initial;

            for (int i = 6; i >= 0; i--)
                masks[i] = masks[i + 1].Clear(masks[i + 1].LowSquare) >> 8;

            for (int i = 8; i < 15; i++)
                masks[i] = masks[i - 1].Clear(masks[i - 1].LowSquare) << 1;

        }
       
        #endregion
    }
}
