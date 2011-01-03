using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using StrongChess.Model;

namespace StrongChess.Model.Tests
{
    [TestClass]
    public partial class BitboardTests
    {
        
        [TestMethod]
        public void Set_Rank2()
        {
            // arrange
            UInt64 bitboard = 0;

            // act
            bitboard = bitboard.Set(Ranks.Rank2);

            // assert
            Assert.IsTrue(bitboard.IsSet(Squares.A2), "a2 should be setted");
            Assert.IsTrue(bitboard.IsSet(Squares.B2), "b2 should be setted");
            Assert.IsTrue(bitboard.IsSet(Squares.C2), "c2 should be setted");
            Assert.IsTrue(bitboard.IsSet(Squares.D2), "d2 should be setted");
            Assert.IsTrue(bitboard.IsSet(Squares.E2), "e2 should be setted");
            Assert.IsTrue(bitboard.IsSet(Squares.F2), "f2 should be setted");
            Assert.IsTrue(bitboard.IsSet(Squares.G2), "g2 should be setted");
            Assert.IsTrue(bitboard.IsSet(Squares.H2), "h2 should be setted");
        }
        [TestMethod]
        public void IsClear_SettedRank2_Rank2ReturnsFalse()
        {
            // arrange
            UInt64 bitboard = 0;

            // act
            bitboard = bitboard.Set(Ranks.Rank2);

            // assert
            Assert.IsTrue(bitboard.IsClear(Ranks.Rank1), "Rank1 should be clear");
            Assert.IsFalse(bitboard.IsClear(Ranks.Rank2), "Rank2 should not be clear");
            Assert.IsTrue(bitboard.IsClear(Ranks.Rank3), "Rank3 should be clear");
            Assert.IsTrue(bitboard.IsClear(Ranks.Rank4), "Rank4 should be clear");
            Assert.IsTrue(bitboard.IsClear(Ranks.Rank5), "Rank5 should be clear");
            Assert.IsTrue(bitboard.IsClear(Ranks.Rank6), "Rank6 should be clear");
            Assert.IsTrue(bitboard.IsClear(Ranks.Rank7), "Rank7 should be clear");
            Assert.IsTrue(bitboard.IsClear(Ranks.Rank8), "Rank8 should be clear");
        }

        [TestMethod]
        public void Clear_D_SettedFileDAndE()
        {
            // arrange
            UInt64 bitboard = 0;

            // act
            bitboard = bitboard
                .Set(Files.FileD)
                .Set(Files.FileE);

            bitboard = bitboard.Clear(Files.FileD);

            // assert
            Assert.IsTrue(bitboard.IsClear(Files.FileA), "A should be clear");
            Assert.IsTrue(bitboard.IsClear(Files.FileB), "B should be clear");
            Assert.IsTrue(bitboard.IsClear(Files.FileC), "C should be clear");
            Assert.IsTrue(bitboard.IsClear(Files.FileD), "D should be clear");
            Assert.IsFalse(bitboard.IsClear(Files.FileE), "E should not be clear");
            Assert.IsTrue(bitboard.IsClear(Files.FileF), "F should be clear");
            Assert.IsTrue(bitboard.IsClear(Files.FileG), "G should be clear");
            Assert.IsTrue(bitboard.IsClear(Files.FileH), "H should be clear");
        }

        [TestMethod]
        public void Clear_5_SettedRank4And5()
        {
            // arrange
            UInt64 bitboard = 0;

            // act
            bitboard = bitboard
                .Set(Ranks.Rank4)
                .Set(Ranks.Rank5);

            bitboard = bitboard.Clear(Ranks.Rank5);

            // assert
            Assert.IsTrue(bitboard.IsClear(Ranks.Rank1), "1 should be clear");
            Assert.IsTrue(bitboard.IsClear(Ranks.Rank2), "2 should be clear");
            Assert.IsTrue(bitboard.IsClear(Ranks.Rank3), "3 should be clear");
            Assert.IsFalse(bitboard.IsClear(Ranks.Rank4), "4 should be clear");
            Assert.IsTrue(bitboard.IsClear(Ranks.Rank5), "5 should not be clear");
            Assert.IsTrue(bitboard.IsClear(Ranks.Rank6), "6 should be clear");
            Assert.IsTrue(bitboard.IsClear(Ranks.Rank7), "7 should be clear");
            Assert.IsTrue(bitboard.IsClear(Ranks.Rank8), "8 should be clear");
        }

