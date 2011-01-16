using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;
using SharpTestsEx;
using StrongChess.Model.Pieces;
using SharpTestsEx.ExtensionsImpl;

namespace StrongChess.Model.Tests.Pieces
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
            var b = new Bishop("A1");
            var expected = Bitboard.With.DiagonalA1H8.Except.A1.Build();
                
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
            Bitboard mb = b.GetMoveBoard(Bitboard.Empty, Bitboard.With.E5);

            // assert
            mb.Should().Be(expected);
        }



        [Test]
        public void GetMoveBoard_BishopInD4EnemiesInB2E3FriendsA7F6()
        {
            // arrange
            var b = new Bishop(new Square("D4"));

            var expected = Bitboard.With.B2.C3.E3.C5.B6.E5.Build();

            // act
            Bitboard mb = b.GetMoveBoard(Bitboard.With.A7.F6, Bitboard.With.B2.E3);

            // assert
            mb.Should().Be(expected);
        }

    }
   
}
