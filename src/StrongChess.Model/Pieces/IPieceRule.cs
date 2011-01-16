using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrongChess.Model.Pieces
{
    public interface IPieceRule
    {
        Bitboard GetMoveBoard(Square from, Bitboard friends, Bitboard enemies);
    }
}