        [TestMethod]
        public void Set_FileE()
        {
            // arrange
            UInt64 bitboard = 0;

            // act
            bitboard = bitboard.Set(Files.FileE);

            // assert
            Assert.IsTrue(bitboard.IsSet(Squares.E1), "e1 should be setted");
            Assert.IsTrue(bitboard.IsSet(Squares.E2), "e2 should be setted");
            Assert.IsTrue(bitboard.IsSet(Squares.E3), "e3 should be setted");
            Assert.IsTrue(bitboard.IsSet(Squares.E4), "e4 should be setted");
            Assert.IsTrue(bitboard.IsSet(Squares.E5), "e5 should be setted");
            Assert.IsTrue(bitboard.IsSet(Squares.E6), "e6 should be setted");
            Assert.IsTrue(bitboard.IsSet(Squares.E7), "e7 should be setted");
            Assert.IsTrue(bitboard.IsSet(Squares.E8), "e8 should be setted");
        }
        
        [TestMethod]
        public void Set_A1()
        {
            // arrange
            UInt64 bitboard = 0;
            UInt64 bitboard1;
            UInt64 bitboard2;

            // act
            bitboard1 = bitboard.Set(Squares.A1);
            bitboard2 = bitboard1.Clear(Squares.A1);
            
            // assert
            Assert.AreEqual(((UInt64)1 << (int)Squares.A1), bitboard1);
            //Assert.AreEqual(0, bitboard2);
        }

        [TestMethod]
        public void Clear_A1()
        {
            // arrange
            UInt64 bitboard = 0;
            UInt64 bitboard1;
            UInt64 bitboard2;

            // act
            bitboard1 = bitboard.Set(Squares.A1);
            bitboard2 = bitboard1.Clear(Squares.A1);

            // assert
            Assert.AreEqual((UInt64)0, bitboard2);
        }

        [TestMethod]
        public void IsSet_SettedA1_ReturnsTrue()
        {
            // arrange
            UInt64 bitboard = 0;
            UInt64 bitboard1;
            UInt64 bitboard2;

            // act
            bitboard1 = bitboard.Set(Squares.A1);
            bitboard2 = bitboard1.Clear(Squares.A1);

            // assert
            Assert.IsTrue(bitboard1.IsSet(Squares.A1));
            Assert.IsFalse(bitboard2.IsSet(Squares.A1));
        }

        [TestMethod]
        public void IsClear_SettedA1_ReturnsFalse()
        {
            // arrange
            UInt64 bitboard = 0;
            UInt64 bitboard1;
            UInt64 bitboard2;

            // act
            bitboard1 = bitboard.Set(Squares.A1);
            bitboard2 = bitboard1.Clear(Squares.A1);

            // assert
            Assert.IsFalse(bitboard1.IsClear(Squares.A1), "Should return False!");
            Assert.IsTrue(bitboard2.IsClear(Squares.A1), "Should return true!");
        }

        [TestMethod]
        public void Set_F5()
        {
            // arrange
            UInt64 bitboard = 0;
            UInt64 bitboard1;
            UInt64 bitboard2;

            // act
            bitboard1 = bitboard.Set(Squares.F5);
            bitboard2 = bitboard1.Clear(Squares.F5);

            // assert
            Assert.AreEqual(((UInt64)1 << (int)Squares.F5), bitboard1);
            //Assert.AreEqual(0, bitboard2);
        }

