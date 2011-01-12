using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;
using SharpTestsEx;

namespace StrongChess.Model.Tests
{
    [TestFixture]
    public class DiagonalNETests
    {

        [Test]
        public void ctor_DiagonalA1H8()
        {
            Square[] squares = new Square[] {
                Squares.A1,
                Squares.B2,
                Squares.C3,
                Squares.D4,
                Squares.E5,
                Squares.F6,
                Squares.G7,
                Squares.H8
              };

            var expected = Squares.A1 |
              Squares.B2 |
              Squares.C3 |
              Squares.D4 |
              Squares.E5 |
              Squares.F6 |
              Squares.G7 |
              Squares.H8;

            for (int i = 0; i < squares.Length; i++)
            {
                var d = new DiagonalNE(squares[i]);
                d.Bitmask.Should().Be(expected.Value);
            }
        }

        [Test]
        public void ctor_DiagonalA4E8()
        {
            Square[] squares = new Square[] {
                Squares.A4,
                Squares.B5,
                Squares.C6,
                Squares.D7,
                Squares.E8
              };

            var expected = Squares.A4 |
              Squares.B5 |
              Squares.C6 |
              Squares.D7 |
              Squares.E8;

            for (int i = 0; i < squares.Length; i++)
            {
                var d = new DiagonalNE(squares[i]);
                d.Bitmask.Should().Be(expected.Value);
            }
        }

        [Test]
        public void ctor_DiagonalA7B8()
        {
            Square[] squares = new Square[] {
                Squares.A7,
                Squares.B8
              };

            var expected = Squares.A7 |
              Squares.B8;

            for (int i = 0; i < squares.Length; i++)
            {
                var d = new DiagonalNE(squares[i]);
                ((Bitboard)d.Bitmask).Should().Be((Bitboard)expected.Value);
            }
        }

        [Test]
        public void ctor_DiagonalE1H4()
        {
            Square[] squares = new Square[] {
                Squares.E1,
                Squares.F2,
                Squares.G3,
                Squares.H4,
              };

            var expected = Squares.E1 |
              Squares.F2 |
              Squares.G3 |
              Squares.H4;


            for (int i = 0; i < squares.Length; i++)
            {
                var d = new DiagonalNE(squares[i]);
                d.Bitmask.Should().Be(expected.Value);
            }
        }

        [Test]
        public void ctor_DiagonalH1()
        {
            var d = new DiagonalNE(Squares.H1);
            d.Bitmask.Should().Be(Squares.H1.Bitmask);
        }

        [Test]
        public void ctor_DiagonalA8()
        {
            var d = new DiagonalNE(Squares.A8);
            ((Bitboard)d.Bitmask).Should().Be((Bitboard)Squares.A8.Bitmask);
        }


    }
}
