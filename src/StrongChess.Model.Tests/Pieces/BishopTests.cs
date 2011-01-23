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
        public void GetMoveBoard_BishopInB2_ReturnsA1H8AndC1A3ExceptB2()
        {
            // arrange
            var expected = Bitboard.With.DiagonalA1H8.DiagonalC1A3.Except.B2.Build();

            // act
            Bitboard mb = Rules.For<Bishop>().GetMoveBoard("B2");

            // assert
            mb.Should().Be(expected);
        }

        [Test]
        public void GetMoveBoard_BishopInA1_ReturnsA1H8DgExceptA1()
        {
            // arrange
            var expected = Bitboard.With.DiagonalA1H8.Except.A1.Build();
                
            // act
            Bitboard mb = Rules.For<Bishop>().GetMoveBoard("A1");

            // assert
            mb.Should().Be(expected);
        }

        [Test]
        public void GetMoveBoard_BishopInA1EnemyInE5_ReturnsB2C3D4E5()
        {
            // arrange
            Bitboard expected = Bitboard.With.B2.C3.D4.E5;

            // act
            Bitboard mb = Rules.For<Bishop>().GetMoveBoard("A1", 0, Bitboard.With.E5);

            // assert
            mb.Should().Be(expected);
        }



        [Test]
        public void GetMoveBoard_BishopInD4EnemiesInB2E3FriendsA7F6()
        {
            // arrange
            var expected = Bitboard.With.B2.C3.E3.C5.B6.E5.Build();

            // act
            var mb = Rules.For<Bishop>().GetMoveBoard("D4",
                Bitboard.With.A7.F6, Bitboard.With.B2.E3);

            // assert
            mb.Should().Be(expected);
        }

    }
   
}
