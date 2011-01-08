using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SharpTestsEx;
using StrongChess.Model.Sets;

namespace StrongChess.Model.Tests
{
    [TestFixture]
    class BlackPawnsTests
    {
        [Test]
        public void IsValid_PawnsInRank1_ReturnsFalse()
        {
            var p = new BlackPawns(new Bitboard().Set(new Square("A1")));
            p.IsValid.Should().Be(false);
        }

        [Test]
        public void IsValid_PawnsInRank8_ReturnsFalse()
        {
            var p = new BlackPawns(new Bitboard().Set(new Square("A8")));
            p.IsValid.Should().Be(false);
        }

        [Test]
        public void IsValid_MoreThan8Pawns_ReturnsFalse()
        {
            Bitboard pawns = new Bitboard()
                .Set(new Square("A3"))
                .Set(new Square("B4"))
                .Set(new Square("C5"))
                .Set(new Square("D7"))
                .Set(new Square("E3"))
                .Set(new Square("G3"))
                .Set(new Square("F4"))
                .Set(new Square("H7"))
                .Set(new Square("H2"));

            var p = new BlackPawns(pawns);
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

            Bitboard expected = new Bitboard()
                .Set(new Square("A7"))
                .Set(new Square("B7"))
                .Set(new Square("C7"))
                .Set(new Square("D7"))
                .Set(new Square("E7"))
                .Set(new Square("F7"))
                .Set(new Square("G7"))
                .Set(new Square("H7"));

            bp.Bitboard.Should().Be(expected);
        }

        // ------------------------

        [Test]
        public void GetMovesTwoSquareForward_B7_ReturnsNormalB7B5()
        {
            var bp = new BlackPawns(new Bitboard().Set(new Square("B7")));
            var moves = bp.GetMovesTwoSquaresForward();
            moves.Count().Should().Be(1);
            var m = moves.First();
            m.From.Should().Be(new Square("B7"));
            m.To.Should().Be(new Square("B5"));
            m.Type.Should().Be(MoveTypes.Normal);
        }

        [Test]
        public void GetMovesTwoSquareForward_B7C4_ReturnsNormalB7B5()
        {
            var bp = new BlackPawns(new Bitboard()
                .Set(new Square("B7"))
                .Set(new Square("C4"))
                );
            var moves = bp.GetMovesTwoSquaresForward();
            moves.Count().Should().Be(1);
            var m = moves.First();
            m.From.Should().Be(new Square("B7"));
            m.To.Should().Be(new Square("B5"));
            m.Type.Should().Be(MoveTypes.Normal);
        }

        [Test]
        public void GetMovesTwoSquareForward_B7BlockedInB6_ReturnsNothing()
        {
            var bp = new BlackPawns(new Bitboard().Set(new Square("B7")));
            var blockers = new Bitboard().Set(new Square("B6"));
            var notblockers = ~(blockers);
            var moves = bp.GetMovesTwoSquaresForward(notblockers);
            moves.Count().Should().Be(0);
        }

        [Test]
        public void GetMovesTwoSquareForward_B7BlockedInB5_ReturnsNothing()
        {
            var bp = new BlackPawns(new Bitboard().Set(new Square("B7")));
            var blockers = new Bitboard().Set(new Square("B5"));
            var notblockers = ~(blockers);
            var moves = bp.GetMovesTwoSquaresForward(notblockers);
            moves.Count().Should().Be(0);
        }

        [Test]
        public void GetMovesTwoSquareForward_B6_ReturnsNothing()
        {
            var bp = new BlackPawns(new Bitboard().Set(new Square("B6")));
            var moves = bp.GetMovesTwoSquaresForward();
            moves.Count().Should().Be(0);
        }


        [Test]
        public void GetMovesOneSquareForward_B5_ReturnsNormalB5B4()
        {
            var bp = new BlackPawns(new Bitboard().Set(new Square("B5")));
            var move = bp.GetMovesOneSquareForward().First();
            move.From.Should().Be(new Square("B5"));
            move.To.Should().Be(new Square("B4"));
            move.Type.Should().Be(MoveTypes.Normal);
        }



