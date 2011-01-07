using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrongChess.Model.Pieces
{
    public struct King : IPiece
    {
        public Bitboard Board { get; private set; }
        public King(Square location) : this(location.Bitmask)
        {
        }
        public King(Bitboard board)
            : this()
        {
            Board = board;
        }

        public Bitboard GetMoveBoard()
        {
            return this.GetMoveBoard(0);
        }
        
        public Bitboard GetMoveBoard(Bitboard alsoAvoid)
        {
            Bitboard result = 0;

            foreach (var square in Board.GetSetSquares())
                result = result.Set(_Moves[square]);

            return result.Clear(alsoAvoid, Board);
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
