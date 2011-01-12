using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using StrongChess.Model.Pieces;
using SharpTestsEx;

namespace StrongChess.Model.Tests
{
    [TestFixture]
    public class KingTests
    {
        [Test]
        public void GetKingAttacksBitboard_A1_ReturnsA2B2B1()
        {
            Bitboard test = new King("A1").GetMoveBoard();

            Bitboard expected = new Bitboard();
            expected = expected
                .Set(new Square("A2"))
                .Set(new Square("B2"))
                .Set(new Square("B1"))
                ;

            test.Should().Be(expected);
        }

        [Test]
        public void GetKingAttacksBitboard_H8_ReturnsH7G7G8()
        {
            Bitboard test = new King("H8").GetMoveBoard();

            Bitboard expected = new Bitboard();
            expected = expected
                .Set(new Square("H7"))
                .Set(new Square("G7"))
                .Set(new Square("G8"))
                ;

            test.Should().Be(expected);
        }

        [Test]
        public void GetKingAttacksBitboard_H1_ReturnsH2G2G1()
        {
            Bitboard test = new King("H1").GetMoveBoard();

            Bitboard expected = new Bitboard();
            expected = expected
                .Set(new Square("H2"))
                .Set(new Square("G2"))
                .Set(new Square("G1"))
                ;

            test.Should().Be(expected);
        }

        [Test]
        public void GetKingAttacksBitboard_A8_ReturnsA7B7B8()
        {
            Bitboard test = new King("A8").GetMoveBoard();

            Bitboard expected = new Bitboard();
            expected = expected
                .Set(new Square("A7"))
                .Set(new Square("B7"))
                .Set(new Square("B8"))
                ;

            test.Should().Be(expected);
        }


        [Test]
        public void GetKingAttacksBitboard_A4_ReturnsA3A5B3B4B5()
        {
            Bitboard test = new King("A4").GetMoveBoard();

            Bitboard expected = new Bitboard();
            expected = expected
                .Set(new Square("A3"))
                .Set(new Square("A5"))
                .Set(new Square("B3"))
                .Set(new Square("B4"))
                .Set(new Square("B5"))
                ;

            test.Should().Be(expected);
        }

        [Test]
        public void GetKingAttacksBitboard_H4_ReturnsH3H5G3G4G5()
        {
            Bitboard test = new King("H4").GetMoveBoard();

            Bitboard expected = new Bitboard();
            expected = expected
                .Set(new Square("H3"))
                .Set(new Square("H5"))
                .Set(new Square("G3"))
                .Set(new Square("G4"))
                .Set(new Square("G5"))
                ;

            test.Should().Be(expected);
        }

        [Test]
        public void GetKingAttacksBitboard_E1_ReturnsD1F1D2E2F2()
        {
            Bitboard test = new King("E1").GetMoveBoard();

            Bitboard expected = new Bitboard();
            expected = expected
                .Set(new Square("D1"))
                .Set(new Square("F1"))
                .Set(new Square("D2"))
                .Set(new Square("E2"))
                .Set(new Square("F2"))
                ;

            test.Should().Be(expected);
        }

        [Test]
        public void GetKingAttacksBitboard_E8_ReturnsD8F8D7E7F7()
        {
            Bitboard test = new King("E8").GetMoveBoard();

            Bitboard expected = new Bitboard();
            expected = expected
                .Set(new Square("D8"))
                .Set(new Square("F8"))
                .Set(new Square("D7"))
                .Set(new Square("E7"))
                .Set(new Square("F7"))
                ;

            test.Should().Be(expected);
        }

        [Test]
        public void GetKingAttacksBitboard_E4AndFriendsD3E3F3D4_ReturnsF4D5E5F5()
        {
            Bitboard friends = new Bitboard();
            friends = friends
                .Set(new Square("D3"))
                .Set(new Square("E3"))
                .Set(new Square("F3"))
                .Set(new Square("D4"));

            Bitboard test = new King("E4").GetMoveBoard(friends);

            Bitboard expected = new Bitboard();
            expected = expected
                .Set(new Square("F4"))
                .Set(new Square("D5"))
                .Set(new Square("E5"))
                .Set(new Square("F5"))
                ;

            test.Should().Be(expected);
        }



    }
}
