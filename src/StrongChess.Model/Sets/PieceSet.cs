using System.Linq;
using System.Collections.Generic;
using StrongChess.Model.Pieces;

namespace StrongChess.Model.Sets
{
    public struct PieceSet<T>
        where T : IPieceRule, new()
    {
        public Bitboard Locations { get; private set; }
        public PieceSet(Bitboard locations) : this()
        { this.Locations = locations; }

        public PieceSet(IBoardUnit bu)
            : this(bu.AsBoard)
        {}
        

        public IEnumerable<Move> GetMoves(Bitboard friends, Bitboard enemies, bool onlyCaptures = false)
        {
            foreach (var from in Locations.Squares)
	        {
                Bitboard destinations = Rules.For<T>().GetMoveBoard(from, friends, enemies);
                if (onlyCaptures) destinations &= enemies;
                foreach (var to in destinations.Squares)
                    yield return new Move(from, to);
	        }
        }

        public IEnumerable<Move> GetMoves(Bitboard friends, Bitboard enemies, Bitboard filterFrom, Bitboard filterTo, bool onlyCaptures = false)
        {
            Bitboard pieces = Locations & filterFrom;
            foreach (var from in pieces.Squares)
            {
                Bitboard destinations = Rules.For<T>().GetMoveBoard(from, friends, enemies);
                if (onlyCaptures) destinations &= enemies;
                destinations &= filterTo;
                foreach (var to in destinations.Squares)
                    yield return new Move(from, to);
            }
        }

        public Bitboard GetMoveBoard(Bitboard friends, Bitboard enemies, bool onlyCaptures = false)
        {
            var moveboards = from f in Locations.Squares
                             select Rules.For<T>().GetMoveBoard(f, friends, enemies);

            var result = moveboards.Aggregate((a, b) => a | b);
            if (onlyCaptures) result &= enemies;

            return result;
        }

        public IEnumerable<Move> GetDirectAttackMoves(Square target, Bitboard friends, Bitboard enemies)
        {
            var hotsquares = Rules.For<T>().GetMoveBoard(target, friends, enemies);
            foreach (var from in Locations.Squares)
	        {
                var candidates = Rules.For<T>().GetMoveBoard(from, friends, enemies);
                Bitboard spot = candidates & hotsquares;
                foreach (var to in spot.Squares)
                    yield return new Move(from, to);
            }
	    }
    }
}
