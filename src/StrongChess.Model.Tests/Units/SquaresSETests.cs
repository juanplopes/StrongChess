using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;
using SharpTestsEx;

namespace StrongChess.Model.Tests.Units
{
    [TestFixture]
    public class SquaresSETests
    {
        [Test]
        public void Ctor_E4_ReturnsF3G2H1()
        {
            // arrange
            var s = new SquaresSE("E4");
            var expected = Bitboard.With.F3.G2.H1.Build();

            // act 

            // assert
            s.AsBoard.Should().Be(expected);
        }

        [Test]
        public void Ctor_H1_ReturnsEmpty()
        {
            // arrange
            var s = new SquaresSE("H1");
            var expected = Bitboard.Empty;

            // act 

            // assert
            s.AsBoard.Should().Be(expected);
        }

        [Test]
        public void Ctor_A8_ReturnsB7C6D5E4F3G2H1()
        {
            // arrange
            var s = new SquaresSE("A8");
            var expected = Bitboard.With.B7.C6.D5.E4.F3.G2.H1.Build();

            // act 

            // assert
            s.AsBoard.Should().Be(expected);
        }
    }
}
