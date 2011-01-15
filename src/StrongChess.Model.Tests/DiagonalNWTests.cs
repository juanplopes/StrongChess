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
            Square[] squares = new Square[] {
                Squares.A8,
                Squares.B7,
                Squares.C6,
                Squares.D5,
                Squares.E4,
                Squares.F3,
                Squares.G2,
                Squares.H1
              };

            var expected = Squares.A8 |
              Squares.B7 |
              Squares.C6 |
              Squares.D5 |
              Squares.E4 |
              Squares.F3 |
              Squares.G2 |
              Squares.H1;

            for (int i = 0; i < squares.Length; i++)
            {
                var d = new DiagonalNW(squares[i]);
                ((Bitboard)d.Bitmask).Should().Be((Bitboard)expected.Value);
            }
        }

        [Test]
        public void ctor_DiagonalH4D8()
        {
          Square[] squares = new Square[] {
            Squares.H4,
            Squares.G5,
            Squares.F6,
            Squares.E7,
            Squares.D8
          };

          var expected = Squares.H4 |
            Squares.G5 |
            Squares.F6 |
            Squares.E7 |
            Squares.D8;

          for (int i = 0; i < squares.Length; i++)
          {
            var d = new DiagonalNW(squares[i]);
            ((Bitboard)d.Bitmask).Should().Be((Bitboard)expected.Value);
          }
        }

        [Test]
        public void ctor_DiagonalH7G8()
        {
          Square[] squares = new Square[] {
            Squares.H7,
            Squares.G8
          };

          var expected = Squares.H7 |
            Squares.G8;

          for (int i = 0; i < squares.Length; i++)
          {
            var d = new DiagonalNW(squares[i]);
            ((Bitboard)d.Bitmask).Should().Be((Bitboard)expected.Value);
          }
        }

        [Test]
        public void ctor_DiagonalE1A5()
        {
          Square[] squares = new Square[] {
            Squares.E1,
            Squares.D2,
            Squares.C3,
            Squares.B4,
            Squares.A5,
          };

          var expected = Squares.E1 |
            Squares.D2 |
            Squares.C3 |
            Squares.B4 |
            Squares.A5;


          for (int i = 0; i < squares.Length; i++)
          {
            var d = new DiagonalNW(squares[i]);
            d.Bitmask.Should().Be(expected.Value);
          }
        }

        [Test]
        public void ctor_DiagonalA1()
        {
          var d = new DiagonalNW(Squares.A1);
          d.Bitmask.Should().Be(Squares.A1.Bitmask);
        }

        [Test]
        public void ctor_DiagonalH8()
        {
          var d = new DiagonalNW(Squares.H8);
          ((Bitboard)d.Bitmask).Should().Be((Bitboard)Squares.H8.Bitmask);
        }

    }

}
