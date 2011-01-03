using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using StrongChess.Model;

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
            bitboard = bitboard.Set(Rank.FromName('2'));

            // assert
            Assert.IsTrue(bitboard.IsSet(Square.FromName("A2")), "a2 should be setted");
            Assert.IsTrue(bitboard.IsSet(Square.FromName("B2")), "b2 should be setted");
            Assert.IsTrue(bitboard.IsSet(Square.FromName("C2")), "c2 should be setted");
            Assert.IsTrue(bitboard.IsSet(Square.FromName("D2")), "d2 should be setted");
            Assert.IsTrue(bitboard.IsSet(Square.FromName("E2")), "e2 should be setted");
            Assert.IsTrue(bitboard.IsSet(Square.FromName("F2")), "f2 should be setted");
            Assert.IsTrue(bitboard.IsSet(Square.FromName("G2")), "g2 should be setted");
            Assert.IsTrue(bitboard.IsSet(Square.FromName("H2")), "h2 should be setted");
        }

        [TestMethod]
        public void Clear_D_SettedFileDAndE()
        {
            // arrange
            var bitboard = new Bitboard();

            // act
            bitboard = bitboard
                .Set(File.FromName('D'), File.FromName('E'));

            bitboard = bitboard.Clear(File.FromName('D'));

            // assert
            Assert.IsTrue(bitboard.IsClear(File.FromName('A')), "A should be clear");
            Assert.IsTrue(bitboard.IsClear(File.FromName('B')), "B should be clear");
            Assert.IsTrue(bitboard.IsClear(File.FromName('C')), "C should be clear");
            Assert.IsTrue(bitboard.IsClear(File.FromName('D')), "D should be clear");
            Assert.IsFalse(bitboard.IsClear(File.FromName('E')), "E should not be clear");
            Assert.IsTrue(bitboard.IsClear(File.FromName('F')), "F should be clear");
            Assert.IsTrue(bitboard.IsClear(File.FromName('G')), "G should be clear");
            Assert.IsTrue(bitboard.IsClear(File.FromName('H')), "H should be clear");
        }

        [TestMethod]
        public void Clear_5_SettedRank4And5()
        {
            // arrange
            var bitboard = new Bitboard();

            // act
            bitboard = bitboard
                .Set(Rank.FromName('4'))
                .Set(Rank.FromName('5'));

            bitboard = bitboard.Clear(Rank.FromName('5'));

            // assert
            Assert.IsTrue(bitboard.IsClear(Rank.FromName('1')), "1 should be clear");
            Assert.IsTrue(bitboard.IsClear(Rank.FromName('2')), "2 should be clear");
            Assert.IsTrue(bitboard.IsClear(Rank.FromName('3')), "3 should be clear");
            Assert.IsFalse(bitboard.IsClear(Rank.FromName('4')), "4 should be clear");
            Assert.IsTrue(bitboard.IsClear(Rank.FromName('5')), "5 should not be clear");
            Assert.IsTrue(bitboard.IsClear(Rank.FromName('6')), "6 should be clear");
            Assert.IsTrue(bitboard.IsClear(Rank.FromName('7')), "7 should be clear");
            Assert.IsTrue(bitboard.IsClear(Rank.FromName('8')), "8 should be clear");
        }

        [TestMethod]
        public void Set_FileE()
        {
            // arrange
            var bitboard = new Bitboard();

            // act
            bitboard = bitboard.Set(File.FromName('E'));

            // assert
            Assert.IsTrue(bitboard.IsSet(Square.FromName("E1")), "e1 should be setted");
            Assert.IsTrue(bitboard.IsSet(Square.FromName("E2")), "e2 should be setted");
            Assert.IsTrue(bitboard.IsSet(Square.FromName("E3")), "e3 should be setted");
            Assert.IsTrue(bitboard.IsSet(Square.FromName("E4")), "e4 should be setted");
            Assert.IsTrue(bitboard.IsSet(Square.FromName("E5")), "e5 should be setted");
            Assert.IsTrue(bitboard.IsSet(Square.FromName("E6")), "e6 should be setted");
            Assert.IsTrue(bitboard.IsSet(Square.FromName("E7")), "e7 should be setted");
            Assert.IsTrue(bitboard.IsSet(Square.FromName("E8")), "e8 should be setted");
        }

        [TestMethod]
        public void Set_A1()
        {
            // arrange
            var bitboard = new Bitboard();
            Bitboard bitboard1;
            Bitboard bitboard2;

            // act
            bitboard1 = bitboard.Set(Square.FromName("A1"));
            bitboard2 = bitboard1.Clear(Square.FromName("A1"));

            // assert
            Assert.AreEqual(((UInt64)1 << (int)Square.FromName("A1")), bitboard1.Value);
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
            bitboard1 = bitboard = bitboard.Set(Square.FromName("A1"));
            bitboard2 = bitboard1.Clear(Square.FromName("A1"));

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
            bitboard1 = bitboard = bitboard.Set(Square.FromName("A1"));
            bitboard2 = bitboard1.Clear(Square.FromName("A1"));

            // assert
            Assert.IsTrue(bitboard1.IsSet(Square.FromName("A1")));
            Assert.IsFalse(bitboard2.IsSet(Square.FromName("A1")));
        }

        [TestMethod]
        public void IsClear_SettedA1_ReturnsFalse()
        {
            // arrange
            var bitboard = new Bitboard();
            Bitboard bitboard1;
            Bitboard bitboard2;

            // act
            bitboard1 = bitboard = bitboard.Set(Square.FromName("A1"));
            bitboard2 = bitboard1.Clear(Square.FromName("A1"));

            // assert
            Assert.IsFalse(bitboard1.IsClear(Square.FromName("A1")), "Should return False!");
            Assert.IsTrue(bitboard2.IsClear(Square.FromName("A1")), "Should return true!");
        }

        [TestMethod]
        public void Set_F5()
        {
            // arrange
            var bitboard = new Bitboard();
            Bitboard bitboard1;
            Bitboard bitboard2;

            // act
            bitboard1 = bitboard = bitboard.Set(Square.FromName("F5"));
            bitboard2 = bitboard1.Clear(Square.FromName("F5"));

            // assert
            Assert.AreEqual(((UInt64)1 << (int)Square.FromName("F5")), bitboard1.Value);
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
            bitboard1 = bitboard = bitboard.Set(Square.FromName("F5"));
            bitboard2 = bitboard1.Clear(Square.FromName("F5"));

            // assert
            //Assert.AreEqual(((long)1 << (int)Square.FromName("F5")), bitboard1);
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
            bitboard1 = bitboard = bitboard.Set(Square.FromName("F5"));
            bitboard2 = bitboard1.Clear(Square.FromName("F5"));

            // assert
            Assert.IsTrue(bitboard1.IsSet(Square.FromName("F5")));
            Assert.IsFalse(bitboard2.IsSet(Square.FromName("F5")));
        }

        [TestMethod]
        public void IsClear_SettedF5_ReturnsFalse()
        {
            // arrange
            var bitboard = new Bitboard();
            Bitboard bitboard1;
            Bitboard bitboard2;

            // act
            bitboard1 = bitboard = bitboard.Set(Square.FromName("F5"));
            bitboard2 = bitboard1.Clear(Square.FromName("F5"));

            // assert
            Assert.IsFalse(bitboard1.IsClear(Square.FromName("F5")));
            Assert.IsTrue(bitboard2.IsClear(Square.FromName("F5")));
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
                   .Set(Square.FromName("F5"))
                   .Set(Square.FromName("A1"));

            bitboard2 = bitboard1.Clear(Square.FromName("A1"));

            // assert
            Assert.IsFalse(bitboard1.IsClear(Square.FromName("A1")));
            Assert.IsTrue(bitboard2.IsClear(Square.FromName("A1")));
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
                   .Set(Square.FromName("F5"))
                   .Set(Square.FromName("A1"));

            bitboard2 = bitboard1.Clear(Square.FromName("A1"));

            // assert
            Assert.IsFalse(bitboard1.IsClear(Square.FromName("F5")));
            Assert.IsFalse(bitboard2.IsClear(Square.FromName("F5")));
        }



        [TestMethod]
        public void GetLeadingSquare_SettedA1_ReturnsA1()
        {
            // arrange
            var bitboard = new Bitboard();
            bitboard = bitboard.Set(Square.FromName("A1"));

            // act
            var result = bitboard.LeadingSquare;

            // assert
            Assert.AreEqual(Square.FromName("A1"), result);
        }

        [TestMethod]
        public void GetLeadingSquare_SettedB1_ReturnsB1()
        {
            // arrange
            var bitboard = new Bitboard();
            bitboard = bitboard.Set(Square.FromName("B1"));

            // act
            var result = bitboard.LeadingSquare;

            // assert
            Assert.AreEqual(Square.FromName("B1"), result);
        }

        [TestMethod]
        public void GetLeadingSquare_SettedA1andB1_ReturnsB1()
        {
            // arrange
            var bitboard = new Bitboard();
            bitboard = bitboard.Set(Square.FromName("A1"), Square.FromName("B1"));

            // act
            var result = bitboard.LeadingSquare;

            // assert
            Assert.AreEqual(Square.FromName("B1"), result);
        }

        [TestMethod]
        public void GetLeadingSquare_SettedA1andH2_ReturnsH2()
        {
            // arrange
            var bitboard = new Bitboard();
            bitboard = bitboard
                .Set(Square.FromName("A1"))
                .Set(Square.FromName("H2"));

            // act
            var result = bitboard.LeadingSquare;

            // assert
            Assert.AreEqual(Square.FromName("H2"), result);
        }

        [TestMethod]
        public void GetLeadingSquare_SettedH2andA3_ReturnsA3()
        {
            // arrange
            var bitboard = new Bitboard();
            bitboard = bitboard
                .Set(Square.FromName("A3"))
                .Set(Square.FromName("H2"));

            // act
            var result = bitboard.LeadingSquare;

            // assert
            Assert.AreEqual(Square.FromName("A3"), result);
        }

        [TestMethod]
        public void GetLeadingSquare_SettedH4andA5_ReturnsA5()
        {
            // arrange
            var bitboard = new Bitboard();
            bitboard = bitboard
                .Set(Square.FromName("A5"))
                .Set(Square.FromName("H4"));

            // act
            var result = bitboard.LeadingSquare;

            // assert
            Assert.AreEqual(Square.FromName("A5"), result);
        }

        [TestMethod]
        public void GetLeadingSquare_SettedH6andA7andE8_ReturnsE8()
        {
            // arrange
            var bitboard = new Bitboard();
            bitboard = bitboard
                .Set(Square.FromName("A7"))
                .Set(Square.FromName("E8"))
                .Set(Square.FromName("H6"));

            // act
            var result = bitboard.LeadingSquare;

            // assert
            Assert.AreEqual(Square.FromName("E8"), result);
        }

        [TestMethod]
        public void GetLeadingSquare_SettedD5andA1_ReturnsD5()
        {
            // arrange
            var bitboard = new Bitboard();
            bitboard = bitboard
                .Set(Square.FromName("A1"))
                .Set(Square.FromName("D5"));

            // act
            var result = bitboard.LeadingSquare;

            // assert
            Assert.AreEqual(Square.FromName("D5"), result);
        }


        [TestMethod]
        public void GetLeadingSquare_EverySquareReverse()
        {

            for (int i = 63; i >= 0; i--)
            {
                var bitboard = new Bitboard();
                var sq = Square.FromIndex(i);
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
                var sq = Square.FromIndex(i);
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
                var sq = Square.FromIndex(i);
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
                var sq = Square.FromIndex(i);
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
                .Set(Square.FromName("A1"))
                .Set(Square.FromName("D5"));

            // act
            var result = bitboard.BitCount;

            // assert
            Assert.AreEqual(2, result);
        }


    }
}
