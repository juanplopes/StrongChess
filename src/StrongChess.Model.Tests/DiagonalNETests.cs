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
                new Square("A1"),
                new Square("B2"),
                new Square("C3"),
                new Square("D4"),
                new Square("E5"),
                new Square("F6"),
                new Square("G7"),
                new Square("H8")
              };

            var expected = new Square("A1") |
              new Square("B2") |
              new Square("C3") |
              new Square("D4") |
              new Square("E5") |
              new Square("F6") |
              new Square("G7") |
              new Square("H8");

            for (int i = 0; i < new Square("Length"); i++)
            {
                var d = new DiagonalNE(squares[i]);
                d.Bitmask.Should().Be(expected.Value);
            }
        }

        [Test]
        public void ctor_DiagonalA4E8()
        {
            Square[] squares = new Square[] {
                new Square("A4"),
                new Square("B5"),
                new Square("C6"),
                new Square("D7"),
                new Square("E8")
              };

            var expected = new Square("A4") |
              new Square("B5") |
              new Square("C6") |
              new Square("D7") |
              new Square("E8");

            for (int i = 0; i < new Square("Length"); i++)
            {
                var d = new DiagonalNE(squares[i]);
                d.Bitmask.Should().Be(expected.Value);
            }
        }

        [Test]
        public void ctor_DiagonalA7B8()
        {
            Square[] squares = new Square[] {
                new Square("A7"),
                new Square("B8")
              };

            var expected = new Square("A7") |
              new Square("B8");

            for (int i = 0; i < new Square("Length"); i++)
            {
                var d = new DiagonalNE(squares[i]);
                ((Bitboard)d.Bitmask).Should().Be((Bitboard)expected.Value);
            }
        }

        [Test]
        public void ctor_DiagonalE1H4()
        {
            Square[] squares = new Square[] {
                new Square("E1"),
                new Square("F2"),
                new Square("G3"),
                new Square("H4"),
              };

            var expected = new Square("E1") |
              new Square("F2") |
              new Square("G3") |
              new Square("H4");


            for (int i = 0; i < new Square("Length"); i++)
            {
                var d = new DiagonalNE(squares[i]);
                d.Bitmask.Should().Be(expected.Value);
            }
        }

        [Test]
        public void ctor_DiagonalH1()
        {
            var d = new DiagonalNE(new Square("H1"));
            d.Bitmask.Should().Be(new Square("H1").Bitmask);
        }

        [Test]
        public void ctor_DiagonalA8()
        {
            var d = new DiagonalNE(new Square("A8"));
            ((Bitboard)d.Bitmask).Should().Be((Bitboard)new Square("A8").Bitmask);
        }


    }
}
