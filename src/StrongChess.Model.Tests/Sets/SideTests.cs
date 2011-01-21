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

        [Test]
        public void GetDiscoveredDiagonalAttackMoves_BishopA1KnightInD4A8TargetInF6()
        {
            // arrange
            var s = new Side("G1",
                new PieceSet<Queen>(),
                new PieceSet<Bishop>(Bitboard.With.A1),
                new PieceSet<Knight>(Bitboard.With.D4.A8),
                new PieceSet<Rook>(),
                new WhitePawns()
                );
            
            // arrange
            var moves = s.GetDiscoveredDiagonalAttackMoves("F6", Bitboard.Empty);

            // assert
            moves.Should().Have.SameSequenceAs(
                new Move("D4", "C2"),
                new Move("D4", "E2"),
                new Move("D4", "B3"),
                new Move("D4", "F3"),
                new Move("D4", "B5"),
                new Move("D4", "F5"),
                new Move("D4", "C6"),
                new Move("D4", "E6")
                );
        }

        [Test]
        public void GetDiscoveredDiagonalAttackMoves_BishopA1RookInD4A8TargetInF6()
        {
            // arrange
            var s = new Side("G1",
                new PieceSet<Queen>(),
                new PieceSet<Bishop>(Bitboard.With.A1),
                new PieceSet<Knight>(),
                new PieceSet<Rook>(Bitboard.With.D4.A8),
                new WhitePawns()
                );

            var expected = Bitboard.With.Rank4.FileD.Except.D4.Build();

            // arrange
            var moves = s.GetDiscoveredDiagonalAttackMoves("F6", Bitboard.Empty).AsMoveboard();

            // assert
            moves.Should().Be(expected);
        }
    }
}
