using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SharpTestsEx;
using System.Runtime.InteropServices;

namespace StrongChess.Model.Tests
{
    [TestFixture]
    public class FileTests
    {
        [Test]
        public void SizeOfFileShouldBe4()
        {
            Marshal.SizeOf(new File()).Should().Be(4);
        }

        [Test]
        public void ConstructFromIndex_4()
        {
            File file = 4;

            file.Index.Should().Be(4);
            file.ToString().Should().Be("E");
        }

        [Test]
        public void ConstructFromString_D()
        {
            File file = "D";

            file.Index.Should().Be(3);
            file.ToString().Should().Be("D");
        }

        [Test]
        public void ConstructFromString_d()
        {
            File file = "d";

            file.Index.Should().Be(3);
            file.ToString().Should().Be("D");
        }


        [Test]
        public void ConstructFromString_Aminus1()
        {
            File file = ((char)('A' - 1)).ToString();

            file.Index.Should().Be(-1);
            file.ToString().Should().Be("#");
        }

        [Test]
        public void ConstructFromString_I()
        {
            File file = "I";

            file.Index.Should().Be(8);
            file.ToString().Should().Be("#");
        }

        [Test]
        public void ThereCanBeInvalidFiles()
        {
            File file1 = "%";
            File file2 = "K";
            file1.IsValid.Should().Be.False();
            file2.IsValid.Should().Be.False();
        }

        [Test]
        public void FileAShouldContainAllA()
        {
            File file = "A";
            file.AsBoard.GetSetSquares().Should().Have.SameSequenceAs(
                "A1", "A2", "A3", "A4", "A5", "A6", "A7", "A8");
        }

        [Test]
        public void BitmaskForRank7()
        {
            File file = "H";
            file.AsBoard.GetSetSquares().Should().Have.SameSequenceAs(
                "H1", "H2", "H3", "H4", "H5", "H6", "H7", "H8");
        }

    }
}
