using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrongChess.Model.Tests
{
    using NUnit.Framework;
    using SharpTestsEx;
    using StrongChess.Model.Sets;
    using StrongChess.Model.Exceptions;

    [TestFixture]
    public class BoardTests
    {
        [Test]
        public void NewGame_WhiteInInitialPosition()
        {
            // arrange
            var b = Board.NewGame();
            //act
            // assert
            b.White.Should().Be(Side.WhiteInitialPosition);
        }

        [Test]
        public void NewGame_BlackInInitialPosition()
        {
            // arrange
            var b = Board.NewGame();
            //act
            // assert
            b.Black.Should().Be(Side.BlackInitialPosition);
        }

        [Test]
        public void NewGame_IsWhiteToMove_ReturnsTrue()
        {
            // arrange
            var b = Board.NewGame();
            //act
            // assert
            b.IsWhiteToMove.Should().Be(true);
        }

        [Test]
        public void NewGame_NoPawnMovesCount_Returns0()
        {
            // arrange
            var b = Board.NewGame();
            //act
            // assert
            b.NoPawnMovesCount.Should().Be(0);
        }

        [Test]
        public void MakeMove_InitialPositionE2E4()
        {
            // arrange
            var board = Board.NewGame();

            // act
            var result = board.MakeMove(new Move("E2", "E4"));

            // assert
            result.White.Pawns.Locations.Should().Be(
                Bitboard.With.A2.B2.C2.D2.E4.F2.G2.H2
                    .Build()
                );
        }

        [Test]
        public void MakeMove_InitialPositionE2E4_EnpassantShouldBeE3()
        {
            // arrange
            var board = Board.NewGame();
            Square enpassant = new Square("E3");
            // act
            var result = board.MakeMove(new Move("E2", "E4"));

            // assert
            result.Enpassant.Value.Should().Be(enpassant);
            //Assert.Fail(result.Enpassant.ToString());
        }

        [Test]
        public void MakeMove_InitialPositionE2E4AndE7E5_EnpassantShouldBeE6()
        {
            // arrange
            var board = Board.NewGame();
            Square enpassant = new Square("E6");
            // act
            var result = board
                .MakeMove(new Move("E2", "E4"))
                .MakeMove(new Move("E7", "E5"));

            // assert
            result.Enpassant.Value.Should().Be(enpassant);
            //Assert.Fail(result.Enpassant.ToString());
        }

        [Test]
        public void MakeMove_InitialPositionE2E4AndE7E6_EnpassantShouldBeNull()
        {
            // arrange
            var board = Board.NewGame();
            // act
            var result = board
                .MakeMove(new Move("E2", "E4"))
                .MakeMove(new Move("E7", "E6"));

            // assert
            Assert.IsTrue(result.Enpassant == null);
            //Assert.Fail(result.Enpassant.ToString());
        }

        [Test]
        public void MakeMove_InitialPositionE2E4AndD7D5_E4D5ShouldBePossible()
        {
            // arrange
            var board = Board.NewGame();
            Move m = new Move("E4", "D5");
            // act
            var result = board
                .MakeMove(new Move("E2", "E4"))
                .MakeMove(new Move("D7", "D5"));


            var c = result.White.Pawns.GetAllMoves(~result.Occupation,
                result.Black.Occupation, "D6")
                .Where(move => move.From == m.From && move.To == m.To);

            c.Count().Should().Be(1);
        }

        [Test]
        public void MakeMove_InitialPositionE2E4AndD7D5AndE4D5_WhitePawnOccupiesD5()
        {
            // arrange
            var board = Board.NewGame();
            Square s = "D5";
            // act
            var result = board
                .MakeMove(new Move("E2", "E4"))
                .MakeMove(new Move("D7", "D5"))
                .MakeMove(new Move("E4", "D5"));

            // assert
            result.White.Pawns.Locations.Contains(s).Should().Be(true);
        }

        [Test]
        public void MakeMove_InitialPositionE2E4AndD7D5AndE4D5_BlackPawnLeavesTheBoard()
        {
            // arrange
            var board = Board.NewGame();
            
            // act
            var result = board
                .MakeMove(new Move("E2", "E4"))
                .MakeMove(new Move("D7", "D5"))
                .MakeMove(new Move("E4", "D5"));

            // assert
            result.Black.Pawns.Locations.Should().Be(
                Bitboard.With.H7.G7.F7.E7.C7.B7.A7.Build());
        }

        [Test]
        public void MakeMove_InitialPositionE2E4AndD7D5AndE4D5AndF7F5AndE5F6_BlackPawnLeavesTheBoard()
        {
            // arrange
            var board = Board.NewGame();

            // act
            var result = board
                .MakeMove(new Move("E2", "E4"))
                .MakeMove(new Move("D7", "D5"))
                .MakeMove(new Move("E4", "E5"))
                .MakeMove(new Move("F7", "F5"))
                .MakeMove(new Move("E5", "F6"));


            // assert
            result.Black.Pawns.Locations.Should().Be(
                Bitboard.With.H7.G7.E7.D5.C7.B7.A7.Build());
        }

        [Test]
        public void MakeMove_InitialPositionE2E4_IsWhiteToMoveShouldBeFalse()
        {
            // arrange
            var board = Board.NewGame();

            // act
            var result = board.MakeMove(new Move("E2", "E4"));

            // assert
            result.IsWhiteToMove.Should().Be(false);
        }

        [Test]
        public void MakeMove_InitialPositionE2E5_ShouldThrowInvalidMoveException()
        {
            // arrange
            var board = Board.NewGame();
            var move = new Move("E2", "E5");
            // act
            board.Executing((b) => b.MakeMove(move))
                .Throws<InvalidMoveException>();
        }

        
        [Test]
        public void Occupation_InitialPostion_ReturnsBlackAndWhiteOccupation()
        {
            // arrange
            var b = Board.NewGame();
            // act

            // assert
            b.Occupation.Should().Be((Bitboard) (b.White.Occupation | b.Black.Occupation));
        }


    }
}
