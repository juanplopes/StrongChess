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
            var allpieces = friends.Set(enemies);

            var result = from.DiagonalNE.AsBoard.Set(from.DiagonalNW).Clear(from);
            
            var rayTo = from.RayTo;
            var ne = rayTo.NE.Intersect(allpieces).LowerSquare;
            var nw = rayTo.NW.Intersect(allpieces).LowerSquare;
            var se = rayTo.SE.Intersect(allpieces).HigherSquare;
            var sw = rayTo.SW.Intersect(allpieces).HigherSquare;

            if (ne.IsValid) result = result.Clear(ne.RayTo.NE);
            if (nw.IsValid) result = result.Clear(nw.RayTo.NW);
            if (se.IsValid) result = result.Clear(se.RayTo.SE);
            if (sw.IsValid) result = result.Clear(sw.RayTo.SW);

            return result.Clear(friends);
        }
    }
}
