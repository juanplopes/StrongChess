using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

using StrongChess.Model;
using System.Runtime.InteropServices;
using SharpTestsEx;

namespace StrongChess.Model.Tests.Units
{
    [TestFixture]
    public class BitboardTests
    {
        [Test]
        public void EmptyBitboardHighestSquareIsA1()
        {
            new Bitboard().HighestSquare.Should().Be(new Square("A1"));
        }

        [Test]
        public void EmptyBitboardLowestSquareIsH8()
        {
            new Bitboard().LowestSquare.Should().Be(new Square("H8"));
        }

        [Test]
        public void SizeOfBitboardShouldBe8()
        {
            Marshal.SizeOf(new Bitboard()).Should().Be(8);
        }

        [Test]
        public void Set_Rank2()
        {
            var bitboard = new Bitboard().And(new Rank("2"));

            bitboard.Value.Should().Be(0x000000000000FF00);
        }

        [Test]
        public void Clear_D_SettedFileDAndE()
        {
            // arrange

            var bitboard = new Bitboard().And(new File("D"), new File("E"));
            bitboard.Value.Should().Be(0x1818181818181818);

            bitboard = bitboard.Except(new File("D"));
            bitboard.Value.Should().Be(0x1010101010101010);
        }

        [Test]
        public void ToString_SettedRank4And5()
        {

            var bitboard = new Bitboard().And(new Rank("4")).And(new Rank("5"));
            bitboard.ToString().Should().Be("[A4; B4; C4; D4; E4; F4; G4; H4; A5; B5; C5; D5; E5; F5; G5; H5]");
        }


        [Test]
        public void Clear_5_SettedRank4And5()
        {

            var bitboard = new Bitboard().And(new Rank("4")).And(new Rank("5"));
            bitboard.Value.Should().Be(0x000000FFFF000000);

            bitboard = bitboard.Except(new Rank("5"));
            bitboard.Value.Should().Be(0x00000000FF000000);
        }

        [Test]
        public void Set_FileE()
        {
            var bitboard = new Bitboard().And(new File("E"));
            bitboard.Value.Should().Be(0x1010101010101010);

        }

        [Test]
        public void Set_A1()
        {
            var bitboard1 = new Bitboard().And(new Square("A1"));

            bitboard1.Value.Should().Be(0x0000000000000001);
        }

        [Test]
        public void Clear_A1()
        {
            var bitboard1 = new Bitboard().And(new Square("A1"));
            var bitboard2 = bitboard1.Except(new Square("A1"));

            bitboard1.Should().Not.Be(bitboard2);
            bitboard2.IsEmpty.Should().Be.True();
        }

        [Test]
        public void IsSet_SettedA1_ReturnsTrue()
        {
            var bitboard1 = new Bitboard().And(new Square("A1"));
            var bitboard2 = bitboard1.Except(new Square("A1"));

            // assert
            bitboard1.IsSet(new Square("A1")).Should().Be.True();
            bitboard2.IsSet(new Square("A1")).Should().Be.False();
        }

        [Test]
        public void IsClear_SettedA1_ReturnsFalse()
        {

            // act
            var bitboard1 = new Bitboard().And(new Square("A1"));
            var bitboard2 = bitboard1.Except(new Square("A1"));

            // assert
            bitboard1.IsClear(new Square("A1")).Should().Be.False();
            bitboard2.IsClear(new Square("A1")).Should().Be.True();
        }

        [Test]
        public void Set_F5()
        {
            // act
            var bitboard1 = new Bitboard().And(new Square("F5"));

            bitboard1.Value.Should().Be(1ul << 4 * 8 + 5);
        }

        [Test]
        public void Clear_F5()
        {
            // act
            var bitboard1 = new Bitboard().And(new Square("F5"));
            var bitboard2 = bitboard1.Except(new Square("F5"));

            bitboard2.Value.Should().Be(0);
        }

        [Test]
        public void IsSet_SettedF5_ReturnsTrue()
        {
            // act
            var bitboard1 = new Bitboard().And(new Square("F5"));
            var bitboard2 = bitboard1.Except(new Square("F5"));

            // assert
            bitboard1.IsSet(new Square("F5")).Should().Be.True();
            bitboard2.IsSet(new Square("F5")).Should().Be.False();
        }

        [Test]
        public void IsClear_SettedF5_ReturnsFalse()
        {
            // arrange

            // act
            var bitboard1 = new Bitboard().And(new Square("F5"));
            var bitboard2 = bitboard1.Except(new Square("F5"));

            // assert
            Assert.IsFalse(bitboard1.IsClear(new Square("F5")));
            Assert.IsTrue(bitboard2.IsClear(new Square("F5")));
        }

        [Test]
        public void IsClear_A1_SettedF5A1ClearingA1_ReturnsTrue()
        {
            // arrange

            // act
            var bitboard1 = new Bitboard()
                   .And(new Square("F5"))
                   .And(new Square("A1"));

            var bitboard2 = bitboard1.Except(new Square("A1"));

            // assert
            Assert.IsFalse(bitboard1.IsClear(new Square("A1")));
            Assert.IsTrue(bitboard2.IsClear(new Square("A1")));
        }

