using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;
using SharpTestsEx;
using StrongChess.Model.Pieces;

namespace StrongChess.Model.Tests
{
    [TestFixture]
    public class BishopTests
    {
        [Test]
        public void ctor_passingD5_LocationD5()
        {
            // arrange
            var b = new Bishop("D5");

            // act

            // assert
            b.Location.Should().Be(new Square("D5"));
        }

        [Test]
        public void GetMoveBoard_BishopInA1_ReturnsA1H8DgExceptA1()
        {
            // arrange
            var b = new Bishop(new Square("A1"));
            Bitboard expected = ((Bitboard)new DiagonalNE(new Square("A1")))
                .Clear(new Square("A1"));

            // act
            Bitboard mb = b.GetMoveBoard();

            // assert
            mb.Should().Be(expected);
        }

        [Test]
        public void GetMoveBoard_BishopInA1EnemyInE5_ReturnsB2C3D4E5()
        {
            // arrange
            var b = new Bishop(new Square("A1"));

            Bitboard expected = Bitboard.With.B2.C3.D4.E5;

            // act
            Bitboard mb = b.GetMoveBoard(Bitboard.Empty, new Square("E5"));

            // assert
            mb.Should().Be(expected);
        }

        [Test]
        public void GetMoveBoard_BishopInD4EnemiesInB2E3FriendsA7F6()
        {
            // arrange
            var b = new Bishop(new Square("D4"));

            Bitboard expected = new Square("B2") | new Square("C3") | 
                new Square("E3") |
                new Square("C5") | new Square("B6") |
                new Square("E5") 
                ;

            // act
            Bitboard mb = b.GetMoveBoard(
                new Square("A7") | new Square("F6"), 
                new Square("B2") | new Square("E3")
                );

            // assert
            mb.Should().Be(expected);
        }

    }
}
