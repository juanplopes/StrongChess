using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrongChess.Model.Pieces
{
    public struct Rook : IPiece
    {

        public Square Location { get; private set; }
        public Rook(Square location)
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
            Bitboard allpieces = friends | enemies;

            Bitboard result = Bitboard.Empty;

            var file = this.Location.File;
            var rank = this.Location.Rank;
            var newSq = this.Location.AsBoard;
            while (true)
            {
                newSq = newSq << 8;
                if (!file.AsBoard.Contains(newSq)) break;
                //if (friends.Contains(newSq)) break;
                result = result | newSq;
                //if (enemies.Contains(newSq)) break;
                if (allpieces.Contains(newSq)) break;
            }

            newSq = this.Location.Bitmask;
            while (true)
            {
                newSq = newSq >> 8;
                if (!file.AsBoard.Contains(newSq)) break;
                //if (friends.Contains(newSq)) break;
                result = result | newSq;
                //if (enemies.Contains(newSq)) break;
                if (allpieces.Contains(newSq)) break;
            }

            newSq = this.Location.Bitmask;
            while (true)
            {
                newSq = newSq << 1;
                if (!rank.AsBoard.Contains(newSq)) break;
                //if (friends.Contains(newSq)) break;
                result = result | newSq;
                //if (enemies.Contains(newSq)) break;
                if (allpieces.Contains(newSq)) break;
            }

            newSq = this.Location.Bitmask;
            while (true)
            {
                newSq = newSq >> 1;
                if (!rank.AsBoard.Contains(newSq)) break;
                //if (friends.Contains(newSq)) break;
                result = result | newSq;
                //if (enemies.Contains(newSq)) break;
                if (allpieces.Contains(newSq)) break;
            }

            result = result & ~friends;

            return result;
        }

    }
}
