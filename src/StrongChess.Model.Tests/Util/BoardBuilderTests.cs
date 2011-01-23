using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SharpTestsEx;

namespace StrongChess.Model.Tests.Util
{
    [TestFixture]
    public class BoardBuilderTests
    {
        [Test]
        public void ConstructingEmptyBoard()
        {
            var board = Bitboard.With.Build();
            board.Squares.Should().Be.Empty();
        }

        [Test]
        public void ConstructingBoardWithDiagonalA1H8()
        {
            var board = Bitboard.With.DiagonalA1H8.Build();
            board.Should().Be(new Square("B2").DiagonalNE.AsBoard);
        }


        [Test]
        public void ConstructingBoardWithDiagonalB1H7()
        {
            var board = Bitboard.With.DiagonalB1H7.Build();
            board.Should().Be(new Square("C2").DiagonalNE.AsBoard);
        }

        [Test]
        public void ConstructingBoardWithDiagonalA2G8()
        {
            var board = Bitboard.With.DiagonalA2G8.Build();
            board.Should().Be(new Square("B3").DiagonalNE.AsBoard);
        }

        [Test]
        public void ConstructingBoardWithDiagonalG1A7()
        {
            var board = Bitboard.With.DiagonalG1A7.Build();
            board.Should().Be(new Square("E3").DiagonalNW.AsBoard);
        }

        [Test]
        public void ConstructingBoardWithDiagonalH2B8()
        {
            var board = Bitboard.With.DiagonalH2B8.Build();
            board.Should().Be(new Square("G3").DiagonalNW.AsBoard);
        }

        [Test]
        public void ConstructingBoardWithDiagonalH1A8()
        {
            var board = Bitboard.With.DiagonalH1A8.Build();
            board.Should().Be(new Square("G2").DiagonalNW.AsBoard);
        }

        [Test]
        public void ConstructingBoardWithA1()
        {
            var board = Bitboard.With.A1.Build();
            board.Squares.Should().Have.SameSequenceAs("A1");
        }

        [Test]
        public void ConstructingBoardWithA1AndA2()
        {
            var board = Bitboard.With.A1.A2.Build();
            board.Squares.Should().Have.SameSequenceAs("A1", "A2");
        }

        [Test]
        public void ConstructingBoardWithA1AndFileH()
        {
            var board = Bitboard.With.A1.FileH.Build();
            board.Squares.Should().Have.SameSequenceAs(
                "A1", "H1", "H2", "H3", "H4", "H5", "H6", "H7", "H8");
        }

        [Test]
        public void ConstructingBoardWithA5AndRank5()
        {
            var board = Bitboard.With.A5.Rank5.Build();
            board.Squares.Should().Have.SameSequenceAs(
                "A5", "B5", "C5", "D5", "E5", "F5", "G5", "H5");
        }

        [Test]
        public void ConstructingBoardWithA5AndRank5ExceptF5()
        {
            var board = Bitboard.With.A5.Rank5.Except.F5.Build();
            board.Squares.Should().Have.SameSequenceAs(
                "A5", "B5", "C5", "D5", "E5", "G5", "H5");
        }


        [Test]
        public void ConstructingBoardWithA5AndRank5ExceptF5ExceptD8ExceptH5()
        {
            var board = Bitboard.With.A5.Rank5.Except.F5.Except.D8.Except.H5.Build();
            board.Squares.Should().Have.SameSequenceAs(
                "A5", "B5", "C5", "D5", "E5", "G5", "D8");
        }
    }
}
