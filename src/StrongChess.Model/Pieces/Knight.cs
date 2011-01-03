using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrongChess.Model.Pieces
{
    public class Knight : IPiece
    {
        public Square Location { get; private set; }
        public Knight(Square location)
        {
            Location = location;
        }


        public bool CanMove(Square to)
        {
            return _Moves[Location].IsSet(to);
        }

        public Bitboard GetMoveBoard()
        {
            return _Moves[Location];
        }

        static readonly Bitboard[] _Moves = new Bitboard[64];

        static Knight()
        {
            int[] knightsq = new int[] { -17, -15, -10, -6, 6, 10, 15, 17 };
            for (Square i = 0; i < 64; i++)
            {
                var bboard = new Bitboard();

                for (int j = 0; j < 8; j++)
                {
                    Square target = i + knightsq[j];
                    if (target.IsValid &&
                        target.File.DistanceFrom(i.File) <= 2 &&
                        target.Rank.DistanceFrom(i.Rank) <= 2)
                        bboard = bboard.Set(target);
                }

                _Moves[i] = bboard;
            }
        }

    }
}
