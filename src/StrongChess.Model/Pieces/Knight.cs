using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrongChess.Model.Pieces
{
    public struct Knight : IPieceRule
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
            for (Square i = 0; i < 64; i++)
            {
                var square = i.AsBoard;
                var board = Bitboard.Empty.Set(
                    square.Shift(1, 2), square.Shift(1, -2),
                    square.Shift(2, 1), square.Shift(2, -1),
                    square.Shift(-1, 2), square.Shift(-1, -2),
                    square.Shift(-2, 1), square.Shift(-2, -1)
                );
                _Moves[i] = board;
            }
        }

        #endregion
    }
}
