using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrongChess.Model.Pieces
{
    public struct Knight : IPiece
    {
        public Bitboard GetMoveBoard(Square from)
        {
            return GetMoveBoard(from, 0);
        }


        public Bitboard GetMoveBoard(Square from, Bitboard friends)
        {
            return GetMoveBoard(from, friends, 0);
        }

        public Bitboard GetMoveBoard(Square from, Bitboard friends, Bitboard enemies)
        {
            return _Moves[from].Clear(friends, enemies);
        }

        #region static

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

        #endregion
    }
}
