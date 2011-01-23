using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SharpTestsEx;
using System.Runtime.InteropServices;

namespace StrongChess.Model.Tests.Units
{
    [TestFixture]
    public class SquareTests
    {
        [Test]
        public void SizeOfSquareShouldBe4()
        {
            Marshal.SizeOf(new Square()).Should().Be(4);
        }


        [Test]
        public void ConstructFromIndex_8()
        {
            Square square = 8;

            square.Index.Should().Be(8);
            square.IsValid.Should().Be.True();
            square.Rank.Index.Should().Be(1);
            square.File.Index.Should().Be(0);
            square.ToString().Should().Be("A2");
        }

        [Test]
        public void ConstructFromString_B3()
        {
            Square square = "B3";

            square.Index.Should().Be(17);
            square.IsValid.Should().Be.True();
            square.Rank.Index.Should().Be(2);
            square.File.Index.Should().Be(1);
            square.ToString().Should().Be("B3");
        }

        [Test]
        public void ConstructFromRankAndFile_E7()
        {
            Square square = new Square("7", "E");

            square.Index.Should().Be(52);
            square.IsValid.Should().Be.True();
            square.Rank.Index.Should().Be(6);
            square.File.Index.Should().Be(4);
            square.ToString().Should().Be("E7");
        }



        [Test]
        public void ConstructFromString_B9()
        {
            Square square = "B9";

            square.IsValid.Should().Be.False();
        }

        [Test]
        public void ConstructFromString_I6()
        {
            Square square = "I6";

            square.IsValid.Should().Be.False();
        }

        [Test]
        public void BitmaskForA1()
        {
            Square square = "A1";
            square.AsBoard.Squares.Should().Have.SameSequenceAs("A1");
        }

        [Test]
        public void BitmaskForH8()
        {
            Square square = "H8";
            square.AsBoard.Squares.Should().Have.SameSequenceAs("H8");
        }

    }
}
