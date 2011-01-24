using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;
using SharpTestsEx;

namespace StrongChess.Model.Tests.Units
{
    [TestFixture]
    public class RookPathTests
    {

        [Test]
        public void BetweenA1A4_A2A3()
        {
            // arrange
            var p = new RookPath("A1", "A4");
            var expected = Bitboard.With.A2.A3.Build();

            // act

            // assert
            p.AsBoard.Should().Be(expected);
            p.IsValid.Should().Be(true);
        }

        [Test]
        public void BetweenA4A1_A2A3()
        {
            // arrange
            var p = new RookPath("A4", "A1");
            var expected = Bitboard.With.A2.A3.Build();

            // act

            // assert
            p.AsBoard.Should().Be(expected);
            p.IsValid.Should().Be(true);
        }


        [Test]
        public void BetweenA1F1_B1C1D1E1()
        {
            // arrange
            var p = new RookPath("A1", "F1");
            var expected=  Bitboard.With.B1.C1.D1.E1.Build();

            // act

            // assert
            p.AsBoard.Should().Be(expected);
            p.IsValid.Should().Be(true);
        }

        [Test]
        public void BetweenF1A1_B1C1D1E1()
        {
            // arrange
            var p = new RookPath("F1", "A1");
            var expected = Bitboard.With.B1.C1.D1.E1.Build();

            // act

            // assert
            p.AsBoard.Should().Be(expected);
            p.IsValid.Should().Be(true);
        }

        [Test]
        public void BetweenF1A2_Empty()
        {
            // arrange
            var p = new RookPath("F1", "A2");
            var expected = Bitboard.Empty;

            // act

            // assert
            p.AsBoard.Should().Be(expected);
            p.IsValid.Should().Be(false);
        }
    }
}
