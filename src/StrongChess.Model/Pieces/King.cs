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
            return _Moves[from].Except(friends);
        }

        #region static
        static readonly Bitboard[] _Moves = new Bitboard[64];
        static King()
        {
            for (Square i = 0; i < 64; i++)
            {
                var square = i.AsBoard;
                var board = Bitboard.Empty.And(
                    square.Shift(0, 1), square.Shift(0, -1),
                    square.Shift(1, 0), square.Shift(-1, 0),
                    square.Shift(1, 1), square.Shift(1, -1),
                    square.Shift(-1, 1), square.Shift(-1, -1));
                _Moves[i] = board;
            }
        }
        #endregion
    }
}
