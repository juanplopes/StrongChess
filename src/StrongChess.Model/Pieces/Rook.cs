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
            var allpieces = friends.Set(enemies);

            var result = from.File.AsBoard.Set(from.Rank).Clear(from);

            var rayTo = from.RayTo;
            var n = rayTo.N.Intersect(allpieces).LowerSquare;
            var s = rayTo.S.Intersect(allpieces).HigherSquare;
            var e = rayTo.E.Intersect(allpieces).LowerSquare;
            var w = rayTo.W.Intersect(allpieces).HigherSquare;

            if (n.IsValid) result = result.Clear(n.RayTo.N);
            if (s.IsValid) result = result.Clear(s.RayTo.S);
            if (e.IsValid) result = result.Clear(e.RayTo.E);
            if (w.IsValid) result = result.Clear(w.RayTo.W);

            return result.Clear(friends);
        }

    }
}
