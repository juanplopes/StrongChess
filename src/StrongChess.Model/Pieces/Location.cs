using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrongChess.Model.Pieces
{
    public class Location
    {
        public IPiece Piece { get; private set; }
        public Square Square { get; private set; }

        public Location(IPiece piece, Square square)
        {
            Piece = piece;
            Square = square;
        }

        public bool CanMoveTo(Square anotherSquare)
        {
            return Piece.CanMove(Square, anotherSquare);
        }
    }
}
