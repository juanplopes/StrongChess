using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrongChess.Model.Pieces
{
    public struct Bishop : IPieceRule
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
            var allpieces = friends.And(enemies);

            var result = from.DiagonalNE.AsBoard.And(from.DiagonalNW).Except(from);

            var rayTo = from.RayTo;
            var ne = rayTo.NE.Intersect(allpieces).LowestSquare;
            var nw = rayTo.NW.Intersect(allpieces).LowestSquare;
            var se = rayTo.SE.Intersect(allpieces).HighestSquare;
            var sw = rayTo.SW.Intersect(allpieces).HighestSquare;

            return result.Except(friends,
                ne.RayTo.NE, nw.RayTo.NW, se.RayTo.SE, sw.RayTo.SW);
        }
    }
}
