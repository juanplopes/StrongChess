using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;
using SharpTestsEx;

namespace StrongChess.Model.Tests
{
    [TestFixture]
    public class DiagonalNWTests
    {
        [Test]
        public void ctor_DiagonalH1A8()
        {
            var expected = Bitboard.With.A8.B7.C6.D5.E4.F3.G2.H1.Build();

            foreach (var square in expected.GetSetSquares())
                square.DiagonalNW.AsBoard.Should().Be(expected);
        }

        [Test]
        public void ctor_DiagonalH4D8()
        {
            var expected = Bitboard.With.H4.G5.F6.E7.D8.Build();

            foreach (var square in expected.GetSetSquares())
                square.DiagonalNW.AsBoard.Should().Be(expected);
        }

        [Test]
        public void ctor_DiagonalH7G8()
        {
            var expected = Bitboard.With.H7.G8.Build();

            foreach (var square in expected.GetSetSquares())
                square.DiagonalNW.AsBoard.Should().Be(expected);
        }

        [Test]
        public void ctor_DiagonalE1A5()
        {
            var expected = Bitboard.With.E1.D2.C3.B4.A5.Build();

            foreach (var square in expected.GetSetSquares())
                square.DiagonalNW.AsBoard.Should().Be(expected);
        }

        [Test]
        public void ctor_DiagonalA1()
        {
            var expected = Bitboard.With.A1.Build();

            foreach (var square in expected.GetSetSquares())
                square.DiagonalNW.AsBoard.Should().Be(expected);
        }

        [Test]
        public void ctor_DiagonalH8()
        {
            var expected = Bitboard.With.H8.Build();

            foreach (var square in expected.GetSetSquares())
                square.DiagonalNW.AsBoard.Should().Be(expected);
        }

    }

}
