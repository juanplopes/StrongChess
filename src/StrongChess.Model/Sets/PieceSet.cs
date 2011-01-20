using System.Linq;
using System.Collections.Generic;
using StrongChess.Model.Pieces;

namespace StrongChess.Model.Sets
{
    public struct PieceSet<TPieceRule>
        where TPieceRule : IPieceRule, new()
    {
        public Bitboard Locations { get; private set; }
        public PieceSet(Bitboard locations) : this()
        { this.Locations = locations; }

        public IEnumerable<Move> GetMoves(Bitboard friends, Bitboard enemies, bool onlyCaptures = false)
        {
            foreach (var from in Locations.GetSettedSquares())
	        {
                Bitboard destinations = Rules.For<TPieceRule>().GetMoveBoard(from, friends, enemies);
                if (onlyCaptures) destinations &= enemies;
                foreach (var to in destinations.GetSettedSquares())
                    yield return new Move(from, to);
	        }
        }

        public Bitboard GetMoveBoard(Bitboard friends, Bitboard enemies, bool onlyCaptures = false)
        {
            var moveboards = from f in Locations.GetSettedSquares()
                             select Rules.For<TPieceRule>().GetMoveBoard(f, friends, enemies);

            var result = moveboards.Aggregate((a, b) => a | b);
            if (onlyCaptures) result &= enemies;

            return result;
        }
    }
}
