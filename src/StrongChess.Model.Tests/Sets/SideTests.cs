using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;
using SharpTestsEx;
using StrongChess.Model.Sets;
using StrongChess.Model.Pieces;

namespace StrongChess.Model.Tests.Sets
{
    [TestFixture]
    public class SideTests
    {
        [Test]
        public void WhiteInitalPosition_Occupation_Rank1Rank2()
        {
            // arrange
            var w = Side.WhiteInitialPosition;

            // act

            // assert
            w.Occupation.Should().Be(Bitboard.With.Rank1.Rank2.Build());
        }

        [Test]
        public void GetMoves_WhiteInitialPosition_CoversRanks3And4()
        {
            // arrange
            var w = Side.WhiteInitialPosition;
            var expected = Bitboard.With.Rank3.Rank4.Build();

            // act 
            var moves = w.GetMoves(Bitboard.Empty, null).AsMoveboard();

            // assert
            moves.Should().Be(expected);
        }

        [Test]
        public void GetMoveBoard_WhiteInitialPosition_CoversRanks3And4()
        {
            // arrange
            var w = Side.WhiteInitialPosition;
            var expected = Bitboard.With.Rank3.Rank4.Build();

            // act 
            var moves = w.GetMoveBoard(Bitboard.Empty, null);

            // assert
            moves.Should().Be(expected);
        }

        [Test]
        public void BlackInitalPosition_Occupation_Rank7Rank8()
        {
            // arrange
            var b = Side.BlackInicialPosition;

            // act

            // assert
            b.Occupation.Should().Be(Bitboard.With.Rank7.Rank8.Build());
        }

        [Test]
        public void GetMoves_BlackInitialPosition_ConvertsRanks5And6()
        {
            // arrange
            var b = Side.BlackInicialPosition;
            var expected = Bitboard.With.Rank5.Rank6.Build();

            // act 
            var moves = b.GetMoves(Bitboard.Empty, null).AsMoveboard();

            // assert
            moves.Should().Be(expected);
        }

        [Test]
        public void GetBlockersToDiagonalAttacks_BishopA1RookInD4TargetInE5_ReturnsD4Bitboard()
        {
            // arrange
            var s = new Side("G1",
                new PieceSet<Queen>(),
                new PieceSet<Bishop>(Bitboard.With.A1),
                new PieceSet<Knight>(),
                new PieceSet<Rook>(Bitboard.With.D4),
                new WhitePawns()
                );

            var target = new Square("E5");

            // act
            var blockers = s.GetBlockersToDiagonalAttacks(target, Bitboard.Empty);

            // assert
            blockers.Should().Be(new Square("D4").AsBoard);
        }

        [Test]
        public void GetBlockersToDiagonalAttacks_BishopA1WhitePawnsInitialPositionTargetInE5_ReturnsB2Bitboard()
        {
            // arrange
            var s = new Side("G1",
                new PieceSet<Queen>(),
                new PieceSet<Bishop>(Bitboard.With.A1),
                new PieceSet<Knight>(),
                new PieceSet<Rook>(),
                WhitePawns.InitialPosition
                );

            var target = new Square("E5");

            // act
            var blockers = s.GetBlockersToDiagonalAttacks(target, Bitboard.Empty);

            // assert
            blockers.Should().Be(new Square("B2").AsBoard);
        }
    }
}
