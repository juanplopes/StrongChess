using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SharpTestsEx;

namespace StrongChess.Model.Tests
{
    [TestFixture]
    public class BoardBuilderTests
    {
        [Test]
        public void ConstructingEmptyBoard()
        {
            var board = Bitboard.With.Build();
            board.GetSetSquares().Should().Be.Empty();
        }

        [Test]
        public void ConstructingBoardWithA1()
        {
            var board = Bitboard.With.A1.Build();
            board.GetSetSquares().Should().Have.SameSequenceAs("A1");
        }

        [Test]
        public void ConstructingBoardWithA1AndA2()
        {
            var board = Bitboard.With.A1.A2.Build();
            board.GetSetSquares().Should().Have.SameSequenceAs("A1", "A2");
        }

        [Test]
        public void ConstructingBoardWithA1AndFileH()
        {
            var board = Bitboard.With.A1.FileH.Build();
            board.GetSetSquares().Should().Have.SameSequenceAs(
                "A1", "H1", "H2", "H3", "H4", "H5", "H6", "H7", "H8");
        }

        [Test]
        public void ConstructingBoardWithA5AndRank5()
        {
            var board = Bitboard.With.A5.Rank5.Build();
            board.GetSetSquares().Should().Have.SameSequenceAs(
                "A5", "B5", "C5", "D5", "E5", "F5", "G5", "H5");
        }

        [Test]
        public void ConstructingBoardWithA5AndRank5ExceptF5()
        {
            var board = Bitboard.With.A5.Rank5.Except.F5.Build();
            board.GetSetSquares().Should().Have.SameSequenceAs(
                "A5", "B5", "C5", "D5", "E5", "G5", "H5");
        }


        [Test]
        public void ConstructingBoardWithA5AndRank5ExceptF5ExceptD8ExceptH5()
        {
            var board = Bitboard.With.A5.Rank5.Except.F5.Except.D8.Except.H5.Build();
            board.GetSetSquares().Should().Have.SameSequenceAs(
                "A5", "B5", "C5", "D5", "E5", "G5", "D8");
        }
    }
}
