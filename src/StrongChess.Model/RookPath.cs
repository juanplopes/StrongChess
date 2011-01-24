using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrongChess.Model
{
    public struct RookPath : IBoardUnit
    {
        public Bitboard AsBoard
        {
            get { return _RookPaths[(int)From, (int)To] ;}
        }

        public bool IsValid
        {
            get { return From.File == To.File || From.Rank == To.Rank; }
        }

        public Square From { get; private set; }
        public Square To { get; private set; }
        
        public RookPath(Square from, Square to) : this()
        {
            From = from;
            To = to;
        }

        static Bitboard[,] _RookPaths = new Bitboard[64, 64];
        static RookPath()
        {
            Square from, to;
            for (int i = 0; i < 64; i++)
                for (int j = 0; j < 64; j++)
                {
                    if (i < j)
                    { from = i; to = j; }
                    else
                    { from = j; to = i; }

                    AttackMasks f = new AttackMasks(from);
                    AttackMasks t = new AttackMasks(to);

                    if (from.Rank == to.Rank)
                        _RookPaths[i, j] = from.RayTo.E.Intersect(to.RayTo.W);
                    else if (from.File == to.File)
                        _RookPaths[i, j] = from.RayTo.N.Intersect(to.RayTo.S);
                }
        }
    }
}
