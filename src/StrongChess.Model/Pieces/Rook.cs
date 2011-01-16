using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrongChess.Model.Pieces
{
    public struct Rook : IPiece
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
            Bitboard allpieces = friends | enemies;

            Bitboard result = Bitboard.Empty;

            var file = from.File;
            var rank = from.Rank;
            var newSq = from.AsBoard;
            while (true)
            {
                newSq = newSq << 8;
                if (!file.AsBoard.Contains(newSq)) break;
                //if (friends.Contains(newSq)) break;
                result = result | newSq;
                //if (enemies.Contains(newSq)) break;
                if (allpieces.Contains(newSq)) break;
            }

            newSq = from.AsBoard;
            while (true)
            {
                newSq = newSq >> 8;
                if (!file.AsBoard.Contains(newSq)) break;
                //if (friends.Contains(newSq)) break;
                result = result | newSq;
                //if (enemies.Contains(newSq)) break;
                if (allpieces.Contains(newSq)) break;
            }

            newSq = from.AsBoard;
            while (true)
            {
                newSq = newSq << 1;
                if (!rank.AsBoard.Contains(newSq)) break;
                //if (friends.Contains(newSq)) break;
                result = result | newSq;
                //if (enemies.Contains(newSq)) break;
                if (allpieces.Contains(newSq)) break;
            }

            newSq = from.AsBoard;
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
