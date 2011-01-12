using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrongChess.Model
{
    public struct DiagonalNW : IBoardUnit
    {
        public DiagonalNW(Square square)
            : this()
        {
            this.Bitmask = _Bitmasks[square];
        }

        public ulong Bitmask
        {
            get;
            private set;
        }

        public bool IsValid
        {
            get { return this.Bitmask > 0; }
        }

        public bool Contains(IBoardUnit bu)
        {
            return (this.Bitmask & bu.Bitmask) > 0;
        }

        public bool Contains(ulong board)
        {
            return (this.Bitmask & board) > 0;
        }

        #region static
        static ulong[] _Bitmasks = new ulong[64];
        static DiagonalNW()
        {
            for (int i = 7; i >= 0; i--)
            {
                ulong diagonalH = 0;
                ulong diagonalV = 0;
                for (int j = 0; j < 8 - (7 - i); j++)
                {
                    diagonalH |= ((1ul << i) << (7 * j));
                    diagonalV |= (((1ul << 7) << (8 * (7 - i)) << (7 * j)));
                }

                for (int j = 0; j < 8 - (7 - i); j++)
                {
                    _Bitmasks[i + (j * 7)] = diagonalH;
                    _Bitmasks[8 * (8 - i) - 1 + (7 * j)] = diagonalV;
                }

            }

        }

        public static Bitboard operator |(DiagonalNW diagonal, IBoardUnit bu)
        {
            return diagonal.Bitmask | bu.Bitmask;
        }

        public static implicit operator Bitboard(DiagonalNW diagonal)
        {
            return new Bitboard(diagonal.Bitmask);
        }
        #endregion
    }
}