        [Test]
        public void IsClear_F5_SettedF5A1ClearingA1_ReturnsFalse()
        {
            // arrange

            // act
            var bitboard1 = new Bitboard()
                   .And(new Square("F5"))
                   .And(new Square("A1"));

            var bitboard2 = bitboard1.Except(new Square("A1"));

            // assert
            Assert.IsFalse(bitboard1.IsClear(new Square("F5")));
            Assert.IsFalse(bitboard2.IsClear(new Square("F5")));
        }



        [Test]
        public void GetLeadingSquare_SettedA1_ReturnsA1()
        {
            // arrange
            var bitboard = new Bitboard().And(new Square("A1"));

            // act
            var result = bitboard.Squares.First();

            // assert
            Assert.AreEqual(new Square("A1"), result);
        }

        [Test]
        public void GetLeadingSquare_SettedB1_ReturnsB1()
        {
            // arrange
            var bitboard = new Bitboard().And(new Square("B1"));

            // act
            var result = bitboard.Squares.First();

            // assert
            Assert.AreEqual(new Square("B1"), result);
        }

        [Test]
        public void GetLeadingSquare_SettedA1andB1_ReturnsA1()
        {
            // arrange
            var bitboard = new Bitboard().And(new Square("A1"), new Square("B1"));

            // act
            var result = bitboard.Squares.First();

            // assert
            Assert.AreEqual(new Square("A1"), result);
        }

        [Test]
        public void GetLeadingSquare_SettedA1andH2_ReturnsA1()
        {
            // arrange
            var bitboard = new Bitboard()
                .And(new Square("A1"))
                .And(new Square("H2"));

            // act
            var result = bitboard.Squares.First();

            // assert
            Assert.AreEqual(new Square("A1"), result);
        }

        [Test]
        public void GetLeadingSquare_SettedH2andA3_ReturnsH2()
        {
            // arrange
            var bitboard = new Bitboard()
                .And(new Square("A3"))
                .And(new Square("H2"));

            // act
            var result = bitboard.Squares.First();

            // assert
            Assert.AreEqual(new Square("H2"), result);
        }

        [Test]
        public void GetLeadingSquare_SettedH4andA5_ReturnsH4()
        {
            // arrange
            var bitboard = new Bitboard()
                .And(new Square("A5"))
                .And(new Square("H4"));

            // act
            var result = bitboard.Squares.First();

            // assert
            Assert.AreEqual(new Square("H4"), result);
        }

        [Test]
        public void GetLeadingSquare_SettedH6andA7andE8_ReturnsH6()
        {
            // arrange
            var bitboard = new Bitboard()
                .And(new Square("A7"))
                .And(new Square("E8"))
                .And(new Square("H6"));

            // act
            var result = bitboard.Squares.First();

            // assert
            Assert.AreEqual(new Square("H6"), result);
        }

        [Test]
        public void GetLeadingSquare_SettedD5andA1_ReturnsA1()
        {
            // arrange
            var bitboard = new Bitboard()
                .And(new Square("A1"))
                .And(new Square("D5"));

            // act
            var result = bitboard.Squares.First();

            // assert
            Assert.AreEqual(new Square("A1"), result);
        }


        [Test]
        public void GetLeadingSquare_EverySquareForward()
        {

            for (int i = 63; i >= 0; i--)
            {
                var sq = new Square(i);
                var bitboard = new Bitboard().And(sq);
                Assert.AreEqual(sq, bitboard.Squares.First());
            }
        }

        [Test]
        public void GetLeadingSquare_Empty_ReturnsINVALID()
        {
            new Bitboard().Squares.Should().Be.Empty();
        }

        [Test]
        public void GetLeadingSquare_EverySquare()
        {
            var bitboard = new Bitboard();
            for (int i = 63; i >=0; i--)
            {
                var sq = new Square(i);
                bitboard = bitboard.And(sq);
                bitboard.Squares.First().Should().Be(sq);
            }
        }


        [Test]
        public void GetBitCount_EverySquare()
        {
            var bitboard = new Bitboard();
            for (int i = 0; i < 64; i++)
            {
                var sq = new Square(i);
                bitboard = bitboard.And(sq);
                bitboard.BitCount.Should().Be(i + 1);
            }
        }

        [Test]
        public void GetBitCount_EverySquareReverse()
        {
            Bitboard bitboard = 0;
            for (int i = 63; i >= 0; i--)
            {
                var sq = new Square(i);
                bitboard = bitboard.And(sq);
                Assert.AreEqual(64 - i, bitboard.BitCount);
            }
        }

        [Test]
        public void GetBitCount_SettedD5andA1_Returns2()
        {
            // arrange
            var bitboard = new Bitboard()
                .And(new Square("A1"))
                .And(new Square("D5"));

            // act
            var result = bitboard.BitCount;

            // assert
            Assert.AreEqual(2, result);
        }


    }
}
