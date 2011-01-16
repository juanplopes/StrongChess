using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using StrongChess.Model.Util;
using SharpTestsEx;

namespace StrongChess.Model.Tests.Util
{
    [TestFixture]
    public class BoardShifterTests
    {
        [Test]
        public void Can1_0ShiftNumber_1()
        {
            1ul.ChessShift(1, 0).Should().Be(0x100);
        }

        [Test]
        public void Can1_1ShiftNumber_1()
        {
            1ul.ChessShift(1, 1).Should().Be(0x200);
        }

        [Test]
        public void Can4_3ShiftNumber_1()
        {
            1ul.ChessShift(4, 3).Should().Be(0x800000000);
        }


        [Test]
        public void CanM4_M3ShiftNumber_1()
        {
            1ul.ChessShift(-4, -3).Should().Be(0);
        }

        [Test]
        public void CanM4_3ShiftNumber_1()
        {
            1ul.ChessShift(-4, 3).Should().Be(0);
        }
    }
}
