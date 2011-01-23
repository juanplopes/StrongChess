using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;
using SharpTestsEx;

namespace StrongChess.Model.Tests.Units
{
    [TestFixture]
    public class DiagonalNETests
    {

        [Test]
        public void ctor_DiagonalA1H8()
        {
            var expected = Bitboard.With.A1.B2.C3.D4.E5.F6.G7.H8.Build();

            foreach (var square in expected.Squares)
                square.DiagonalNE.AsBoard.Should().Be(expected);

        }

        [Test]
        public void ctor_DiagonalA4E8()
        {
            var expected = Bitboard.With.A4.B5.C6.D7.E8.Build();

            foreach (var square in expected.Squares)
                square.DiagonalNE.AsBoard.Should().Be(expected);
        }

        [Test]
        public void ctor_DiagonalA7B8()
        {
            var expected = Bitboard.With.A7.B8.Build();

            foreach (var square in expected.Squares)
                square.DiagonalNE.AsBoard.Should().Be(expected);
        }

        [Test]
        public void ctor_DiagonalE1H4()
        {
            var expected = Bitboard.With.E1.F2.G3.H4.Build();

            foreach (var square in expected.Squares)
                square.DiagonalNE.AsBoard.Should().Be(expected);
        }

        [Test]
        public void ctor_DiagonalH1()
        {
            var expected = Bitboard.With.H1.Build();

            foreach (var square in expected.Squares)
                square.DiagonalNE.AsBoard.Should().Be(expected);
        }

        [Test]
        public void ctor_DiagonalA8()
        {
            var expected = Bitboard.With.A8.Build();

            foreach (var square in expected.Squares)
                square.DiagonalNE.AsBoard.Should().Be(expected);
        }


    }
}
