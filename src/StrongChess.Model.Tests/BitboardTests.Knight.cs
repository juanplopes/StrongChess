//using System;
//using System.Text;
//using System.Collections.Generic;
//using System.Linq;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

//namespace StrongChess.Model.Tests
//{
//    public partial class BitboardTests
//    {
//        [TestMethod]
//        public void GetKnightAttacksBitboad_A1_ReturnsC2andB3()
//        {
//            UInt64 test = Bitboard2.GetKnightAttacksBitboard
//                (Squares.A1);
            
//            UInt64 expected = 0;
//            expected = expected
//                .Set(Squares.B3)
//                .Set(Squares.C2);

//            Assert.AreEqual(expected, test);
//        }

//        [TestMethod]
//        public void GetKnightAttacksBitboad_H1_ReturnsF2andG3()
//        {
//            UInt64 test = Bitboard2.GetKnightAttacksBitboard
//                (Squares.H1);

//            UInt64 expected = 0;
//            expected = expected
//                .Set(Squares.G3)
//                .Set(Squares.F2);

//            Assert.AreEqual(expected, test);
//        }

//        [TestMethod]
//        public void GetKnightAttacksBitboad_H8_ReturnsF7andG6()
//        {
//            UInt64 test = Bitboard2.GetKnightAttacksBitboard
//                (Squares.H8);

//            UInt64 expected = 0;
//            expected = expected
//                .Set(Squares.F7)
//                .Set(Squares.G6);

//            Assert.AreEqual(expected, test);
//        }

//        [TestMethod]
//        public void GetKnightAttacksBitboad_A8_ReturnsC7andB6()
//        {
//            UInt64 test = Bitboard2.GetKnightAttacksBitboard
//                (Squares.A8);

//            UInt64 expected = 0;
//            expected = expected
//                .Set(Squares.C7)
//                .Set(Squares.B6);

//            Assert.AreEqual(expected, test);
//        }

//        [TestMethod]
//        public void GetKnightAttacksBitboad_B1_ReturnsA3andC3andD2()
//        {
//            UInt64 test = Bitboard2.GetKnightAttacksBitboard
//                (Squares.B1);

//            UInt64 expected = 0;
//            expected = expected
//                .Set(Squares.A3)
//                .Set(Squares.C3)
//                .Set(Squares.D2);

//            Assert.AreEqual(expected, test);
//        }

//        [TestMethod]
//        public void GetKnightAttacksBitboad_G8_ReturnsH6andF6andE7()
//        {
//            Bitboard test = Bitboard2.GetKnightAttacksBitboard
//                (Squares.G8);

//            Assert.IsTrue(test.IsSet(Squares.H6), "H6?!");
//            Assert.IsTrue(test.IsSet(Squares.F6), "F6?!");
//            Assert.IsTrue(test.IsSet(Squares.E7), "E7?!");
//            UInt64 expected = 0;
//            expected = expected
//                .Set(Squares.H6)
//                .Set(Squares.F6)
//                .Set(Squares.E7);

//            Assert.AreEqual(expected, test);
//        }

//        [TestMethod]
//        public void GetKnightAttacksBitboad_E4_ReturnsF6G5G3F2D2C3C5D6()
//        {
//            UInt64 test = Bitboard2.GetKnightAttacksBitboard
//                (Squares.E4);

//            UInt64 expected = 0;
//            expected = expected
//                .Set(Squares.F6)
//                .Set(Squares.G5)
//                .Set(Squares.G3)
//                .Set(Squares.F2)
//                .Set(Squares.D2)
//                .Set(Squares.C3)
//                .Set(Squares.C5)
//                .Set(Squares.D6);

//            Assert.AreEqual(expected, test);
//        }

//        [TestMethod]
//        public void GetKnightAttacksBitboard_H4_ReturnsF3G2G6F5()
//        {
//            UInt64 test = Bitboard2.GetKnightAttacksBitboard
//                (Squares.H4);

//            UInt64 expected = 0;
//            expected = expected
//                .Set(Squares.F3)
//                .Set(Squares.G2)
//                .Set(Squares.G6)
//                .Set(Squares.F5);

//            Assert.AreEqual(expected, test);
//        }

//        // ------------------------------------------------

//        [TestMethod]
//        public void GetKnightAttacksBitboad_A1Bitboard_ReturnsC2andB3()
//        {
//            UInt64 test = 0;
//            test = test.Set(Squares.A1);
//            test = Bitboard2.GetKnightAttacksBitboard(test, test);

//            UInt64 expected = 0;
//            expected = expected
//                .Set(Squares.B3)
//                .Set(Squares.C2);

//            Assert.AreEqual(expected, test);
//        }

//        [TestMethod]
//        public void GetKnightAttacksBitboad_H1Bitboard_ReturnsF2andG3()
//        {
//            UInt64 test = 0;
//            test = test.Set(Squares.H1);
//            test = Bitboard2.GetKnightAttacksBitboard(test, test);

//            UInt64 expected = 0;
//            expected = expected
//                .Set(Squares.G3)
//                .Set(Squares.F2);

