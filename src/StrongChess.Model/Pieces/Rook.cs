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

            var rayTo = from.RayTo;
            var n = rayTo.N.Intersect(allpieces).LowestSquare;
            var s = rayTo.S.Intersect(allpieces).HighestSquare;
            var e = rayTo.E.Intersect(allpieces).LowestSquare;
            var w = rayTo.W.Intersect(allpieces).HighestSquare;

            return result.Except(friends,
                n.RayTo.N, s.RayTo.S, e.RayTo.E, w.RayTo.W);
        }

    }
}
