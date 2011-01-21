using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;
using SharpTestsEx;

namespace StrongChess.Model.Tests.Units
{
    [TestFixture]
    public class SquaresNWTests
    {
        [Test]
        public void Ctor_E4_ReturnsD5C6B7A8()
        {
            // arrange
            var s = new SquaresNW("E4");
            var expected = Bitboard.With.D5.C6.B7.A8.Build();

            // act 

            // assert
            s.AsBoard.Should().Be(expected);
        }

        [Test]
        public void Ctor_H1_ReturnsG2F3E4D5C6B7A8()
        {
            // arrange
            var s = new SquaresNW("H1");
            var expected = Bitboard.With.G2.F3.E4.D5.C6.B7.A8.Build();

            // act 

            // assert
            s.AsBoard.Should().Be(expected);
        }

        [Test]
        public void Ctor_A8_ReturnsEmpty()
        {
            // arrange
            var s = new SquaresNW("A8");
            var expected = Bitboard.Empty;

            // act 

            // assert
            s.AsBoard.Should().Be(expected);
        }
    }
}
