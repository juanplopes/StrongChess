using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrongChess.Model.Pieces
{
    public struct King : IPieceRule
    {
        public Bitboard GetMoveBoard(Square from)
        {
            return this.GetMoveBoard(from, 0);
        }


        public Bitboard GetMoveBoard(Square from, Bitboard friends)
        {
            return this.GetMoveBoard(from, friends, 0);
        }

        public Bitboard GetMoveBoard(Square from, Bitboard friends, Bitboard enemies)
        {
            return _Moves[from].Clear(friends);
        }

        #region static
        static readonly Bitboard[] _Moves = new Bitboard[64];
        static King()
        {
            int[] knightsq = new int[] { -9, -8, -7, -1, 1, 7, 8, 9 };
            for (Square i = 0; i < 64; i++)
            {
                var bboard = new Bitboard();

                for (int j = 0; j < 8; j++)
                {
                    Square target = i + knightsq[j];
                    if (target.IsValid &&
                        target.File.DistanceFrom(i.File) <= 1 &&
                        target.Rank.DistanceFrom(i.Rank) <= 1)
                        bboard = bboard.Set(target);
                }

                _Moves[i] = bboard;
            }
        }
        #endregion
    }
}
