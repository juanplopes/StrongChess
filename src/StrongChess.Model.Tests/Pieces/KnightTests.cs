using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using StrongChess.Model.Pieces;
using SharpTestsEx;

namespace StrongChess.Model.Tests.Pieces
{
    [TestFixture]
    public partial class KnightTests
    {
        [Test]
        public void GetKnightAttacksBitboad_A1_ReturnsC2andB3()
        {
            var test = Rules.For<Knight>().GetMoveBoard("A1");

            test.Should().Be(Bitboard.With.B3.C2.Build());
        }

        [Test]
        public void GetKnightAttacksBitboad_H1_ReturnsF2andG3()
        {
            var test = Rules.For<Knight>().GetMoveBoard("H1");

            test.Should().Be(Bitboard.With.G3.F2.Build());

        }

        [Test]
        public void GetKnightAttacksBitboad_H8_ReturnsF7andG6()
        {
            var test = Rules.For<Knight>().GetMoveBoard("H8");

            test.Should().Be(Bitboard.With.F7.G6.Build());
        }

        [Test]
        public void GetKnightAttacksBitboad_A8_ReturnsC7andB6()
        {
            var test = Rules.For<Knight>().GetMoveBoard("A8");

            test.Should().Be(Bitboard.With.C7.B6.Build());
        }

        [Test]
        public void GetKnightAttacksBitboad_B1_ReturnsA3andC3andD2()
        {
            var test = Rules.For<Knight>().GetMoveBoard("B1");

            test.Should().Be(Bitboard.With.A3.C3.D2.Build());
        }

        [Test]
        public void GetKnightAttacksBitboad_G8_ReturnsH6andF6andE7()
        {
            var test = Rules.For<Knight>().GetMoveBoard("G8");

            test.Should().Be(Bitboard.With.H6.F6.E7.Build());
        }

        [Test]
        public void GetKnightAttacksBitboad_E4_ReturnsF6G5G3F2D2C3C5D6()
        {
            var test = Rules.For<Knight>().GetMoveBoard("E4");

            test.Should().Be(Bitboard.With.F6.G5.G3.F2.D2.C3.C5.D6.Build());
        }

        [Test]
        public void GetKnightAttacksBitboard_H4_ReturnsF3G2G6F5()
        {
            var test = Rules.For<Knight>().GetMoveBoard("H4");

            test.Should().Be(Bitboard.With.F3.G2.G6.F5.Build());
        }

        // ------------------------------------------------


        [Test]
        public void GetKnightAttacksBitboard_B1BitboardAndFriendsA4B5D5E4_ReturnsD2A3C3()
        {
            var friends = Bitboard.With.A4.B5.D5.E4.Build();
            var expected = Bitboard.With.D2.A3.C3.Build();

            var test = Rules.For<Knight>().GetMoveBoard("B1");

            test.Should().Be(expected);

        }

        [Test]
        public void GetKnightAttacksBitboard_B1BitboardAndFriendsA4B5D5E4EnemyInD2_ReturnsD2A3C3()
        {
            var friends = Bitboard.With.A4.B5.D5.E4.Build();
            var enemy = Bitboard.With.D2.Build();
            var expected = Bitboard.With.D2.A3.C3.Build();

            var test = Rules.For<Knight>().GetMoveBoard("D2");

            test.Should().Be(expected);

        }
    }
}
