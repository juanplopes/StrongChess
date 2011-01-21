
namespace StrongChess.Model
{
    public struct SquaresSW : IBoardUnit
    {
        public Bitboard AsBoard
        { get { return _masks[(int)Origin]; } }

        public bool IsValid
        { get { return true; } }

        public Square Origin { get; private set; }

        public SquaresSW(Square origin)
            : this()
        { this.Origin = origin; }

        #region static
        static Bitboard[] _masks = new Bitboard[64];
        static SquaresSW()
        {
            for (int i = 0; i < 64; i++)
            {
                Bitboard sq = (1ul << i);
                while (sq != 0)
                {
                    sq = sq.Shift(-1, -1);
                    _masks[i] |= sq;
                }
            }
        }
        #endregion
    }
}
