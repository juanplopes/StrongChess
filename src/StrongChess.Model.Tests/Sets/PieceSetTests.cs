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

            // act 
            var result = knights.GetMoves(friends, Bitboard.With.D1, true);

            // assert
            result.Should().Have.SameSequenceAs(
                new Move("C3", "D1")
                );
        }

        [Test]
        public void GetMoveBoard_KnightsInB1C3EnemyInD1OnlyCaptures_ReturnsMoveFromC3ToD1()
        {
            // arrange
            var friends = Bitboard.With.B1.C3;
            PieceSet<Knight> knights = new PieceSet<Knight>(
                friends
                );

            // act 
            var result = knights.GetMoveBoard(friends, Bitboard.With.D1, true);

            // assert
            result.Should().Be(Bitboard.With.D1.Build());
        }

        [Test]
        public void GetDirectAttackMoves_RookInA1ToAttackF6()
        {
            // arrange 
            PieceSet<Rook> rooks = new PieceSet<Rook>(
                Bitboard.With.A1
                );

            var target = new Square("F6");

            // act
            var moves = rooks.GetDirectAttackMoves(target, Bitboard.Empty, target.AsBoard);

            // assert
            moves.Should().Have.SameSequenceAs(
                new Move("A1", "F1"),
                new Move("A1", "A6")
                );
        }

        [Test]
        public void GetDirectAttackMoves_QueenInA2ToAttackF6()
        {
            // arrange 
            PieceSet<Queen> queens = new PieceSet<Queen>(
                Bitboard.With.A2
                );

            var target = new Square("F6");

            // act
            var moves = queens.GetDirectAttackMoves(target, Bitboard.Empty, target.AsBoard);

            // assert
            moves.Should().Have.SameSequenceAs(
                new Move("A2", "A1"),
                new Move("A2", "B2"),
                new Move("A2", "F2"),
                new Move("A2", "A6"),
                new Move("A2", "E6"),
                new Move("A2", "F7")
                );
        }


        [Test]
        public void GetDirectAttackMoves_KnightsInB1AndH7ToAttackE4()
        {
            // arrange 
            PieceSet<Knight> knights = new PieceSet<Knight>(
                Bitboard.With.B1.H7
                );

            var target = new Square("E4");

            // act
            var moves = knights.GetDirectAttackMoves(target, Bitboard.Empty, target.AsBoard);

            // assert
            moves.Should().Have.SameSequenceAs(
                new Move("B1", "D2"),
                new Move("B1", "C3"),
                new Move("H7", "G5"),
                new Move("H7", "F6")
                );
        }

        [Test]
        public void GetDirectAttackMoves_BishopInC4AttacksG4()
        {
            // arrange
            PieceSet<Bishop> bishops = new PieceSet<Bishop>(
                Bitboard.With.C4
                );

            var target = new Square("G4");

            // act
            var moves = bishops.GetDirectAttackMoves(target, Bitboard.Empty, target.AsBoard);


            // assert
            moves.Should().Have.SameSequenceAs(
                new Move("C4", "E2" ),
                new Move("C4", "E6")
                );
        }

    }
}
