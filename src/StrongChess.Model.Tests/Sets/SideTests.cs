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
    }
}
