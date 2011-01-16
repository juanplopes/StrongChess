using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using StrongChess.Model.Pieces;
using SharpTestsEx;

namespace StrongChess.Model.Tests.Pieces
{
    [TestFixture]
    public class KingTests
    {
        [Test]
        public void GetKingAttacksBitboard_A1_ReturnsA2B2B1()
        {
            var test = Rules.For<King>().GetMoveBoard("A1");
            var expected = Bitboard.With.A2.B2.B1.Build();
            test.Should().Be(expected);
        }

        [Test]
        public void GetKingAttacksBitboard_H8_ReturnsH7G7G8()
        {
            var test = Rules.For<King>().GetMoveBoard("H8");
            var expected = Bitboard.With.H7.G7.G8.Build();
            test.Should().Be(expected);
        }

        [Test]
        public void GetKingAttacksBitboard_H1_ReturnsH2G2G1()
        {
            var test = Rules.For<King>().GetMoveBoard("H1");
            var expected = Bitboard.With.H2.G2.G1.Build();
            test.Should().Be(expected);
        }

        [Test]
        public void GetKingAttacksBitboard_A8_ReturnsA7B7B8()
        {
            var test = Rules.For<King>().GetMoveBoard("A8");
            var expected = Bitboard.With.A7.B7.B8.Build();
            test.Should().Be(expected);
        }


        [Test]
        public void GetKingAttacksBitboard_A4_ReturnsA3A5B3B4B5()
        {
            var test = Rules.For<King>().GetMoveBoard("A4");
            var expected = Bitboard.With.A3.A5.B3.B4.B5.Build();
            test.Should().Be(expected);
        }

        [Test]
        public void GetKingAttacksBitboard_H4_ReturnsH3H5G3G4G5()
        {
            var test = Rules.For<King>().GetMoveBoard("H4");
            var expected = Bitboard.With.H3.H5.G3.G4.G5.Build();
            test.Should().Be(expected);
        }

        [Test]
        public void GetKingAttacksBitboard_E1_ReturnsD1F1D2E2F2()
        {
            var test = Rules.For<King>().GetMoveBoard("E1");
            var expected = Bitboard.With.D1.F1.D2.E2.F2.Build();
            test.Should().Be(expected);
        }

        [Test]
        public void GetKingAttacksBitboard_E8_ReturnsD8F8D7E7F7()
        {
            var test = Rules.For<King>().GetMoveBoard("e8");
            var expected = Bitboard.With.D8.F8.D7.E7.F7.Build();
            test.Should().Be(expected);
        }

        [Test]
        public void GetKingAttacksBitboard_E4AndFriendsD3E3F3D4_ReturnsF4D5E5F5()
        {
            var friends = Bitboard.With.D3.E3.F3.D4.Build();
            var test = Rules.For<King>().GetMoveBoard("E4", friends);
            var expected = Bitboard.With.F4.D5.E5.F5.Build();
            test.Should().Be(expected);
        }



    }
}