        [TestMethod]
        public void Clear_F5()
        {
            // arrange
            UInt64 bitboard = 0;
            UInt64 bitboard1;
            UInt64 bitboard2;

            // act
            bitboard1 = bitboard.Set(Squares.F5);
            bitboard2 = bitboard1.Clear(Squares.F5);

            // assert
            //Assert.AreEqual(((long)1 << (int)Squares.F5), bitboard1);
            Assert.AreEqual((UInt64)0, bitboard2);
        }

        [TestMethod]
        public void IsSet_SettedF5_ReturnsTrue()
        {
            // arrange
            UInt64 bitboard = 0;
            UInt64 bitboard1;
            UInt64 bitboard2;

            // act
            bitboard1 = bitboard.Set(Squares.F5);
            bitboard2 = bitboard1.Clear(Squares.F5);

            // assert
            Assert.IsTrue(bitboard1.IsSet(Squares.F5));
            Assert.IsFalse(bitboard2.IsSet(Squares.F5));
        }

        [TestMethod]
        public void IsClear_SettedF5_ReturnsFalse()
        {
            // arrange
            UInt64 bitboard = 0;
            UInt64 bitboard1;
            UInt64 bitboard2;

            // act
            bitboard1 = bitboard.Set(Squares.F5);
            bitboard2 = bitboard1.Clear(Squares.F5);

            // assert
            Assert.IsFalse(bitboard1.IsClear(Squares.F5));
            Assert.IsTrue(bitboard2.IsClear(Squares.F5));
        }

        [TestMethod]
        public void IsClear_A1_SettedF5A1ClearingA1_ReturnsTrue()
        {
            // arrange
            UInt64 bitboard = 0;
            UInt64 bitboard1;
            UInt64 bitboard2;

            // act
            bitboard1 = bitboard
                   .Set(Squares.F5)
                   .Set(Squares.A1);
                        
            bitboard2 = bitboard1.Clear(Squares.A1);

            // assert
            Assert.IsFalse(bitboard1.IsClear(Squares.A1));
            Assert.IsTrue(bitboard2.IsClear(Squares.A1));
        }

        [TestMethod]
        public void IsClear_F5_SettedF5A1ClearingA1_ReturnsFalse()
        {
            // arrange
            UInt64 bitboard = 0;
            UInt64 bitboard1;
            UInt64 bitboard2;

            // act
            bitboard1 = bitboard
                   .Set(Squares.F5)
                   .Set(Squares.A1);

            bitboard2 = bitboard1.Clear(Squares.A1);

            // assert
            Assert.IsFalse(bitboard1.IsClear(Squares.F5));
            Assert.IsFalse(bitboard2.IsClear(Squares.F5));
        }

        
        
        [TestMethod]
        public void GetLeadingSquare_SettedA1_ReturnsA1()
        {
            // arrange
            UInt64 bitboard = 0;
            bitboard = bitboard.Set(Squares.A1);

            // act
            var result = bitboard.GetLeadingSquare();

            // assert
            Assert.AreEqual(Squares.A1, result);
        }

        [TestMethod]
        public void GetLeadingSquare_SettedB1_ReturnsB1()
        {
            // arrange
            UInt64 bitboard = 0;
            bitboard = bitboard.Set(Squares.B1);

            // act
            var result = bitboard.GetLeadingSquare();

            // assert
            Assert.AreEqual(Squares.B1, result);
        }

        [TestMethod]
        public void GetLeadingSquare_SettedA1andB1_ReturnsB1()
        {
            // arrange
            UInt64 bitboard = 0;
            bitboard = bitboard.Set(Squares.B1);

            // act
            var result = bitboard.GetLeadingSquare();

            // assert
            Assert.AreEqual(Squares.B1, result);
        }

