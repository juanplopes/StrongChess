﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using StrongChess.Model.Util;
using SharpTestsEx;

namespace StrongChess.Model.Tests.Util
{
    [TestFixture]
    public class BitOperationsTests
    {
        [Test]
        public void PopulationCountOf1Is1()
        {
            BitOperations.PopCount(1).Should().Be(1);
        }

        [Test]
        public void PopulationCountOf3Is2()
        {
            BitOperations.PopCount(3).Should().Be(2);
        }

        [Test]
        public void PopulationCountOfNotZeroIs64()
        {
            BitOperations.PopCount(~0ul).Should().Be(64);
        }

        [Test]
        public void BitScanReverseOf0Is0()
        {
            BitOperations.BitScanReverse(0).Should().Be(0);
        }

        [Test]
        public void BitScanReverseOf1Is0()
        {
            BitOperations.BitScanReverse(1).Should().Be(0);
        }

        [Test]
        public void BitScanReverseOf3Is1()
        {
            BitOperations.BitScanReverse(3).Should().Be(1);
        }

        [Test]
        public void BitScanReverseOfNotZeroIs63()
        {
            BitOperations.BitScanReverse(~0ul).Should().Be(63);
        }

        [Test]
        public void BitScanForwardOf1Is0()
        {
            BitOperations.BitScanForward(1).Should().Be(0);
        }

        [Test]
        public void BitScanForwardOf3Is0()
        {
            BitOperations.BitScanForward(3).Should().Be(0);
        }

        [Test]
        public void BitScanForwardOfNotZeroIs0()
        {
            BitOperations.BitScanForward(~0ul).Should().Be(0);
        }

        [Test]
        public void BitScanForwardOfZeroIs0()
        {
            BitOperations.BitScanForward(0).Should().Be(63);
        }
    }


}
