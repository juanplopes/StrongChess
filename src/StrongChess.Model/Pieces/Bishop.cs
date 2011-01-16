using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrongChess.Model.Pieces
{
    public struct Bishop : IPiece
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

            var ne = from.DiagonalNE;
            var nw = from.DiagonalNW;

            var newSq = from.AsBoard;
            while (true)
            {
                newSq = newSq << 9;
                if (!ne.AsBoard.Contains(newSq)) break;
                //if (friends.Contains(newSq)) break;
                result = result | newSq;
                //if (enemies.Contains(newSq)) break;
                if (allpieces.Contains(newSq)) break;
            }

            newSq = from.AsBoard;
            while (true)
            {
                newSq = newSq >> 9;
                if (!ne.AsBoard.Contains(newSq)) break;
                //if (friends.Contains(newSq)) break;
                result = result | newSq;
                //if (enemies.Contains(newSq)) break;
                if (allpieces.Contains(newSq)) break;
            }

            newSq = from.AsBoard;
            while (true)
            {
                newSq = newSq << 7;
                if (!nw.AsBoard.Contains(newSq)) break;
                //if (friends.Contains(newSq)) break;
                result = result | newSq;
                //if (enemies.Contains(newSq)) break;
                if (allpieces.Contains(newSq)) break;
            }

            newSq = from.AsBoard;
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
