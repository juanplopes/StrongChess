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
            var result = Bitboard.Empty.And(from.File, from.Rank).Except(from);

            return result.Except(friends,
                from.RayTo.NE.Intersect(allpieces).LowestSquare.RayTo.NE,
                from.RayTo.NW.Intersect(allpieces).LowestSquare.RayTo.NW,
                from.RayTo.SE.Intersect(allpieces).HighestSquare.RayTo.SE,
                from.RayTo.SW.Intersect(allpieces).HighestSquare.RayTo.SW);
        }
    }
}
