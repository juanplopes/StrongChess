using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;
using SharpTestsEx;

namespace StrongChess.Model.Tests
{
    [TestFixture]
    public class DirectionsTests
    {
        [Test]
        public void N_E4_ReturnsE5E6E7E8()
        {
            // arrange
            var s = new Directions("E4").N;
            var expected = Bitboard.With.E5.E6.E7.E8.Build();

            // act 

            // assert
            s.AsBoard.Should().Be(expected);
        }

        [Test]
        public void N_A8_ReturnsEmpty()
        {
            // arrange
            var s = new Directions("A8").N;
            var expected = Bitboard.Empty;

            // act 

            // assert
            s.AsBoard.Should().Be(expected);
        }

        [Test]
        public void S_E4_ReturnsE3E2E1()
        {
            // arrange
            var s = new Directions("E4").S;
            var expected = Bitboard.With.E3.E2.E1.Build();

            // act 

            // assert
            s.AsBoard.Should().Be(expected);
        }

        [Test]
        public void S_A1_ReturnsEmpty()
        {
            // arrange
            var s = new Directions("A1").S;
            var expected = Bitboard.Empty;

            // act 

            // assert
            s.AsBoard.Should().Be(expected);
        }

        [Test]
        public void SE_E4_ReturnsF3G2H1()
        {
            // arrange
            var s = new Directions("E4").SE;
            var expected = Bitboard.With.F3.G2.H1.Build();

            // act 

            // assert
            s.AsBoard.Should().Be(expected);
        }

        [Test]
        public void SE_H1_ReturnsEmpty()
        {
            // arrange
            var s = new Directions("H1").SE;
            var expected = Bitboard.Empty;

            // act 

            // assert
            s.AsBoard.Should().Be(expected);
        }

        [Test]
        public void SE_A8_ReturnsB7C6D5E4F3G2H1()
        {
            // arrange
            var s = new Directions("A8").SE;
            var expected = Bitboard.With.B7.C6.D5.E4.F3.G2.H1.Build();

            // act 

            // assert
            s.AsBoard.Should().Be(expected);
        }

        [Test]
        public void NE_E4_ReturnsF5G6H7()
        {
            // arrange
            var s = new Directions("E4").NE;
            var expected = Bitboard.With.F5.G6.H7.Build();

            // act 

            // assert
            s.AsBoard.Should().Be(expected);
        }

        [Test]
        public void NE_H1_ReturnsEmpty()
        {
            // arrange
            var s = new Directions("H1").NE;
            var expected = Bitboard.Empty;

            // act 

            // assert
            s.AsBoard.Should().Be(expected);
        }

        [Test]
        public void NE_A8_ReturnsEmpty()
        {
            // arrange
            var s = new Directions("A8").NE;
            var expected = Bitboard.Empty;

            // act 

            // assert
            s.AsBoard.Should().Be(expected);
        }

        [Test]
        public void NW_E4_ReturnsD5C6B7A8()
        {
            // arrange
            var s = new Directions("E4").NW;
            var expected = Bitboard.With.D5.C6.B7.A8.Build();

            // act 

            // assert
            s.AsBoard.Should().Be(expected);
        }

        [Test]
        public void NW_H1_ReturnsG2F3E4D5C6B7A8()
        {
            // arrange
            var s = new Directions("H1").NW;
            var expected = Bitboard.With.G2.F3.E4.D5.C6.B7.A8.Build();

            // act 

            // assert
            s.AsBoard.Should().Be(expected);
        }

        [Test]
        public void NW_A8_ReturnsEmpty()
        {
            // arrange
            var s = new Directions("A8").NW;
            var expected = Bitboard.Empty;

            // act 

            // assert
            s.AsBoard.Should().Be(expected);
        }

        [Test]
        public void SW_E4_ReturnsD3C2B1()
        {
            // arrange
            var s = new Directions("E4").SW;
            var expected = Bitboard.With.D3.C2.B1.Build();

            // act 

            // assert
            s.AsBoard.Should().Be(expected);
        }

        [Test]
        public void SW_H1_ReturnsEmpty()
        {
            // arrange
            var s = new Directions("H1").SW;
            var expected = Bitboard.Empty;

            // act 

            // assert
            s.AsBoard.Should().Be(expected);
        }

        [Test]
        public void SW_A8_ReturnsEmpty()
        {
            // arrange
            var s = new Directions("A8").SW;
            var expected = Bitboard.Empty;

            // act 

            // assert
            s.AsBoard.Should().Be(expected);
        }

        [Test]
        public void E_E4_ReturnsF4G4H4()
        {
            // arrange
            var s = new Directions("E4").E;
            var expected = Bitboard.With.F4.G4.H4.Build();

            // act 

            // assert
            s.AsBoard.Should().Be(expected);
        }

        [Test]
        public void E_H1_ReturnsEmpty()
        {
            // arrange
            var s = new Directions("H1").E;
            var expected = Bitboard.Empty;

            // act 

            // assert
            s.AsBoard.Should().Be(expected);
        }

        [Test]
        public void E_A8_ReturnsB8C8D8E8F8G8H8()
        {
            // arrange
            var s = new Directions("A8").E;
            var expected = Bitboard.With.B8.C8.D8.E8.F8.G8.H8.Build();

            // act 

            // assert
            s.AsBoard.Should().Be(expected);
        }

        [Test]
        public void W_E4_ReturnsD4C4B4A4()
        {
            // arrange
            var s = new Directions("E4").W;
            var expected = Bitboard.With.D4.C4.B4.A4.Build();

            // act 

            // assert
            s.AsBoard.Should().Be(expected);
        }

        [Test]
        public void W_H1_ReturnsG1F1E1D1C1B1A1()
        {
            // arrange
            var s = new Directions("H1").W;
            var expected = Bitboard.With.G1.F1.E1.D1.C1.B1.A1.Build();

            // act 

            // assert
            s.AsBoard.Should().Be(expected);
        }

        [Test]
        public void W_A8_ReturnsEmpty()
        {
            // arrange
            var s = new Directions("A8").W;
            var expected = Bitboard.Empty;

            // act 

            // assert
            s.AsBoard.Should().Be(expected);
        }
    }
}
