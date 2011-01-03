using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using StrongChess.Model;
using System.Runtime.InteropServices;

namespace StrongChess.Model.Tests
{
    [TestClass]
    public class BitboardTests
    {

        [TestMethod]
        public void Set_Rank2()
        {
            var bitboard = new Bitboard();

            // act
            bitboard = bitboard.Set(new Rank("2"));

            // assert
            Assert.IsTrue(bitboard.IsSet(new Square("A2")), "a2 should be setted");
            Assert.IsTrue(bitboard.IsSet(new Square("B2")), "b2 should be setted");
            Assert.IsTrue(bitboard.IsSet(new Square("C2")), "c2 should be setted");
            Assert.IsTrue(bitboard.IsSet(new Square("D2")), "d2 should be setted");
            Assert.IsTrue(bitboard.IsSet(new Square("E2")), "e2 should be setted");
            Assert.IsTrue(bitboard.IsSet(new Square("F2")), "f2 should be setted");
            Assert.IsTrue(bitboard.IsSet(new Square("G2")), "g2 should be setted");
            Assert.IsTrue(bitboard.IsSet(new Square("H2")), "h2 should be setted");
        }

        [TestMethod]
        public void Clear_D_SettedFileDAndE()
        {
            // arrange
            var bitboard = new Bitboard();

            // act
            bitboard = bitboard
                .Set(new File("D"), new File("E"));

            bitboard = bitboard.Clear(new File("D"));

            // assert
            Assert.IsTrue(bitboard.IsClear(new File("A")), "A should be clear");
            Assert.IsTrue(bitboard.IsClear(new File("B")), "B should be clear");
            Assert.IsTrue(bitboard.IsClear(new File("C")), "C should be clear");
            Assert.IsTrue(bitboard.IsClear(new File("D")), "D should be clear");
            Assert.IsFalse(bitboard.IsClear(new File("E")), "E should not be clear");
            Assert.IsTrue(bitboard.IsClear(new File("F")), "F should be clear");
            Assert.IsTrue(bitboard.IsClear(new File("G")), "G should be clear");
            Assert.IsTrue(bitboard.IsClear(new File("H")), "H should be clear");
        }

        [TestMethod]
        public void Clear_5_SettedRank4And5()
        {
            // arrange
            var bitboard = new Bitboard();

            // act
            bitboard = bitboard
                .Set(new Rank("4"))
                .Set(new Rank("5"));

            bitboard = bitboard.Clear(new Rank("5"));

            // assert
            Assert.IsTrue(bitboard.IsClear(new Rank("1")), "1 should be clear");
            Assert.IsTrue(bitboard.IsClear(new Rank("2")), "2 should be clear");
            Assert.IsTrue(bitboard.IsClear(new Rank("3")), "3 should be clear");
            Assert.IsFalse(bitboard.IsClear(new Rank("4")), "4 should be clear");
            Assert.IsTrue(bitboard.IsClear(new Rank("5")), "5 should not be clear");
            Assert.IsTrue(bitboard.IsClear(new Rank("6")), "6 should be clear");
            Assert.IsTrue(bitboard.IsClear(new Rank("7")), "7 should be clear");
            Assert.IsTrue(bitboard.IsClear(new Rank("8")), "8 should be clear");
        }

        [TestMethod]
        public void Set_FileE()
        {
            // arrange
            var bitboard = new Bitboard();

            // act
            bitboard = bitboard.Set(new File("E"));

            // assert
            Assert.IsTrue(bitboard.IsSet(new Square("E1")), "e1 should be setted");
            Assert.IsTrue(bitboard.IsSet(new Square("E2")), "e2 should be setted");
            Assert.IsTrue(bitboard.IsSet(new Square("E3")), "e3 should be setted");
            Assert.IsTrue(bitboard.IsSet(new Square("E4")), "e4 should be setted");
            Assert.IsTrue(bitboard.IsSet(new Square("E5")), "e5 should be setted");
            Assert.IsTrue(bitboard.IsSet(new Square("E6")), "e6 should be setted");
            Assert.IsTrue(bitboard.IsSet(new Square("E7")), "e7 should be setted");
            Assert.IsTrue(bitboard.IsSet(new Square("E8")), "e8 should be setted");
        }

        [TestMethod]
        public void Set_A1()
        {
            // arrange
            var bitboard = new Bitboard();
            Bitboard bitboard1;
            Bitboard bitboard2;

            // act
            bitboard1 = bitboard.Set(new Square("A1"));
            bitboard2 = bitboard1.Clear(new Square("A1"));

            // assert
            Assert.AreEqual(((UInt64)1 << (int)new Square("A1")), bitboard1.Value);
            //Assert.AreEqual(0, bitboard2);
        }

