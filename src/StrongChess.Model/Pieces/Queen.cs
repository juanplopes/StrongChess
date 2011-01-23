using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrongChess.Model.Pieces
{
    public struct Queen : IPieceRule
    {
        static IPieceRule bishop = Rules.For<Bishop>();
        static IPieceRule rook = Rules.For<Rook>();

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
            return
                rook.GetMoveBoard(from, friends, enemies).And(
                bishop.GetMoveBoard(from, friends, enemies));
        }
    }
}
