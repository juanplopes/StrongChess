
namespace StrongChess.Model
{
    public struct DiagonalNE : IBoardUnit
    {
        int index;
        public int Index { get { return index; } }
        public ulong Bitmask { get { return masks[index + 7]; } }
        public Bitboard AsBoard { get { return masks[index + 7]; } }

        public bool IsValid
        {
            get { return index >= -7 && index <= 7; }
        }

        public DiagonalNE(int index) : this() { this.index = index; }



        #region static
        static Bitboard[] masks = new Bitboard[15];
        static DiagonalNE()
        {
            var initial = Bitboard.With.A1.B2.C3.D4.E5.F6.G7.H8.Build();

            for (int i = 7; i >= 0; i--)
                masks[i] = initial.Shift(7 - i, 0);

            for (int i = 8; i < 15; i++)
                masks[i] = initial.Shift(0, i - 7);

        }

        #endregion
    }
}
