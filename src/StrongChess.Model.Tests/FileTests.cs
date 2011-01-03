using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SharpTestsEx;

namespace StrongChess.Model.Tests
{
    [TestFixture]
    public class FileTests
    {
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
        public void BitmaskForFileA()
        {
            File file = "A";
            file.Bitmask.Should().Be(0x0101010101010101);
        }

        [Test]
        public void BitmaskForRank7()
        {
            File file = "H";
            file.Bitmask.Should().Be(0x8080808080808080);
        }

    }
}
