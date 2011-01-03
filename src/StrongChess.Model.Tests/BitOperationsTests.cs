using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using StrongChess.Model.Util;
using SharpTestsEx;

namespace StrongChess.Model.Tests
{
    [TestFixture]
    public class BitOperationsTests
    {
        [Test]
        public void PopulationCountOf1Is1()
        {
            BitOperations.PopCountIn(1).Should().Be(1);
        }

        [Test]
        public void PopulationCountOf3Is2()
        {
            BitOperations.PopCountIn(3).Should().Be(2);
        }

        [Test]
        public void PopulationCountOfNotZeroIs64()
        {
            BitOperations.PopCountIn(~0ul).Should().Be(64);
        }

        [Test]
        public void HighestBitOf0IsMinus0()
        {
            BitOperations.HighestBitPosition(0).Should().Be(-1);
        }

        [Test]
        public void HighestBitOf1Is0()
        {
            BitOperations.HighestBitPosition(1).Should().Be(0);
        }

        [Test]
        public void HighestBitOf3Is1()
        {
            BitOperations.HighestBitPosition(3).Should().Be(1);
        }

        [Test]
        public void HighestBitOfNotZeroIs63()
        {
            BitOperations.HighestBitPosition(~0ul).Should().Be(63);
        }
    }


}
