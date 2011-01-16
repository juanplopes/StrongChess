using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using StrongChess.Model.Sets;
using SharpTestsEx;

namespace StrongChess.Model.Tests.Pieces
{
    [TestFixture]
    public class WhitePawnsTests
    {
        [Test]
        public void IsValid_PawnsInRank1_ReturnsFalse()
        {
            var p = new WhitePawns(new Bitboard().Set(new Square("A1")));
            p.IsValid.Should().Be(false);
        }

        [Test]
        public void IsValid_PawnsInRank8_ReturnsFalse()
        {
            var p = new WhitePawns(new Bitboard().Set(new Square("A8")));
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

            var p = new WhitePawns(pawns);
            p.IsValid.Should().Be(false);
        }

        [Test]
        public void IsValid_InitialPosition_ReturnsTrue()
        {
            var p = WhitePawns.InitialPosition;
            p.IsValid.Should().Be(true);
        }


        [Test]
        public void InitialPosition()
        {
            var wp = WhitePawns.InitialPosition;

            Bitboard expected = new Bitboard()
                .Set(new Square("A2"))
                .Set(new Square("B2"))
                .Set(new Square("C2"))
                .Set(new Square("D2"))
                .Set(new Square("E2"))
                .Set(new Square("F2"))
                .Set(new Square("G2"))
                .Set(new Square("H2"));

            wp.Bitboard.Should().Be(expected);
        }

        [Test]
        public void GetMovesTwoSquareForward_B2_ReturnsNormalB2B4()
        {
            var wp = new WhitePawns(new Bitboard().Set(new Square("B2")));
            var moves = wp.GetMovesTwoSquaresForward();
            moves.Count().Should().Be(1);
            var m = moves.First();
            m.From.Should().Be(new Square("B2"));
            m.To.Should().Be(new Square("B4"));
            m.Type.Should().Be(MoveTypes.Normal);
        }

        [Test]
        public void GetMovesTwoSquareForward_B2C5_ReturnsNormalB2B4()
        {
            var wp = new WhitePawns(new Bitboard()
                .Set(new Square("B2"))
                .Set(new Square("C5"))
                );
            var moves = wp.GetMovesTwoSquaresForward();
            moves.Count().Should().Be(1);
            var m = moves.First();
            m.From.Should().Be(new Square("B2"));
            m.To.Should().Be(new Square("B4"));
            m.Type.Should().Be(MoveTypes.Normal);
        }

        [Test]
        public void GetMovesTwoSquareForward_B2BlockedInB3_ReturnsNothing()
        {
            var wp = new WhitePawns(new Bitboard().Set(new Square("B2")));
            var blockers = new Bitboard().Set(new Square("B3"));
            var notblockers = ~(blockers);
            var moves = wp.GetMovesTwoSquaresForward(notblockers);
            moves.Count().Should().Be(0);
        }

        [Test]
        public void GetMovesTwoSquareForward_B2BlockedInB4_ReturnsNothing()
        {
            var wp = new WhitePawns(new Bitboard().Set(new Square("B2")));
            var blockers = new Bitboard().Set(new Square("B4"));
            var notblockers = ~(blockers);
            var moves = wp.GetMovesTwoSquaresForward(notblockers);
            moves.Count().Should().Be(0);
        }

        [Test]
        public void GetMovesTwoSquareForward_B3_ReturnsNothing()
        {
            var wp = new WhitePawns(new Bitboard().Set(new Square("B3")));
            var moves = wp.GetMovesTwoSquaresForward();
            moves.Count().Should().Be(0);
        }


        [Test]
        public void GetMovesOneSquareForward_B4_ReturnsNormalB4B5()
        {
            var wp = new WhitePawns(new Bitboard().Set(new Square("B4")));
            var move = wp.GetMovesOneSquareForward().First();
            move.From.Should().Be(new Square("B4"));
            move.To.Should().Be(new Square("B5"));
            move.Type.Should().Be(MoveTypes.Normal);
        }

