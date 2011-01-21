using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;
using SharpTestsEx;

namespace StrongChess.Model.Tests.Units
{
    [TestFixture]
    public class SquaresSWTests
    {
        [Test]
        public void Ctor_E4_ReturnsD3C2B1()
        {
            // arrange
            var s = new SquaresSW("E4");
            var expected = Bitboard.With.D3.C2.B1.Build();

            // act 

            // assert
            s.AsBoard.Should().Be(expected);
        }

        [Test]
        public void Ctor_H1_ReturnsEmpty()
        {
            // arrange
            var s = new SquaresSW("H1");
            var expected = Bitboard.Empty;

            // act 

            // assert
            s.AsBoard.Should().Be(expected);
        }

        [Test]
        public void Ctor_A8_ReturnsEmpty()
        {
            // arrange
            var s = new SquaresSW("A8");
            var expected = Bitboard.Empty;

            // act 

            // assert
            s.AsBoard.Should().Be(expected);
        }
    }
}