        [TestMethod]
        public void Clear_A1()
        {
            // arrange
            var bitboard = new Bitboard();
            Bitboard bitboard1;
            Bitboard bitboard2;

            // act
            bitboard1 = bitboard = bitboard.Set(new Square("A1"));
            bitboard2 = bitboard1.Clear(new Square("A1"));

            // assert
            Assert.AreEqual((UInt64)0, bitboard2.Value);
        }

        [TestMethod]
        public void IsSet_SettedA1_ReturnsTrue()
        {
            // arrange
            var bitboard = new Bitboard();
            Bitboard bitboard1;
            Bitboard bitboard2;

            // act
            bitboard1 = bitboard = bitboard.Set(new Square("A1"));
            bitboard2 = bitboard1.Clear(new Square("A1"));

            // assert
            Assert.IsTrue(bitboard1.IsSet(new Square("A1")));
            Assert.IsFalse(bitboard2.IsSet(new Square("A1")));
        }

        [TestMethod]
        public void IsClear_SettedA1_ReturnsFalse()
        {
            // arrange
            var bitboard = new Bitboard();
            Bitboard bitboard1;
            Bitboard bitboard2;

            // act
            bitboard1 = bitboard = bitboard.Set(new Square("A1"));
            bitboard2 = bitboard1.Clear(new Square("A1"));

            // assert
            Assert.IsFalse(bitboard1.IsClear(new Square("A1")), "Should return False!");
            Assert.IsTrue(bitboard2.IsClear(new Square("A1")), "Should return true!");
        }

        [TestMethod]
        public void Set_F5()
        {
            // arrange
            var bitboard = new Bitboard();
            Bitboard bitboard1;
            Bitboard bitboard2;

            // act
            bitboard1 = bitboard = bitboard.Set(new Square("F5"));
            bitboard2 = bitboard1.Clear(new Square("F5"));

            // assert
            Assert.AreEqual(((UInt64)1 << (int)new Square("F5")), bitboard1.Value);
            //Assert.AreEqual(0, bitboard2);
        }

        [TestMethod]
        public void Clear_F5()
        {
            // arrange
            var bitboard = new Bitboard();
            Bitboard bitboard1;
            Bitboard bitboard2;

            // act
            bitboard1 = bitboard = bitboard.Set(new Square("F5"));
            bitboard2 = bitboard1.Clear(new Square("F5"));

            // assert
            //Assert.AreEqual(((long)1 << (int)new Square("F5")), bitboard1);
            Assert.AreEqual((UInt64)0, bitboard2.Value);
        }

        [TestMethod]
        public void IsSet_SettedF5_ReturnsTrue()
        {
            // arrange
            var bitboard = new Bitboard();
            Bitboard bitboard1;
            Bitboard bitboard2;

            // act
            bitboard1 = bitboard = bitboard.Set(new Square("F5"));
            bitboard2 = bitboard1.Clear(new Square("F5"));

            // assert
            Assert.IsTrue(bitboard1.IsSet(new Square("F5")));
            Assert.IsFalse(bitboard2.IsSet(new Square("F5")));
        }

        [TestMethod]
        public void IsClear_SettedF5_ReturnsFalse()
        {
            // arrange
            var bitboard = new Bitboard();
            Bitboard bitboard1;
            Bitboard bitboard2;

            // act
            bitboard1 = bitboard = bitboard.Set(new Square("F5"));
            bitboard2 = bitboard1.Clear(new Square("F5"));

            // assert
            Assert.IsFalse(bitboard1.IsClear(new Square("F5")));
            Assert.IsTrue(bitboard2.IsClear(new Square("F5")));
        }

        [TestMethod]
        public void IsClear_A1_SettedF5A1ClearingA1_ReturnsTrue()
        {
            // arrange
            var bitboard = new Bitboard();
            Bitboard bitboard1;
            Bitboard bitboard2;

            // act
            bitboard1 = bitboard
                   .Set(new Square("F5"))
                   .Set(new Square("A1"));

            bitboard2 = bitboard1.Clear(new Square("A1"));

            // assert
            Assert.IsFalse(bitboard1.IsClear(new Square("A1")));
            Assert.IsTrue(bitboard2.IsClear(new Square("A1")));
        }

        [TestMethod]
        public void IsClear_F5_SettedF5A1ClearingA1_ReturnsFalse()
        {
            // arrange
            var bitboard = new Bitboard();
            Bitboard bitboard1;
            Bitboard bitboard2;

            // act
            bitboard1 = bitboard
                   .Set(new Square("F5"))
                   .Set(new Square("A1"));

            bitboard2 = bitboard1.Clear(new Square("A1"));

            // assert
            Assert.IsFalse(bitboard1.IsClear(new Square("F5")));
            Assert.IsFalse(bitboard2.IsClear(new Square("F5")));
        }



