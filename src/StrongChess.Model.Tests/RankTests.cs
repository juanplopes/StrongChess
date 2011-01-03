using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SharpTestsEx;

namespace StrongChess.Model.Tests
{
    [TestFixture]
    public class RankTests
    {
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
    }
}
