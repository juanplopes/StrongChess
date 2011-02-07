using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrongChess.Model
{
    public struct AttackPath : IBoardUnit
    {
        public Bitboard AsBoard
        {
            get { return _AttackPaths[(int)From, (int)To]; }
        }

        public bool IsValid
        {
            get
            {
                return
                    From.File == To.File || From.Rank == To.Rank ||
                    From.RayTo.NE.Contains(To) ||
                    From.RayTo.NW.Contains(To) ||
                    To.RayTo.NE.Contains(From) ||
                    To.RayTo.NW.Contains(From);
            }
        }

        public Square From { get; private set; }
        public Square To { get; private set; }

        public AttackPath(Square from, Square to)
            : this()
        {
            From = from;
            To = to;
        }

        static Bitboard[,] _AttackPaths = new Bitboard[64, 64];
        static AttackPath()
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
                        _AttackPaths[i, j] = from.RayTo.E.Intersect(to.RayTo.W);
                    else if (from.File == to.File)
                        _AttackPaths[i, j] = from.RayTo.N.Intersect(to.RayTo.S);
                    else if (from.RayTo.NE.Contains(to))
                        _AttackPaths[i, j] = from.RayTo.NE.Intersect(to.RayTo.SW);
                    else
                        _AttackPaths[i, j] = from.RayTo.NW.Intersect(to.RayTo.SE);
                }
        }
    }
}
