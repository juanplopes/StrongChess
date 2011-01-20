using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

using NUnit.Framework;
using SharpTestsEx;

using StrongChess.Model.Sets;
using StrongChess.Model.Pieces;



namespace StrongChess.Model.Tests.Sets
{
    [TestFixture]
    public class PieceSetTests
    {
        [Test]
        public void GetMoveBoard_KnightsInB1C3_ReturnsA3D2A2A4B5D5E4E2D1()
        {
            // arrange
            var friends = Bitboard.With.B1.C3;
            PieceSet<Knight> knights = new PieceSet<Knight>(
                friends
                );
            Bitboard expected = Bitboard.With.A3.D2.A2.A4.B5.D5.E4.E2.D1;

            // act 
            var result = knights.GetMoveBoard(friends, Bitboard.Empty);

            // assert
            result.Should().Be(expected);
        }

        [Test]
        public void GetMoves_KnightsInB1C3()
        {
            // arrange
            var friends = Bitboard.With.B1.C3;
            PieceSet<Knight> knights = new PieceSet<Knight>(
                friends
                );
            Bitboard expected = Bitboard.With.A3.D2.A2.A4.B5.D5.E4.E2.D1;

            // act 
            var result = knights.GetMoves(friends, Bitboard.Empty);

            // assert
            result.Should().Have.SameSequenceAs(
                new Move("B1", "D2"),
                new Move("B1", "A3"),
                new Move("C3", "D1"),
                new Move("C3", "A2"),
                new Move("C3", "E2"),
                new Move("C3", "A4"),
                new Move("C3", "E4"),
                new Move("C3", "B5"),
                new Move("C3", "D5")
                );
            //result.Should().Be(expected);
        }

        [Test]
        public void GetMoves_KnightsInB1C3NoEnemiesOnlyCaptures_ReturnsNothing()
        {
            // arrange
            var friends = Bitboard.With.B1.C3;
            PieceSet<Knight> knights = new PieceSet<Knight>(
                friends
                );
            Bitboard expected = Bitboard.With.A3.D2.A2.A4.B5.D5.E4.E2.D1;

            // act 
            var result = knights.GetMoves(friends, Bitboard.Empty, true);

            // assert
            result.Count().Should().Be(0);
        }

        [Test]
        public void GetMoves_KnightsInB1C3EnemyInD1OnlyCaptures_ReturnsMoveFromC3ToD1()
        {
            // arrange
            var friends = Bitboard.With.B1.C3;
            PieceSet<Knight> knights = new PieceSet<Knight>(
                friends
                );
            Bitboard expected = Bitboard.With.A3.D2.A2.A4.B5.D5.E4.E2.D1;

            // act 
            var result = knights.GetMoves(friends, Bitboard.With.D1, true);

            // assert
            result.Should().Have.SameSequenceAs(
                new Move("C3", "D1")
                );
        }
    }
}
