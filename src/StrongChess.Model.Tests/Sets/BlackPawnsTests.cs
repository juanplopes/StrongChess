using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SharpTestsEx;
using StrongChess.Model.Sets;

namespace StrongChess.Model.Tests.Sets
{
    [TestFixture]
    class BlackPawnsTests
    {
        [Test]
        public void IsValid_PawnsInRank1_ReturnsFalse()
        {
            var p = new BlackPawns(Bitboard.With.A1);
            p.IsValid.Should().Be(false);
        }

        [Test]
        public void IsValid_PawnsInRank8_ReturnsFalse()
        {
            var p = new BlackPawns(Bitboard.With.A8);
            p.IsValid.Should().Be(false);
        }

        [Test]
        public void IsValid_MoreThan8Pawns_ReturnsFalse()
        {
            var p = new BlackPawns(
                Bitboard.With.A3.B4.C5.D7.E3.G3.F4.H7.H2.Build());
            p.IsValid.Should().Be(false);
        }

        [Test]
        public void IsValid_InitialPosition_ReturnsTrue()
        {
            var p = BlackPawns.InitialPosition;
            p.IsValid.Should().Be(true);
        }

        [Test]
        public void InitialPosition()
        {
            var bp = BlackPawns.InitialPosition;
            var expected = Bitboard.With.Rank7.Build();
            bp.Locations.Should().Be(expected);
        }

        // ------------------------

        [Test]
        public void GetMovesTwoSquareForward_B7_ReturnsNormalB7B5()
        {
            var bp = new BlackPawns(Bitboard.With.B7);
            var moves = bp.GetMovesTwoSquaresForward();
            moves.Should().Have.SameSequenceAs(new Move("B7", "B5", MoveTypes.Normal));
        }

        [Test]
        public void GetMovesTwoSquareForward_B7C4_ReturnsNormalB7B5()
        {
            var bp = new BlackPawns(Bitboard.With.B7.C4);
            var moves = bp.GetMovesTwoSquaresForward();
            moves.Should().Have.SameSequenceAs(new Move("B7", "B5", MoveTypes.Normal));
        }

        [Test]
        public void GetMovesTwoSquareForward_B7BlockedInB6_ReturnsNothing()
        {
            var bp = new BlackPawns(Bitboard.With.B7);
            var notblockers = Bitboard.With.B6.Build().Inverted;
            var moves = bp.GetMovesTwoSquaresForward(notblockers);
            moves.Should().Be.Empty();
        }

        [Test]
        public void GetMovesTwoSquareForward_B7BlockedInB5_ReturnsNothing()
        {
            var bp = new BlackPawns(Bitboard.With.B7);
            var notblockers = Bitboard.With.B5.Build().Inverted;
            var moves = bp.GetMovesTwoSquaresForward(notblockers);
            moves.Should().Be.Empty();
        }

        [Test]
        public void GetMovesTwoSquareForward_B6_ReturnsNothing()
        {
            var bp = new BlackPawns(Bitboard.With.B6);
            var moves = bp.GetMovesTwoSquaresForward();
            moves.Should().Be.Empty();
        }


        [Test]
        public void GetMovesOneSquareForward_B5_ReturnsNormalB5B4()
        {
            var bp = new BlackPawns(Bitboard.With.B5);
            var moves = bp.GetMovesOneSquareForward();
            moves.Should().Have.SameSequenceAs(
                new Move("B5", "B4", MoveTypes.Normal));
        }

        [Test]
        public void GetMoveBoard_InitialPosition_ReturnsRank6Rank5()
        {
            var bp = BlackPawns.InitialPosition;
            var expected = Bitboard.With.Rank6.Rank5.Build();

            var result = bp.GetMoveBoard(Bitboard.Full, Bitboard.Empty, null);

            result.Should().Be(expected);
        }


        [Test]
        public void GetMovesOneSquareForward_BlockedB5_ReturnsNoMoves()
        {
            var bp = new BlackPawns(Bitboard.With.B5.Build().Inverted);
            var moves = bp.GetMovesOneSquareForward(Bitboard.With.B4);
            moves.Should().Be.Empty();
        }


        [Test]
        public void GetMovesOneSquareForward_A2_ReturnsPromotions()
        {
            var bp = new BlackPawns(Bitboard.With.A2);
            var m = bp.GetMovesOneSquareForward();

            m.Should().Have.SameSequenceAs(
                new Move("A2", "A1", MoveTypes.PawnToQueenPromotion),
                new Move("A2", "A1", MoveTypes.PawnToRookPromotion),
                new Move("A2", "A1", MoveTypes.PawnToBishopPromotion),
                new Move("A2", "A1", MoveTypes.PawnToKnightPromotion));
        }

        [Test]
        public void GetCaptures_D5EnemiesD4C4_ReturnsNormalD5C4()
        {
            var bp = new BlackPawns(Bitboard.With.D5);
            var enemies = Bitboard.With.C4.D4.Build();

            bp.GetCaptures(enemies).Should().Have.SameSequenceAs(
                new Move("D5", "C4", MoveTypes.Normal));
        }

        [Test]
        public void GetCaptures_D5EnemiesD4E4_ReturnsNormalD5E4()
        {
            var bp = new BlackPawns(Bitboard.With.D5);
            var enemies = Bitboard.With.E4.D4.Build();

            bp.GetCaptures(enemies).Should().Have.SameSequenceAs(
                new Move("D5", "E4", MoveTypes.Normal));

        }

        [Test]
        public void GetCaptures_A5EnemiesB4_ReturnsNormalA5B4()
        {
            var bp = new BlackPawns(Bitboard.With.A5);
            var enemies = Bitboard.With.B4.Build();

            bp.GetCaptures(enemies).Should().Have.SameSequenceAs(
                new Move("A5", "B4", MoveTypes.Normal));
        }

        [Test]
        public void GetCaptures_H5EnemiesG4_ReturnsNormalH5G4()
        {
            var bp = new BlackPawns(Bitboard.With.H5);
            var enemies = Bitboard.With.G4.Build();

            bp.GetCaptures(enemies).Should().Have.SameSequenceAs(
                new Move("H5", "G4", MoveTypes.Normal));

        }

        [Test]
        public void GetCapturesMoveBoard_PawnsInD4E4EnemyInF3_ReturnsF3()
        {
            var pawns = Bitboard.With.D4.E4.Build();
            var enemy = Bitboard.With.F3.Build();
            var wp = new BlackPawns(pawns);

            var result = wp.GetCapturesMoveBoard(Bitboard.Full, enemy, null);

            result.Should().Be(enemy);
        }
    
    }
}