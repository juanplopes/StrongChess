
namespace StrongChess.Model
{
    public struct DiagonalNE : IBoardUnit
    {
        public DiagonalNE(Square square)
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
        static DiagonalNE()
        {

            for (int i = 0; i < 8; i++)
            {
                ulong diagonalH = 0; // A..H
                ulong diagonalV = 0; // 1..8
                for (int j = 0; j < 8 - i; j++)
                {
                    diagonalH |= ((1ul << i) << (9 * j));
                    diagonalV |= ((1ul << (i * 8)) << (9 * j));
                }

                for (int j = 0; j < 8 - i; j++)
                {
                    _Bitmasks[i + (j * 9)] = diagonalH;
                    _Bitmasks[(i * 8) + (j * 9)] = diagonalV;
                }
            }
        }

        public static Bitboard operator |(DiagonalNE diagonal, IBoardUnit bu)
        {
            return diagonal.Bitmask | bu.Bitmask;
        }

        public static implicit operator Bitboard(DiagonalNE diagonal)
        {
            return new Bitboard(diagonal.Bitmask);
        }
        #endregion
    }
}
