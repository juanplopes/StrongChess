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
                new Square("A8"),
                new Square("B7"),
                new Square("C6"),
                new Square("D5"),
                new Square("E4"),
                new Square("F3"),
                new Square("G2"),
                new Square("H1")
              };

            var expected = new Square("A8") |
              new Square("B7") |
              new Square("C6") |
              new Square("D5") |
              new Square("E4") |
              new Square("F3") |
              new Square("G2") |
              new Square("H1");

            for (int i = 0; i < new Square("Length"); i++)
            {
                var d = new DiagonalNW(squares[i]);
                ((Bitboard)d.Bitmask).Should().Be((Bitboard)expected.Value);
            }
        }

        [Test]
        public void ctor_DiagonalH4D8()
        {
          Square[] squares = new Square[] {
            new Square("H4"),
            new Square("G5"),
            new Square("F6"),
            new Square("E7"),
            new Square("D8")
          };

          var expected = new Square("H4") |
            new Square("G5") |
            new Square("F6") |
            new Square("E7") |
            new Square("D8");

          for (int i = 0; i < new Square("Length"); i++)
          {
            var d = new DiagonalNW(squares[i]);
            ((Bitboard)d.Bitmask).Should().Be((Bitboard)expected.Value);
          }
        }

        [Test]
        public void ctor_DiagonalH7G8()
        {
          Square[] squares = new Square[] {
            new Square("H7"),
            new Square("G8")
          };

          var expected = new Square("H7") |
            new Square("G8");

          for (int i = 0; i < new Square("Length"); i++)
          {
            var d = new DiagonalNW(squares[i]);
            ((Bitboard)d.Bitmask).Should().Be((Bitboard)expected.Value);
          }
        }

        [Test]
        public void ctor_DiagonalE1A5()
        {
          Square[] squares = new Square[] {
            new Square("E1"),
            new Square("D2"),
            new Square("C3"),
            new Square("B4"),
            new Square("A5"),
          };

          var expected = new Square("E1") |
            new Square("D2") |
            new Square("C3") |
            new Square("B4") |
            new Square("A5");


          for (int i = 0; i < new Square("Length"); i++)
          {
            var d = new DiagonalNW(squares[i]);
            d.Bitmask.Should().Be(expected.Value);
          }
        }

        [Test]
        public void ctor_DiagonalA1()
        {
          var d = new DiagonalNW(new Square("A1"));
          d.Bitmask.Should().Be(new Square("A1").Bitmask);
        }

        [Test]
        public void ctor_DiagonalH8()
        {
          var d = new DiagonalNW(new Square("H8"));
          ((Bitboard)d.Bitmask).Should().Be((Bitboard)new Square("H8").Bitmask);
        }

    }

}
