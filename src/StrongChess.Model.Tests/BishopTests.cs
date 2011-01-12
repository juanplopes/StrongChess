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
            var b = new Bishop(Squares.D5);

            // act

            // assert
            b.Location.Should().Be(Squares.D5);
        }

        [Test]
        public void GetMoveBoard_BishopInA1_ReturnsA1H8DgExceptA1()
        {
            // arrange
            var b = new Bishop(Squares.A1);
            Bitboard expected = ((Bitboard)new DiagonalNE(Squares.A1))
                .Clear(Squares.A1);

            // act
            Bitboard mb = b.GetMoveBoard();

            // assert
            mb.Should().Be(expected);
        }

        [Test]
        public void GetMoveBoard_BishopInA1EnemyInE5_ReturnsB2C3D4E5()
        {
            // arrange
            var b = new Bishop(Squares.A1);

            Bitboard expected = Squares.B2 | Squares.C3 | Squares.D4 | Squares.E5;

            // act
            Bitboard mb = b.GetMoveBoard(Bitboard.Empty, Squares.E5);

            // assert
            mb.Should().Be(expected);
        }

        [Test]
        public void GetMoveBoard_BishopInD4EnemiesInB2E3FriendsA7F6()
        {
            // arrange
            var b = new Bishop(Squares.D4);

            Bitboard expected = Squares.B2 | Squares.C3 | 
                Squares.E3 |
                Squares.C5 | Squares.B6 |
                Squares.E5 
                ;

            // act
            Bitboard mb = b.GetMoveBoard(
                Squares.A7 | Squares.F6, 
                Squares.B2 | Squares.E3
                );

            // assert
            mb.Should().Be(expected);
        }

    }
}