        [Test]
        public void GetMovesOneSquareForward_BlockedB5_ReturnsNoMoves()
        {
            var bp = new BlackPawns(~(new Bitboard().Set(new Square("B5"))));
            var moves = bp.GetMovesOneSquareForward(new Bitboard().Set(new Square("B4")));
            moves.Count().Should().Be(0);
        }


        [Test]
        public void GetMovesOneSquareForward_A2_ReturnsPromotions()
        {
            var bp = new BlackPawns(new Bitboard().Set(new Square("A2")));
            var m = bp.GetMovesOneSquareForward();
            var moves = m.GetEnumerator();


            moves.MoveNext();
            var f1 = moves.Current;
            f1.From.Should().Be(new Square("A2"));
            f1.To.Should().Be(new Square("A1"));
            f1.Type.Should().Be(MoveTypes.PawnToQueenPromotion);

            moves.MoveNext();
            var f2 = moves.Current;
            f2.From.Should().Be(new Square("A2"));
            f2.To.Should().Be(new Square("A1"));
            f2.Type.Should().Be(MoveTypes.PawnToRookPromotion);

            moves.MoveNext();
            var f3 = moves.Current;
            f3.From.Should().Be(new Square("A2"));
            f3.To.Should().Be(new Square("A1"));
            f3.Type.Should().Be(MoveTypes.PawnToBishopPromotion);

            moves.MoveNext();
            var f4 = moves.Current;
            f4.From.Should().Be(new Square("A2"));
            f4.To.Should().Be(new Square("A1"));
            f4.Type.Should().Be(MoveTypes.PawnToKnightPromotion);

            m.Count().Should().Be(4);
        }

        [Test]
        public void GetCaptures_D5EnemiesD4C4_ReturnsNormalD5C4()
        {
            var bp = new BlackPawns(
                new Bitboard().Set(new Square("D5"))
                );

            var enemies = new Bitboard()
                .Set(new Square("C4"))
                .Set(new Square("D4"));

            var moves = bp.GetCaptures(enemies);
            moves.Count().Should().Be(1);
            var move = moves.First();
            move.From.Should().Be(new Square("D5"));
            move.To.Should().Be(new Square("C4"));
            move.Type.Should().Be(MoveTypes.Normal);
        }

        [Test]
        public void GetCaptures_D5EnemiesD4E4_ReturnsNormalD5E4()
        {
            var bp = new BlackPawns(
                new Bitboard().Set(new Square("D5"))
                );

            var enemies = new Bitboard()
                .Set(new Square("E4"))
                .Set(new Square("D4"));

            var moves = bp.GetCaptures(enemies);
            moves.Count().Should().Be(1);
            var move = moves.First();
            move.From.Should().Be(new Square("D5"));
            move.To.Should().Be(new Square("E4"));
            move.Type.Should().Be(MoveTypes.Normal);
        }

        [Test]
        public void GetCaptures_A5EnemiesB4_ReturnsNormalA5B4()
        {
            var bp = new BlackPawns(
                new Bitboard().Set(new Square("A5"))
                );

            var enemies = new Bitboard()
                .Set(new Square("B4"));

            var moves = bp.GetCaptures(enemies);
            moves.Count().Should().Be(1);
            var move = moves.First();
            move.From.Should().Be(new Square("A5"));
            move.To.Should().Be(new Square("B4"));
            move.Type.Should().Be(MoveTypes.Normal);
        }

        [Test]
        public void GetCaptures_H5EnemiesG4_ReturnsNormalH5G4()
        {
            var bp = new BlackPawns(
                new Bitboard().Set(new Square("H5"))
                );

            var enemies = new Bitboard()
                .Set(new Square("G4"));

            var moves = bp.GetCaptures(enemies);
            moves.Count().Should().Be(1);
            var move = moves.First();
            move.From.Should().Be(new Square("H5"));
            move.To.Should().Be(new Square("G4"));
            move.Type.Should().Be(MoveTypes.Normal);
        }
    }
}
