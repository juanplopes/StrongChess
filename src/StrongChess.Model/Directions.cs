using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrongChess.Model
{
    public struct Directions
    {
        public Square Origin { get; private set; }

        public Directions(Square origin)
            : this()
        { this.Origin = origin; }


        public Bitboard N
        { get { return _masksN[(int)Origin]; } }

        public Bitboard S
        { get { return _masksS[(int)Origin]; } }

        public Bitboard E
        { get { return _masksE[(int)Origin]; } }

        public Bitboard W
        { get { return _masksW[(int)Origin]; } }
        
        public Bitboard SE
        { get { return _masksSE[(int)Origin]; } }

        public Bitboard SW
        { get { return _masksSW[(int)Origin]; } }

        public Bitboard NE
        { get { return _masksNE[(int)Origin]; } }
        
        public Bitboard NW
        { get { return _masksNW[(int)Origin]; } }
        
        

        #region static
        static Bitboard[] _masksN = new Bitboard[64];
        static Bitboard[] _masksS = new Bitboard[64];
        static Bitboard[] _masksE = new Bitboard[64];
        static Bitboard[] _masksW = new Bitboard[64];
        static Bitboard[] _masksSE = new Bitboard[64];
        static Bitboard[] _masksNE = new Bitboard[64];
        static Bitboard[] _masksNW = new Bitboard[64];
        static Bitboard[] _masksSW = new Bitboard[64];
        static Directions()
        {
            for (int i = 0; i < 64; i++)
            {
                Bitboard sq = (1ul << i);
                while (sq != 0)
                {
                    sq = sq.Shift(1, 0);
                    _masksN[i] |= sq;
                }

                sq = (1ul << i);
                while (sq != 0)
                {
                    sq = sq.Shift(-1, 0);
                    _masksS[i] |= sq;
                }

                sq = (1ul << i);
                while (sq != 0)
                {
                    sq = sq.Shift(-1, 1);
                    _masksSE[i] |= sq;
                }

                sq = (1ul << i);
                while (sq != 0)
                {
                    sq = sq.Shift(1, 1);
                    _masksNE[i] |= sq;
                }

                sq = (1ul << i);
                while (sq != 0)
                {
                    sq = sq.Shift(1, -1);
                    _masksNW[i] |= sq;
                }

                sq = (1ul << i);
                while (sq != 0)
                {
                    sq = sq.Shift(-1, -1);
                    _masksSW[i] |= sq;
                }

                sq = (1ul << i);
                while (sq != 0)
                {
                    sq = sq.Shift(0, 1);
                    _masksE[i] |= sq;
                }

                sq = (1ul << i);
                while (sq != 0)
                {
                    sq = sq.Shift(0, -1);
                    _masksW[i] |= sq;
                }
            }
        }
        #endregion
    }
}
