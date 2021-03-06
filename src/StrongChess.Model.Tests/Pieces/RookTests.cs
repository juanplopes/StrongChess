﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using StrongChess.Model.Pieces;
using SharpTestsEx;

namespace StrongChess.Model.Tests.Pieces
{
    [TestFixture]
    public class RookTests
    {
      
        // -------------------------------------------------

        [Test]
        public void GetMoveBoard_RookInA1_ReturnsFileARank1ExceptA1()
        {
            // arrange
            var expected = Bitboard.With.FileA.Rank1.Except.A1.Build();

            // act
            var mb = Rules.For<Rook>().GetMoveBoard("A1");

            // assert
            mb.Should().Be(expected);
        }

        [Test]
        public void GetMoveBoard_RookInH1_ReturnsFileHRank1ExceptH1()
        {
            // arrange
            var expected = Bitboard.With.FileH.Rank1.Except.H1.Build();

            // act
            var mb = Rules.For<Rook>().GetMoveBoard("H1");

            // assert
            mb.Should().Be(expected);
        }

        [Test]
        public void GetMoveBoard_RookInH8_ReturnsFileHRank8ExceptH8()
        {
            // arrange
            var expected = Bitboard.With.FileH.Rank8.Except.H8.Build();

            // act
            Bitboard mb = Rules.For<Rook>().GetMoveBoard("h8");

            // assert
            mb.Should().Be(expected);
        }

        [Test]
        public void GetMoveBoard_RookInD4_ReturnsFileDRank4ExceptD4()
        {
            // arrange
            var expected = Bitboard.With.FileD.Rank4.Except.D4.Build();

            // act
            var mb = Rules.For<Rook>().GetMoveBoard("D4");

            // assert
            mb.Should().Be(expected);
        }

        // ----------------------------------------------------
        [Test]
        public void GetMoveBoard_RookInA1EnemyInA5_ReturnsFileARank1ExceptA1A6A7A8()
        {
            // arrange
            var enemy = Bitboard.With.A5.Build();
            var expected = Bitboard.With.FileA.Rank1.Except.A1.A6.A7.A8.Build();

            // act
            var mb = Rules.For<Rook>().GetMoveBoard("A1", 0, enemy);

            // assert
            mb.Should().Be(expected);
        }


        [Test]
        public void GetMoveBoard_RookInA1EnemyInF1_ReturnsFileARank1ExceptA1G1H1()
        {
            // arrange
            var enemy = Bitboard.With.F1.Build();
            var expected = Bitboard.With.FileA.Rank1.Except.A1.G1.H1.Build();

            // act
            var mb = Rules.For<Rook>().GetMoveBoard("A1", 0, enemy);

            // assert
            mb.Should().Be(expected);
        }

        [Test]
        public void GetMoveBoard_RookInH1EnemyInB1_ReturnsFileHRank1ExceptH1A1()
        {
            // arrange 
            var enemy = Bitboard.With.B1.Build();
            var expected = Bitboard.With.FileH.Rank1.Except.A1.H1.Build();

            // act
            var mb = Rules.For<Rook>().GetMoveBoard("H1", 0, enemy);

            // assert
            mb.Should().Be(expected);
        }

        [Test]
        public void GetMoveBoard_RookInD4EnemyInD2B4_ReturnsFileDRank4ExceptD4D1A4()
        {
            // arrange 
            var enemy = Bitboard.With.D2.B4.Build();
            var expected = Bitboard.With.FileD.Rank4.Except.D4.D1.A4.Build();

            // act
            var mb = Rules.For<Rook>().GetMoveBoard("D4", 0, enemy);

            // assert
            mb.Should().Be(expected);
        }


        // ----------------------------------------------------
        [Test]
        public void GetMoveBoard_RookInA1FriendInA5_ReturnsFileARank1ExceptA1A5A6A7A8()
        {
            // arrange
            var friend = Bitboard.With.A5.Build();
            var expected = Bitboard.With.FileA.Rank1.Except.A1.A5.A6.A7.A8.Build();

            // act
            var mb = Rules.For<Rook>().GetMoveBoard("A1", friend, 0);

            // assert
            mb.Should().Be(expected);
        }


        [Test]
        public void GetMoveBoard_RookInA1FriendInF1_ReturnsFileARank1ExceptA1F1G1H1()
        {
            // arrange
            var friend = Bitboard.With.F1.Build();
            var expected = Bitboard.With.FileA.Rank1.Except.A1.F1.G1.H1.Build();

            // act
            var mb = Rules.For<Rook>().GetMoveBoard("A1", friend, 0);

            // assert
            mb.Should().Be(expected);
        }

        [Test]
        public void GetMoveBoard_RookInH1FriendInB1_ReturnsFileHRank1ExceptH1A1B1()
        {
            // arrange 
            var friend = Bitboard.With.B1.Build();
            var expected = Bitboard.With.FileH.Rank1.Except.A1.B1.H1.Build();

            // act
            var mb = Rules.For<Rook>().GetMoveBoard("H1", friend, 0);

            // assert
            mb.Should().Be(expected);
        }

        [Test]
        public void GetMoveBoard_RookInD4FriendInD2B4_ReturnsFileDRank4ExceptB4D2D4D1A4()
        {
            // arrange 
            var friend = Bitboard.With.D2.B4.Build();
            var expected = Bitboard.With.FileD.Rank4.Except.D4.B4.D2.D1.A4.Build();

            // act
            var mb = Rules.For<Rook>().GetMoveBoard("D4", friend, 0);

            // assert
            mb.Should().Be(expected);
        }

    }
}