        [TestMethod]
        public void GetLeadingSquare_SettedA1andH2_ReturnsH2()
        {
            // arrange
            UInt64 bitboard = 0;
            bitboard = bitboard
                .Set(Squares.A1)
                .Set(Squares.H2);

            // act
            var result = bitboard.GetLeadingSquare();

            // assert
            Assert.AreEqual(Squares.H2, result);
        }

        [TestMethod]
        public void GetLeadingSquare_SettedH2andA3_ReturnsA3()
        {
            // arrange
            UInt64 bitboard = 0;
            bitboard = bitboard
                .Set(Squares.A3)
                .Set(Squares.H2);

            // act
            var result = bitboard.GetLeadingSquare();

            // assert
            Assert.AreEqual(Squares.A3, result);
        }

        [TestMethod]
        public void GetLeadingSquare_SettedH4andA5_ReturnsA5()
        {
            // arrange
            UInt64 bitboard = 0;
            bitboard = bitboard
                .Set(Squares.A5)
                .Set(Squares.H4);

            // act
            var result = bitboard.GetLeadingSquare();

            // assert
            Assert.AreEqual(Squares.A5, result);
        }

        [TestMethod]
        public void GetLeadingSquare_SettedH6andA7andE8_ReturnsE8()
        {
            // arrange
            UInt64 bitboard = 0;
            bitboard = bitboard
                .Set(Squares.A7)
                .Set(Squares.E8)
                .Set(Squares.H6);

            // act
            var result = bitboard.GetLeadingSquare();
                
            // assert
            Assert.AreEqual(Squares.E8, result);
        }

        [TestMethod]
        public void GetLeadingSquare_SettedD5andA1_ReturnsD5()
        {
            // arrange
            UInt64 bitboard = 0;
            bitboard = bitboard
                .Set(Squares.A1)
                .Set(Squares.D5);

            // act
            var result = bitboard.GetLeadingSquare();

            // assert
            Assert.AreEqual(Squares.D5, result);
        }


        [TestMethod]
        public void GetLeadingSquare_EverySquareReverse()
        {
            
            for (int i = 63; i >= 0; i--)
            {
                UInt64 bitboard = 0;
                Squares sq = (Squares)i;
                bitboard = bitboard.Set(sq);
                Assert.AreEqual(sq, bitboard.GetLeadingSquare());
            }
        }

        [TestMethod]
        public void GetLeadingSquare_Empty_ReturnsINVALID()
        {
            // arrange
            UInt64 bitboard = 0;

            // act
            var result = bitboard.GetLeadingSquare();

            // assert
            Assert.AreEqual(Squares.INVALID, result);
        }

        [TestMethod]
        public void GetLeadingSquare_EverySquare()
        {
            UInt64 bitboard = 0;
            for (int i = 0; i < 64; i++)
            {
                Squares sq = (Squares)i;
                bitboard = bitboard.Set(sq);
                Assert.AreEqual(sq, bitboard.GetLeadingSquare());
            }
        }


        [TestMethod]
        public void GetBitCount_EverySquare()
        {
            UInt64 bitboard = 0;
            for (int i = 0; i < 64; i++)
            {
                Squares sq = (Squares)i;
                bitboard = bitboard.Set(sq);
                Assert.AreEqual(i + 1, bitboard.GetBitCount(), string.Format("Índice = {0}", i));
            }
        }

        [TestMethod]
        public void GetBitCount_EverySquareReverse()
        {
            UInt64 bitboard = 0;
            for (int i = 63; i >= 0; i--)
            {
                Squares sq = (Squares)i;
                bitboard = bitboard.Set(sq);
                Assert.AreEqual(64 - i, bitboard.GetBitCount());
            }
        }

        [TestMethod]
        public void GetBitCount_SettedD5andA1_Returns2()
        {
            // arrange
            UInt64 bitboard = 0;
            bitboard = bitboard
                .Set(Squares.A1)
                .Set(Squares.D5);

            // act
            var result = bitboard.GetBitCount();

            // assert
            Assert.AreEqual(2, result);
        }

        
    }
}
