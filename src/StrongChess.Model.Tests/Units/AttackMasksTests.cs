using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;
using SharpTestsEx;


namespace StrongChess.Model.Tests.Units
{
    [TestFixture]
    public class AttackMasksTests
    {
        [Test]
        public void WhitePawns_E4_D3F3()
        {
            // arrange
            var a = new AttackMasks(new Square("E4"));
            var expected = Bitboard.With.D3.F3.Build();

            // act
            var result = a.WhitePawns;

            // assert
            result.Should().Be(expected);
        }

        [Test]
        public void BlackPawns_E4_D5F5()
        {
            // arrange
            var a = new AttackMasks(new Square("E4"));
            var expected = Bitboard.With.D5.F5.Build();

            // act
            var result = a.BlackPawns;

            // assert
            result.Should().Be(expected);
        }

        [Test]
        public void BlackPawns_A4_B5()
        {
            // arrange
            var a = new AttackMasks(new Square("A4"));
            var expected = Bitboard.With.B5.Build();

            // act
            var result = a.BlackPawns;

            // assert
            result.Should().Be(expected);
        }

        [Test]
        public void WhitePawns_A4_B3()
        {
            // arrange
            var a = new AttackMasks(new Square("A4"));
            var expected = Bitboard.With.B3.Build();

            // act
            var result = a.WhitePawns;

            // assert
            result.Should().Be(expected);
        }

    }
}