//            Assert.AreEqual(expected, test);
//        }

//        [TestMethod]
//        public void GetKnightAttacksBitboad_H8Bitboard_ReturnsF7andG6()
//        {
//            UInt64 test = 0;
//            test = test.Set(Squares.H8);
//            test = Bitboard2.GetKnightAttacksBitboard(test, test);

//            UInt64 expected = 0;
//            expected = expected
//                .Set(Squares.F7)
//                .Set(Squares.G6);

//            Assert.AreEqual(expected, test);
//        }

//        [TestMethod]
//        public void GetKnightAttacksBitboad_A8Bitboard_ReturnsC7andB6()
//        {
//            UInt64 test = 0;
//            test = test.Set(Squares.A8);
//            test = Bitboard2.GetKnightAttacksBitboard(test, test);

//            UInt64 expected = 0;
//            expected = expected
//                .Set(Squares.C7)
//                .Set(Squares.B6);

//            Assert.AreEqual(expected, test);
//        }

//        [TestMethod]
//        public void GetKnightAttacksBitboad_B1Bitboard_ReturnsA3andC3andD2()
//        {
//            UInt64 test = 0;
//            test = test.Set(Squares.B1);
//            test = Bitboard2.GetKnightAttacksBitboard(test, test);

//            UInt64 expected = 0;
//            expected = expected
//                .Set(Squares.A3)
//                .Set(Squares.C3)
//                .Set(Squares.D2);

//            Assert.AreEqual(expected, test);
//        }

//        [TestMethod]
//        public void GetKnightAttacksBitboad_G8Bitboard_ReturnsH6andF6andE7()
//        {
//            UInt64 test = 0;
//            test = test.Set(Squares.G8);
//            test = Bitboard2.GetKnightAttacksBitboard(test, test);

//            Assert.IsTrue(test.IsSet(Squares.H6), "H6?!");
//            Assert.IsTrue(test.IsSet(Squares.F6), "F6?!");
//            Assert.IsTrue(test.IsSet(Squares.E7), "E7?!");
//            UInt64 expected = 0;
//            expected = expected
//                .Set(Squares.H6)
//                .Set(Squares.F6)
//                .Set(Squares.E7);

//            Assert.AreEqual(expected, test);
//        }

//        [TestMethod]
//        public void GetKnightAttacksBitboad_E4Bitboard_ReturnsF6G5G3F2D2C3C5D6()
//        {
//            UInt64 test = 0;
//            test = test.Set(Squares.E4);
//            test = Bitboard2.GetKnightAttacksBitboard(test, test);

//            UInt64 expected = 0;
//            expected = expected
//                .Set(Squares.F6)
//                .Set(Squares.G5)
//                .Set(Squares.G3)
//                .Set(Squares.F2)
//                .Set(Squares.D2)
//                .Set(Squares.C3)
//                .Set(Squares.C5)
//                .Set(Squares.D6);

//            Assert.AreEqual(expected, test);
//        }

//        [TestMethod]
//        public void GetKnightAttacksBitboard_H4Bitboard_ReturnsF3G2G6F5()
//        {
//            UInt64 test = 0;
//            test = test.Set(Squares.H4);
//            test = Bitboard2.GetKnightAttacksBitboard(test, test);

//            UInt64 expected = 0;
//            expected = expected
//                .Set(Squares.F3)
//                .Set(Squares.G2)
//                .Set(Squares.G6)
//                .Set(Squares.F5);

//            Assert.AreEqual(expected, test);
//        }

//        [TestMethod]
//        public void GetKnightAttacksBitboard_B1C3Bitboard_ReturnsD2A3A2A4B5D5E4E2D1()
//        {
//            UInt64 test = 0;
//            test = test.Set(Squares.B1).Set(Squares.C3);
//            test = Bitboard2.GetKnightAttacksBitboard(test, test);

//            UInt64 expected = 0;
//            expected = expected
//                .Set(Squares.D2)
//                .Set(Squares.A3)
//                .Set(Squares.A2)
//                .Set(Squares.A4)
//                .Set(Squares.B5)
//                .Set(Squares.D5)
//                .Set(Squares.E4)
//                .Set(Squares.E2)
//                .Set(Squares.D1);

//            Assert.AreEqual(expected, test);
//        }

//        [TestMethod]
//        public void 
//        GetKnightAttacksBitboard_B1C3BitboardAndFriendsA4B5D5E4_ReturnsD2A3A2E2D1()
//        {
//            UInt64 test = 0;
//            test = test.Set(Squares.B1).Set(Squares.C3);
            
//            var friends = test
//                .Set(Squares.A4)
//                .Set(Squares.B5)
//                .Set(Squares.D5)
//                .Set(Squares.E4);

//            test = Bitboard2.GetKnightAttacksBitboard(test, friends);

//            UInt64 expected = 0;
//            expected = expected
//                .Set(Squares.D2)
//                .Set(Squares.A3)
//                .Set(Squares.A2)
//                .Set(Squares.E2)
//                .Set(Squares.D1);

//            Assert.AreEqual(expected, test);
//        }
//    }
//}
