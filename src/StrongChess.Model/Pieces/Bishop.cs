using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrongChess.Model.Pieces
{
    public struct Bishop : IPiece
    {
        public Square Location { get; private set; }
        public Bishop(Square location)
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

            var ne = this.Location.DiagonalNE;
            var nw = this.Location.DiagonalNW;

            var newSq = this.Location.AsBoard;
            while (true)
            {
                newSq = newSq << 9;
                if (!ne.AsBoard.Contains(newSq)) break;
                //if (friends.Contains(newSq)) break;
                result = result | newSq;
                //if (enemies.Contains(newSq)) break;
                if (allpieces.Contains(newSq)) break;
            }

            newSq = this.Location.Bitmask;
            while (true)
            {
                newSq = newSq >> 9;
                if (!ne.AsBoard.Contains(newSq)) break;
                //if (friends.Contains(newSq)) break;
                result = result | newSq;
                //if (enemies.Contains(newSq)) break;
                if (allpieces.Contains(newSq)) break;
            }

            newSq = this.Location.Bitmask;
            while (true)
            {
                newSq = newSq << 7;
                if (!nw.AsBoard.Contains(newSq)) break;
                //if (friends.Contains(newSq)) break;
                result = result | newSq;
                //if (enemies.Contains(newSq)) break;
                if (allpieces.Contains(newSq)) break;
            }

            newSq = this.Location.Bitmask;
            while (true)
            {
                newSq = newSq >> 7;
                if (!nw.AsBoard.Contains(newSq)) break;
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
