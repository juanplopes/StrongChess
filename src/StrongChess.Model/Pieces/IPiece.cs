﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrongChess.Model.Pieces
{
    public interface IPiece
    {
        bool CanMove(Square to);
        Bitboard GetMoveBoard();
    }
}
