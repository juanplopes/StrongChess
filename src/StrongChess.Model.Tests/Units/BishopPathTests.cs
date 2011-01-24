using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;
using SharpTestsEx;

namespace StrongChess.Model.Tests.Units
{
    
    [TestFixture]
    public class BishopPathTests
    {
        [Test]
        public void BetweenA1D4_B2C3()
        {
            // arrange
            var p = new BishopPath("A1", "D4");
            var expected = Bitboard.With.B2.C3.Build();

            // act
            
            // assert
            p.AsBoard.Should().Be(expected);
            p.IsValid.Should().Be(true);
        }

        [Test]
        public void BetweenH1E4_G2F3()
        {
            // arrange
            var p = new BishopPath("H1", "E4");
            var expected = Bitboard.With.G2.F3.Build();

            // act

            // assert
            p.AsBoard.Should().Be(expected);
            p.IsValid.Should().Be(true);
        }

        [Test]
        public void BetweenD4A1_B2C3()
        {
            // arrange
            var p = new BishopPath("D4", "A1");
            var expected = Bitboard.With.B2.C3.Build();

            // act

            // assert
            p.AsBoard.Should().Be(expected);
            p.IsValid.Should().Be(true);
        }

        [Test]
        public void BetweenD5A1_Empty()
        {
            // arrange
            var p = new BishopPath("D5", "A1");
            var expected = Bitboard.Empty;

            // act

            // assert
            p.AsBoard.Should().Be(expected);
            p.IsValid.Should().Be(false);
        }
    }
}