        [TestMethod]
        public void GetLeadingSquare_SettedA1_ReturnsA1()
        {
            // arrange
            var bitboard = new Bitboard();
            bitboard = bitboard.Set(new Square("A1"));

            // act
            var result = bitboard.LeadingSquare;

            // assert
            Assert.AreEqual(new Square("A1"), result);
        }

        [TestMethod]
        public void GetLeadingSquare_SettedB1_ReturnsB1()
        {
            // arrange
            var bitboard = new Bitboard();
            bitboard = bitboard.Set(new Square("B1"));

            // act
            var result = bitboard.LeadingSquare;

            // assert
            Assert.AreEqual(new Square("B1"), result);
        }

        [TestMethod]
        public void GetLeadingSquare_SettedA1andB1_ReturnsB1()
        {
            // arrange
            var bitboard = new Bitboard();
            bitboard = bitboard.Set(new Square("A1"), new Square("B1"));

            // act
            var result = bitboard.LeadingSquare;

            // assert
            Assert.AreEqual(new Square("B1"), result);
        }

        [TestMethod]
        public void GetLeadingSquare_SettedA1andH2_ReturnsH2()
        {
            // arrange
            var bitboard = new Bitboard();
            bitboard = bitboard
                .Set(new Square("A1"))
                .Set(new Square("H2"));

            // act
            var result = bitboard.LeadingSquare;

            // assert
            Assert.AreEqual(new Square("H2"), result);
        }

        [TestMethod]
        public void GetLeadingSquare_SettedH2andA3_ReturnsA3()
        {
            // arrange
            var bitboard = new Bitboard();
            bitboard = bitboard
                .Set(new Square("A3"))
                .Set(new Square("H2"));

            // act
            var result = bitboard.LeadingSquare;

            // assert
            Assert.AreEqual(new Square("A3"), result);
        }

        [TestMethod]
        public void GetLeadingSquare_SettedH4andA5_ReturnsA5()
        {
            // arrange
            var bitboard = new Bitboard();
            bitboard = bitboard
                .Set(new Square("A5"))
                .Set(new Square("H4"));

            // act
            var result = bitboard.LeadingSquare;

            // assert
            Assert.AreEqual(new Square("A5"), result);
        }

        [TestMethod]
        public void GetLeadingSquare_SettedH6andA7andE8_ReturnsE8()
        {
            // arrange
            var bitboard = new Bitboard();
            bitboard = bitboard
                .Set(new Square("A7"))
                .Set(new Square("E8"))
                .Set(new Square("H6"));

            // act
            var result = bitboard.LeadingSquare;

            // assert
            Assert.AreEqual(new Square("E8"), result);
        }

        [TestMethod]
        public void GetLeadingSquare_SettedD5andA1_ReturnsD5()
        {
            // arrange
            var bitboard = new Bitboard();
            bitboard = bitboard
                .Set(new Square("A1"))
                .Set(new Square("D5"));

            // act
            var result = bitboard.LeadingSquare;

            // assert
            Assert.AreEqual(new Square("D5"), result);
        }


        [TestMethod]
        public void GetLeadingSquare_EverySquareReverse()
        {

            for (int i = 63; i >= 0; i--)
            {
                var bitboard = new Bitboard();
                var sq = new Square(i);
                bitboard = bitboard.Set(sq);
                Assert.AreEqual(sq, bitboard.LeadingSquare);
            }
        }

        [TestMethod]
        public void GetLeadingSquare_Empty_ReturnsINVALID()
        {
            // arrange
            var bitboard = new Bitboard();

            // act
            var result = bitboard.LeadingSquare;

            // assert
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        public void GetLeadingSquare_EverySquare()
        {
            var bitboard = new Bitboard();
            for (int i = 0; i < 64; i++)
            {
                var sq = new Square(i);
                bitboard = bitboard.Set(sq);
                Assert.AreEqual(sq, bitboard.LeadingSquare);
            }
        }


        [TestMethod]
        public void GetBitCount_EverySquare()
        {
            var bitboard = new Bitboard();
            for (int i = 0; i < 64; i++)
            {
                var sq = new Square(i);
                bitboard = bitboard.Set(sq);
                Assert.AreEqual(i + 1, bitboard.BitCount, string.Format("Índice = {0}", i));
            }
        }

        [TestMethod]
        public void GetBitCount_EverySquareReverse()
        {
            var bitboard = new Bitboard();
            for (int i = 63; i >= 0; i--)
            {
                var sq = new Square(i);
                bitboard = bitboard.Set(sq);
                Assert.AreEqual(64 - i, bitboard.BitCount);
            }
        }

        [TestMethod]
        public void GetBitCount_SettedD5andA1_Returns2()
        {
            // arrange
            var bitboard = new Bitboard();
            bitboard = bitboard
                .Set(new Square("A1"))
                .Set(new Square("D5"));

            // act
            var result = bitboard.BitCount;

            // assert
            Assert.AreEqual(2, result);
        }


    }
}