        [Test]
        public void GetMovesOneSquareForward_BlockedB4_ReturnsNoMoves()
        {
            var wp = new WhitePawns(~(new Bitboard().Set(new Square("B4"))));
            var moves = wp.GetMovesOneSquareForward(new Bitboard().Set(new Square("B5")));
            moves.Count().Should().Be(0);
        }

        [Test]
        public void GetMovesOneSquareForward_A7_ReturnsPromotions()
        {
            var wp = new WhitePawns(new Bitboard().Set(new Square("A7")));
            var m = wp.GetMovesOneSquareForward();
            var moves = m.GetEnumerator();


            moves.MoveNext();
            var f1 = moves.Current;
            f1.From.Should().Be(new Square("A7"));
            f1.To.Should().Be(new Square("A8"));
            f1.Type.Should().Be(MoveTypes.PawnToQueenPromotion);

            moves.MoveNext();
            var f2 = moves.Current;
            f2.From.Should().Be(new Square("A7"));
            f2.To.Should().Be(new Square("A8"));
            f2.Type.Should().Be(MoveTypes.PawnToRookPromotion);

            moves.MoveNext();
            var f3 = moves.Current;
            f3.From.Should().Be(new Square("A7"));
            f3.To.Should().Be(new Square("A8"));
            f3.Type.Should().Be(MoveTypes.PawnToBishopPromotion);

            moves.MoveNext();
            var f4 = moves.Current;
            f4.From.Should().Be(new Square("A7"));
            f4.To.Should().Be(new Square("A8"));
            f4.Type.Should().Be(MoveTypes.PawnToKnightPromotion);

            m.Count().Should().Be(4);
        }

        [Test]
        public void GetCaptures_D4EnemiesD5C5_ReturnsNormalD4C5()
        {
            var wp = new WhitePawns(
                new Bitboard().Set(new Square("D4"))
                );

            var enemies = new Bitboard()
                .Set(new Square("C5"))
                .Set(new Square("D5"));

            var moves = wp.GetCaptures(enemies);
            moves.Count().Should().Be(1);
            var move = moves.First();
            move.From.Should().Be(new Square("D4"));
            move.To.Should().Be(new Square("C5"));
            move.Type.Should().Be(MoveTypes.Normal);
        }

        [Test]
        public void GetCaptures_D4EnemiesD5E5_ReturnsNormalD4E5()
        {
            var wp = new WhitePawns(
                new Bitboard().Set(new Square("D4"))
                );

            var enemies = new Bitboard()
                .Set(new Square("E5"))
                .Set(new Square("D5"));

            var moves = wp.GetCaptures(enemies);
            moves.Count().Should().Be(1);
            var move = moves.First();
            move.From.Should().Be(new Square("D4"));
            move.To.Should().Be(new Square("E5"));
            move.Type.Should().Be(MoveTypes.Normal);
        }

        [Test]
        public void GetCaptures_A4EnemiesB5_ReturnsNormalA4B5()
        {
            var wp = new WhitePawns(
                new Bitboard().Set(new Square("A4"))
                );

            var enemies = new Bitboard()
                .Set(new Square("B5"));

            var moves = wp.GetCaptures(enemies);
            moves.Count().Should().Be(1);
            var move = moves.First();
            move.From.Should().Be(new Square("A4"));
            move.To.Should().Be(new Square("B5"));
            move.Type.Should().Be(MoveTypes.Normal);
        }

        [Test]
        public void GetCaptures_H4EnemiesG5_ReturnsNormalH4G5()
        {
            var wp = new WhitePawns(
                new Bitboard().Set(new Square("H4"))
                );

            var enemies = new Bitboard()
                .Set(new Square("G5"));

            var moves = wp.GetCaptures(enemies);
            moves.Count().Should().Be(1);
            var move = moves.First();
            move.From.Should().Be(new Square("H4"));
            move.To.Should().Be(new Square("G5"));
            move.Type.Should().Be(MoveTypes.Normal);
        }
    }
}
