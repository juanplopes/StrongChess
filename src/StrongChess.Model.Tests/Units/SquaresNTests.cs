using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;
using SharpTestsEx;

namespace StrongChess.Model.Tests.Units
{
    [TestFixture]
    public class SquaresNTests
    {
        [Test]
        public void Ctor_E4_ReturnsE5E6E7E8()
        {
            // arrange
            var s = new SquaresN("E4");
            var expected = Bitboard.With.E5.E6.E7.E8.Build();

            // act 

            // assert
            s.AsBoard.Should().Be(expected);
        }

        [Test]
        public void Ctor_A8_ReturnsEmpty()
        {
            // arrange
            var s = new SquaresN("A8");
            var expected = Bitboard.Empty;

            // act 

            // assert
            s.AsBoard.Should().Be(expected);
        }
    }
}
