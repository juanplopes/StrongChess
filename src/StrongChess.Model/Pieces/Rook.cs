using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrongChess.Model.Pieces
{
    public struct Rook : IPieceRule
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
            var result = from.File.AsBoard.And(from.Rank).Except(from);

            return result.Except(friends,
                from.RayTo.N.Intersect(allpieces).LowestSquare.RayTo.N,
                from.RayTo.E.Intersect(allpieces).LowestSquare.RayTo.E,
                from.RayTo.S.Intersect(allpieces).HighestSquare.RayTo.S,
                from.RayTo.W.Intersect(allpieces).HighestSquare.RayTo.W);
            
        }

    }
}
