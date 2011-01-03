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
    public class RankTests
    {
        [Test]
        public void SizeOfRankShouldBe4()
        {
            Marshal.SizeOf(new Rank()).Should().Be(4);
        }


        [Test]
        public void ConstructFromIndex_4()
        {
            Rank rank = 4;
            
            rank.Index.Should().Be(4);
            rank.ToString().Should().Be("5");
        }

        [Test]
        public void ConstructFromString_4()
        {
            Rank rank = "4";

            rank.Index.Should().Be(3);
            rank.ToString().Should().Be("4");
        }

        [Test]
        public void ConstructFromString_0()
        {
            Rank rank = "0";

            rank.Index.Should().Be(-1);
            rank.ToString().Should().Be("#");
        }

        [Test]
        public void ConstructFromString_9()
        {
            Rank rank = "9";

            rank.Index.Should().Be(8);
            rank.ToString().Should().Be("#");
        }

        [Test]
        public void ThereCanBeInvalidRanks()
        {
            Rank rank1 = "0";
            Rank rank2 = "9";
            rank1.IsValid.Should().Be.False();
            rank2.IsValid.Should().Be.False();
        }

        [Test]
        public void BitmaskForRank1()
        {
            Rank rank = "1";
            rank.Bitmask.Should().Be(0x00000000000000FF);
        }

        [Test]
        public void BitmaskForRank7()
        {
            Rank rank = "7";
            rank.Bitmask.Should().Be(0x00FF000000000000);
        }

    }
}
