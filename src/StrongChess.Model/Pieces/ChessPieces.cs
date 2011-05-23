using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrongChess.Model.Pieces
{
    [Flags]
    public enum ChessPieces
    {
        None = 0,
        King = 1,
        Queen = 2,
        Bishop = 4,
        Knight = 8,
        Rook = 16,
        Pawn = 32
    }
}
