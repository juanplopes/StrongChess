using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrongChess.Model.Pieces
{
    public struct Queen : IPiece
    {
        public Square Location { get; private set; }
        public Queen(Square location)
            : this()
        {
            this.Location = location;
        }

        public Bitboard GetMoveBoard()
        {
            return GetMoveBoard(0);
        }

        public Bitboard GetMoveBoard(Bitboard alsoAvoid)
        {
            return GetMoveBoard(alsoAvoid, Bitboard.Empty);
        }

        public Bitboard GetMoveBoard(Bitboard friends, Bitboard enemies)
        {
            return
                new Bishop(this.Location).GetMoveBoard(friends, enemies) |
                new Rook(this.Location).GetMoveBoard(friends, enemies);
        }
    }
}
