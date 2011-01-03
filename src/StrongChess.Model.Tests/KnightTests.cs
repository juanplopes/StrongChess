using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using StrongChess.Model.Pieces;
using SharpTestsEx;

namespace StrongChess.Model.Tests
{
    [TestFixture]
    public partial class KnightTests
    {
        [Test]
        public void GetKnightAttacksBitboad_A1_ReturnsC2andB3()
        {
            Bitboard test = new Knight("A1").GetMoveBoard();

            Bitboard expected = new Bitboard();
            expected = expected
                .Set(new Square("B3"))
                .Set(new Square("C2"));

            test.Should().Be(expected);
        }

        [Test]
        public void GetKnightAttacksBitboad_H1_ReturnsF2andG3()
        {
            Bitboard test = new Knight("H1").GetMoveBoard();

            Bitboard expected = new Bitboard();
            expected = expected
                .Set(new Square("G3"))
                .Set(new Square("F2"));

            test.Should().Be(expected);
        }

        [Test]
        public void GetKnightAttacksBitboad_H8_ReturnsF7andG6()
        {
            Bitboard test = new Knight("H8").GetMoveBoard();

            Bitboard expected = new Bitboard();
            expected = expected
                .Set(new Square("F7"))
                .Set(new Square("G6"));

            test.Should().Be(expected);
        }

        [Test]
        public void GetKnightAttacksBitboad_A8_ReturnsC7andB6()
        {
            Bitboard test = new Knight("A8").GetMoveBoard();

            Bitboard expected = new Bitboard();
            expected = expected
                .Set(new Square("C7"))
                .Set(new Square("B6"));

            test.Should().Be(expected);
        }

        [Test]
        public void GetKnightAttacksBitboad_B1_ReturnsA3andC3andD2()
        {
            Bitboard test = new Knight("B1").GetMoveBoard();

            Bitboard expected = new Bitboard();
            expected = expected
                .Set(new Square("A3"))
                .Set(new Square("C3"))
                .Set(new Square("D2"));

            test.Should().Be(expected);
        }

        [Test]
        public void GetKnightAttacksBitboad_G8_ReturnsH6andF6andE7()
        {
            Bitboard test = new Knight("G8").GetMoveBoard();

            Assert.IsTrue(test.IsSet(new Square("H6")), "H6?!");
            Assert.IsTrue(test.IsSet(new Square("F6")), "F6?!");
            Assert.IsTrue(test.IsSet(new Square("E7")), "E7?!");
            Bitboard expected = new Bitboard();
            expected = expected
                .Set(new Square("H6"))
                .Set(new Square("F6"))
                .Set(new Square("E7"));

            test.Should().Be(expected);
        }

        [Test]
        public void GetKnightAttacksBitboad_E4_ReturnsF6G5G3F2D2C3C5D6()
        {
            Bitboard test = new Knight("E4").GetMoveBoard();

            Bitboard expected = new Bitboard();
            expected = expected
                .Set(new Square("F6"))
                .Set(new Square("G5"))
                .Set(new Square("G3"))
                .Set(new Square("F2"))
                .Set(new Square("D2"))
                .Set(new Square("C3"))
                .Set(new Square("C5"))
                .Set(new Square("D6"));

            test.Should().Be(expected);
        }

        [Test]
        public void GetKnightAttacksBitboard_H4_ReturnsF3G2G6F5()
        {
            Bitboard test = new Knight("H4").GetMoveBoard();

            Bitboard expected = new Bitboard();
            expected = expected
                .Set(new Square("F3"))
                .Set(new Square("G2"))
                .Set(new Square("G6"))
                .Set(new Square("F5"));

            test.Should().Be(expected);
        }

        // ------------------------------------------------

        [Test]
        public void GetKnightAttacksBitboad_A1Bitboard_ReturnsC2andB3()
        {
            Bitboard test = new Knight("A1").GetMoveBoard();

            Bitboard expected = new Bitboard();
            expected = expected
                .Set(new Square("B3"))
                .Set(new Square("C2"));

            test.Should().Be(expected);
        }

        [Test]
        public void GetKnightAttacksBitboad_H1Bitboard_ReturnsF2andG3()
        {
            Bitboard test= new Knight("H1").GetMoveBoard();

            Bitboard expected = new Bitboard();
            expected = expected
                .Set(new Square("G3"))
                .Set(new Square("F2"));

            test.Should().Be(expected);
        }

