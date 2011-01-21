using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;
using SharpTestsEx;

namespace StrongChess.Model.Tests.Units
{
    [TestFixture]
    public class SquaresNETests
    {
        [Test]
        public void Ctor_E4_ReturnsF5G6H7()
        {
           // arrange
            var s = new SquaresNE("E4");
            var expected = Bitboard.With.F5.G6.H7.Build();

            // act 

            // assert
            s.AsBoard.Should().Be(expected);
        }

        [Test]
        public void Ctor_H1_ReturnsEmpty()
        {
            // arrange
            var s = new SquaresNE("H1");
            var expected = Bitboard.Empty;

            // act 

            // assert
            s.AsBoard.Should().Be(expected);
        }

        [Test]
        public void Ctor_A8_ReturnsEmpty()
        {
            // arrange
            var s = new SquaresNE("A8");
            var expected = Bitboard.Empty;

            // act 

            // assert
            s.AsBoard.Should().Be(expected);
        }
    }
}
