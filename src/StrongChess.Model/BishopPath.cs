using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrongChess.Model
{
    public struct BishopPath : IBoardUnit
    {
        public Bitboard AsBoard
        {
            get { return _BishopPaths[(int)From, (int)To] ;}
        }

        public bool IsValid
        {
            get 
            {
                return
                    From.RayTo.NE.Contains(To) ||
                    From.RayTo.NW.Contains(To) ||
                    To.RayTo.NE.Contains(From) ||
                    To.RayTo.NW.Contains(From);
            }
        }

        public Square From { get; private set; }
        public Square To { get; private set; }
        
        public BishopPath(Square from, Square to) : this()
        {
            From = from;
            To = to;
        }

        static Bitboard[,] _BishopPaths = new Bitboard[64, 64];
        static BishopPath()
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

                    if (from.RayTo.NE.Contains(to))
                        _BishopPaths[i, j] = from.RayTo.NE.Intersect(to.RayTo.SW);
                    else
                        _BishopPaths[i, j] = from.RayTo.NW.Intersect(to.RayTo.SE);
                }
        }
    }
}