        [Test]
        public void GetKnightAttacksBitboad_H8Bitboard_ReturnsF7andG6()
        {
            Bitboard test = new Knight("H8").GetMoveBoard();

            Bitboard expected = new Bitboard();
            expected = expected
                .Set(new Square("F7"))
                .Set(new Square("G6"));

            test.Should().Be(expected);
        }

        [Test]
        public void GetKnightAttacksBitboad_A8Bitboard_ReturnsC7andB6()
        {
            Bitboard test = new Knight("A8").GetMoveBoard();

            Bitboard expected = new Bitboard();
            expected = expected
                .Set(new Square("C7"))
                .Set(new Square("B6"));

            test.Should().Be(expected);
        }

        [Test]
        public void GetKnightAttacksBitboad_B1Bitboard_ReturnsA3andC3andD2()
        {
            Bitboard test = new Knight("B1").GetMoveBoard();

            Bitboard expected = new Bitboard();
            expected = expected
                .Set(new Square("A3"))
                .Set(new Square("C3"))
                .Set(new Square("D2"));

            test.Should().Be(expected);
        }

        [Test]
        public void GetKnightAttacksBitboad_G8Bitboard_ReturnsH6andF6andE7()
        {
            Bitboard test = new Knight("G8").GetMoveBoard();

            Assert.IsTrue(test.IsSet(new Square("H6")), "H6?!");
            Assert.IsTrue(test.IsSet(new Square("F6")), "F6?!");
            Assert.IsTrue(test.IsSet(new Square("E7")), "E7?!");
            Bitboard expected = new Bitboard();
            expected = expected
                .Set(new Square("H6"))
                .Set(new Square("F6"))
                .Set(new Square("E7"));

            test.Should().Be(expected);
        }

        [Test]
        public void GetKnightAttacksBitboad_E4Bitboard_ReturnsF6G5G3F2D2C3C5D6()
        {
            Bitboard test = new Knight("E4").GetMoveBoard();

            Bitboard expected = new Bitboard();
            expected = expected
                .Set(new Square("F6"))
                .Set(new Square("G5"))
                .Set(new Square("G3"))
                .Set(new Square("F2"))
                .Set(new Square("D2"))
                .Set(new Square("C3"))
                .Set(new Square("C5"))
                .Set(new Square("D6"));

            test.Should().Be(expected);
        }

        [Test]
        public void GetKnightAttacksBitboard_H4Bitboard_ReturnsF3G2G6F5()
        {
            Bitboard test = new Knight("H4").GetMoveBoard();

            Bitboard expected = new Bitboard();
            expected = expected
                .Set(new Square("F3"))
                .Set(new Square("G2"))
                .Set(new Square("G6"))
                .Set(new Square("F5"));

            test.Should().Be(expected);
        }

        //[Test]
        //public void GetKnightAttacksBitboard_B1C3Bitboard_ReturnsD2A3A2A4B5D5E4E2D1()
        //{
        //    Bitboard test = 0;
        //    test = test.Set(new Square("B1")).Set(new Square("C3"));
        //    test = new Knight(test, test);

        //    Bitboard expected = 0;
        //    expected = expected
        //        .Set(new Square("D2"))
        //        .Set(new Square("A3"))
        //        .Set(new Square("A2"))
        //        .Set(new Square("A4"))
        //        .Set(new Square("B5"))
        //        .Set(new Square("D5"))
        //        .Set(new Square("E4"))
        //        .Set(new Square("E2"))
        //        .Set(new Square("D1"));

        //    test.Should().Be(expected);
        //}

        //[Test]
        //public void
        //GetKnightAttacksBitboard_B1C3BitboardAndFriendsA4B5D5E4_ReturnsD2A3A2E2D1()
        //{
        //    Bitboard test = 0;
        //    test = test.Set(new Square("B1")).Set(new Square("C3"));

        //    var friends = test
        //        .Set(new Square("A4"))
        //        .Set(new Square("B5"))
        //        .Set(new Square("D5"))
        //        .Set(new Square("E4"));

        //    test = new Knight(test, friends);

        //    Bitboard expected = 0;
        //    expected = expected
        //        .Set(new Square("D2"))
        //        .Set(new Square("A3"))
        //        .Set(new Square("A2"))
        //        .Set(new Square("E2"))
        //        .Set(new Square("D1"));

        //    test.Should().Be(expected);
        //}
    }
}
