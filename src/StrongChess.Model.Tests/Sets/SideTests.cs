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
        public void GetBlockersToStaightAttacks_RookE1BishopE4TargetE5_ReturnsD4Bitboard()
        {
            // arrange
            var s = new Side("G1",
                new PieceSet<Queen>(),
                new PieceSet<Bishop>(Bitboard.With.E4),
                new PieceSet<Knight>(),
                new PieceSet<Rook>(Bitboard.With.E1),
                new WhitePawns()
                );

            var target = new Square("E5");

            // act
            var blockers = s.GetBlockersToStraightAttacks(target, Bitboard.Empty);

            // assert
            blockers.Should().Be(new Square("E4").AsBoard);
        }

        [Test]
        public void GetBlockersToStaightAttacks_RookA5BishopD5TargetE5_ReturnsD4Bitboard()
        {
            // arrange
            var s = new Side("G1",
                new PieceSet<Queen>(),
                new PieceSet<Bishop>(Bitboard.With.D5),
                new PieceSet<Knight>(),
                new PieceSet<Rook>(Bitboard.With.A5),
                new WhitePawns()
                );

            var target = new Square("E5");

            // act
            var blockers = s.GetBlockersToStraightAttacks(target, Bitboard.Empty);

            // assert
            blockers.Should().Be(new Square("D5").AsBoard);
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

        [Test]
        public void GetDiscoveredDiagonalAttackMoves_BishopA1KingD4TargetInF6()
        {
            // arrange
            var s = new Side("D4",
                new PieceSet<Queen>(),
                new PieceSet<Bishop>(Bitboard.With.A1),
                new PieceSet<Knight>(),
                new PieceSet<Rook>(),
                new WhitePawns()
                );

            var expected = Bitboard.With.C4.C5.D5.E4.E3.D3.Build();

            // arrange
            var moves = s.GetDiscoveredDiagonalAttackMoves("F6", Bitboard.Empty).AsMoveboard();

            // assert
            moves.Should().Be(expected);
        }

        [Test]
        public void GetDiscoveredDiagonalAttackMoves_BishopH8KingF6TargetInC3()
        {
            // arrange
            var s = new Side("F6",
                new PieceSet<Queen>(),
                new PieceSet<Bishop>(Bitboard.With.H8),
                new PieceSet<Knight>(),
                new PieceSet<Rook>(),
                new WhitePawns()
                );

            var expected = Bitboard.With.F7.E7.G6.E6.F5.G5.Build();

            // arrange
            var moves = s.GetDiscoveredDiagonalAttackMoves("C3", Bitboard.Empty).AsMoveboard();

            // assert
            moves.Should().Be(expected);
        }

        [Test]
        public void GetDiscoveredDiagonalAttackMoves_BishopA8KingC6TargetInF3()
        {
            // arrange
            var s = new Side("C6",
                new PieceSet<Queen>(),
                new PieceSet<Bishop>(Bitboard.With.A8),
                new PieceSet<Knight>(),
                new PieceSet<Rook>(),
                new WhitePawns()
                );

            var expected = Bitboard.With.C7.D7.B6.D6.B5.C5.Build();

            // arrange
            var moves = s.GetDiscoveredDiagonalAttackMoves("F3", Bitboard.Empty).AsMoveboard();

            // assert
            moves.Should().Be(expected);
        }

        [Test]
        public void GetDiscoveredDiagonalAttackMoves_BishopH1KingF3TargetInC6()
        {
            // arrange
            var s = new Side("F3",
                new PieceSet<Queen>(),
                new PieceSet<Bishop>(Bitboard.With.H1),
                new PieceSet<Knight>(),
                new PieceSet<Rook>(),
                new WhitePawns()
                );

            var expected = Bitboard.With.F4.G4.E3.G3.E2.F2.Build();

            // arrange
            var moves = s.GetDiscoveredDiagonalAttackMoves("C6", Bitboard.Empty).AsMoveboard();

            // assert
            moves.Should().Be(expected);
        }

        [Test]
        public void GetDiscoveredDiagonalAttackMoves_BishopH1WhitePawnsInitialPositionTargetInC6()
        {
            // arrange
            var s = new Side("G1",
                new PieceSet<Queen>(),
                new PieceSet<Bishop>(Bitboard.With.H1),
                new PieceSet<Knight>(),
                new PieceSet<Rook>(),
                WhitePawns.InitialPosition
                );

            //var expected = Bitboard.With.F4.G4.E3.G3.E2.F2.Build();

            // arrange
            var moves = s.GetDiscoveredDiagonalAttackMoves("C6", Bitboard.Empty);

            // assert
            moves.Should().Have.SameSequenceAs(
                new Move("G2", "G3"),
                new Move("G2", "G4")
                );
        }

        [Test]
        public void GetDiscoveredDiagonalAttackMoves_BishopH8BlackPawnsInitialPositionTargetInC3()
        {
            // arrange
            var s = new Side("G8",
                new PieceSet<Queen>(),
                new PieceSet<Bishop>(Bitboard.With.H8),
                new PieceSet<Knight>(),
                new PieceSet<Rook>(),
                BlackPawns.InitialPosition
                );

            //var expected = Bitboard.With.F4.G4.E3.G3.E2.F2.Build();

            // arrange
            var moves = s.GetDiscoveredDiagonalAttackMoves("C3", Bitboard.Empty);

            // assert
            moves.Should().Have.SameSequenceAs(
                new Move("G7", "G6"),
                new Move("G7", "G5")
                );
        }

        [Test]
        public void GetDiscoveredDiagonalAttackMoves_BishopH8BlackPawnF6WhitePawnG5TargetInC3()
        {
            // arrange
            var s = new Side("G8",
                new PieceSet<Queen>(),
                new PieceSet<Bishop>(Bitboard.With.H8),
                new PieceSet<Knight>(),
                new PieceSet<Rook>(),
                new BlackPawns(new Square("F6").AsBoard)
                );

            //var expected = Bitboard.With.F4.G4.E3.G3.E2.F2.Build();

            // arrange
            var moves = s.GetDiscoveredDiagonalAttackMoves("C3", Bitboard.With.G5.Build());

            // assert
            moves.Should().Have.SameSequenceAs(
                new Move("F6", "F5"),
                new Move("F6", "G5")
                );
        }
        
        [Test]
        public void GetDiscoveredStraightAttackMoves_RookE1BishopE2TargetE7_AllBishopMoves()
        {
            // arrange
            var s = new Side("A1",
                new PieceSet<Queen>(),
                new PieceSet<Bishop>(new Square("E2")),
                new PieceSet<Knight>(),
                new PieceSet<Rook>(new Square("E1")),
                new WhitePawns()
                );

            var expected = new PieceSet<Bishop>(new Square("E2")).GetMoves(Bitboard.Empty, Bitboard.Empty);

            // act
            var result = s.GetDiscoverdStraightAttackMoves(new Square("E7"), Bitboard.Empty);

            // assert
            result.Should().Have.SameSequenceAs(expected);
        }

        [Test]
        public void GetDiscoveredStraightAttackMoves_RookE1KnightE2TargetE7_AllKnightMoves()
        {
            // arrange
            var s = new Side("A1",
                new PieceSet<Queen>(),
                new PieceSet<Bishop>(),
                new PieceSet<Knight>(new Square("E2")),
                new PieceSet<Rook>(new Square("E1")),
                new WhitePawns()
                );

            var expected = new PieceSet<Knight>(new Square("E2")).GetMoves(Bitboard.Empty, Bitboard.Empty);

            // act
            var result = s.GetDiscoverdStraightAttackMoves(new Square("E7"), Bitboard.Empty);

            // assert
            result.Should().Have.SameSequenceAs(expected);
        }

        [Test]
        public void GetDiscoveredStraightAttackMoves_RookE1KingE3TargetE7()
        {
            // arrange
            var s = new Side("E3",
                new PieceSet<Queen>(),
                new PieceSet<Bishop>(),
                new PieceSet<Knight>(),
                new PieceSet<Rook>(new Square("E1")),
                new WhitePawns()
                );

            var expected = new PieceSet<King>(new Square("E3")).GetMoves(Bitboard.Empty, Bitboard.Empty, Bitboard.Full, ~Bitboard.With.FileE.Build());

            // act
            var result = s.GetDiscoverdStraightAttackMoves(new Square("E7"), Bitboard.Empty);

            // assert
            result.Should().Have.SameSequenceAs(expected);
        }

        [Test]
        public void GetDiscoveredStraightAttackMoves_RookE1PawnE3TargetE7_ReturnsEmpty()
        {
            // arrange
            var s = new Side("G1",
                new PieceSet<Queen>(),
                new PieceSet<Bishop>(),
                new PieceSet<Knight>(),
                new PieceSet<Rook>(new Square("E1")),
                new WhitePawns(Bitboard.With.A3.Build())
                );

            // act
            var result = s.GetDiscoverdStraightAttackMoves(new Square("E7"), Bitboard.Empty);

            // assert
            result.Count().Should().Be(0);
        }

        [Test]
        public void GetDiscoveredStraightAttackMoves_RookE1PawnE3EnemyD4TargetE7_ReturnsE3D4()
        {
            // arrange
            var s = new Side("G1",
                new PieceSet<Queen>(),
                new PieceSet<Bishop>(),
                new PieceSet<Knight>(),
                new PieceSet<Rook>(new Square("E1")),
                new WhitePawns(Bitboard.With.Rank2.E3.Except.E2.Build())
                );

            // act
            var result = s.GetDiscoverdStraightAttackMoves(new Square("E7"), new Square("D4").AsBoard);

            // assert
            result.Should().Have.SameSequenceAs(
                new Move("E3", "D4")
                );
        }

        [Test]
        public void GetDiscoveredStraightAttackMoves_RookA4PawnB4TargetE4_ReturnsB4B5()
        {
            // arrange
            var s = new Side("G1",
                new PieceSet<Queen>(),
                new PieceSet<Bishop>(),
                new PieceSet<Knight>(),
                new PieceSet<Rook>(new Square("A4")),
                new WhitePawns(Bitboard.With.Rank2.B4.Except.B2.Build())
                );

            // act
            var result = s.GetDiscoverdStraightAttackMoves(new Square("E4"), Bitboard.Empty);

            // assert
            result.Should().Have.SameSequenceAs(
                new Move("B4", "B5")
                );

        }

        [Test]
        public void GetDirectAttackMoves_WhitePawnsD4G4G2EnemyF5TargetE6()
        {
            // arrange
            var s = new Side("G1",
                new PieceSet<Queen>(),
                new PieceSet<Bishop>(),
                new PieceSet<Knight>(),
                new PieceSet<Rook>(),
                new WhitePawns(Bitboard.With.D4.G4)
                );

            var enemy = new Square("F5").AsBoard;

            // act
            var result = s.GetDirectAttackMoves("E6", enemy);

            // assert
            result.Should().Have.SameSequenceAs(
                new Move("G4", "F5"),
                new Move("D4", "D5")
                );
        }
    }
}
