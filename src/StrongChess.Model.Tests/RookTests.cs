using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using StrongChess.Model.Pieces;
using SharpTestsEx;

namespace StrongChess.Model.Tests
{
  [TestFixture]
  public class RookTests
  {
    [Test]
    public void ctor_passingD5_LocationD5()
    {
      // arrange
      Rook r = new Rook(Squares.D5);

      // act

      // assert
      r.Location.Should().Be(Squares.D5);
    }

    // -------------------------------------------------

    [Test]
    public void GetMoveBoard_RookInA1_ReturnsFileARank1ExceptA1()
    {
      // arrange
      var r = new Rook(Squares.A1);
      Bitboard expected = (Files.A | Ranks.One).Clear(Squares.A1);

      // act
      var mb = r.GetMoveBoard();

      // assert
      mb.Should().Be(expected);
    }

    [Test]
    public void GetMoveBoard_RookInH1_ReturnsFileHRank1ExceptH1()
    {
      // arrange
      var r = new Rook(Squares.H1);
      Bitboard expected = (Files.H | Ranks.One).Clear(Squares.H1);

      // act
      var mb = r.GetMoveBoard();

      // assert
      mb.Should().Be(expected);
    }

    [Test]
    public void GetMoveBoard_RookInH8_ReturnsFileHRank8ExceptH8()
    {
      // arrange
      var r = new Rook(Squares.H8);
      Bitboard expected = (Files.H | Ranks.Eight).Clear(Squares.H8);

      // act
      Bitboard mb = r.GetMoveBoard();
       
      // assert
      mb.Should().Be(expected);
    }

    [Test]
    public void GetMoveBoard_RookInD4_ReturnsFileDRank4ExceptD4()
    {
      // arrange
      var r = new Rook(Squares.D4);
      Bitboard expected = (Files.D | Ranks.Four).Clear(Squares.D4);

      // act
      Bitboard mb = r.GetMoveBoard();

      // assert
      mb.Should().Be(expected);
    }

    // ----------------------------------------------------
    [Test]
    public void GetMoveBoard_RookInA1EnemyInA5_ReturnsFileARank1ExceptA1A6A7A8()
    {
      // arrange
      var r = new Rook(Squares.A1);
      var enemy = new Bitboard()
        .Set(Squares.A5);

      Bitboard expected = (Files.A | Ranks.One)
        .Clear(Squares.A1)
        .Clear(Squares.A6)
        .Clear(Squares.A7)
        .Clear(Squares.A8);

      // act
      var mb = r.GetMoveBoard(0, enemy);

      // assert
      mb.Should().Be(expected);
    }


    [Test]
    public void GetMoveBoard_RookInA1EnemyInF1_ReturnsFileARank1ExceptA1G1H1()
    {
      // arrange
      var r = new Rook(Squares.A1);
      var enemy = new Bitboard()
        .Set(Squares.F1);

      Bitboard expected = (Files.A | Ranks.One)
        .Clear(Squares.A1)
        .Clear(Squares.G1)
        .Clear(Squares.H1);

      // act
      var mb = r.GetMoveBoard(0, enemy);

      // assert
      mb.Should().Be(expected);
    }

    [Test]
    public void GetMoveBoard_RookInH1EnemyInB1_ReturnsFileHRank1ExceptH1A1()
    {
      // arrange 
      var r = new Rook(Squares.H1);
      var enemy = new Bitboard()
        .Set(Squares.B1);

      Bitboard expected = (Files.H | Ranks.One)
        .Clear(Squares.A1)
        .Clear(Squares.H1);

      // act
      var mb = r.GetMoveBoard(0, enemy);

      // assert
      mb.Should().Be(expected);
    }

    [Test]
    public void GetMoveBoard_RookInD4EnemyInD2B4_ReturnsFileDRank4ExceptD4D1A4()
    {
      // arrange 
      var r = new Rook(Squares.D4);
      var enemy = new Bitboard()
        .Set(Squares.D2)
        .Set(Squares.B4);

      Bitboard expected = (Files.D | Ranks.Four)
        .Clear(Squares.D4)
        .Clear(Squares.D1)
        .Clear(Squares.A4);

      // act
      var mb = r.GetMoveBoard(0, enemy);

      // assert
      mb.Should().Be(expected);
    }


    // ----------------------------------------------------
    [Test]
    public void GetMoveBoard_RookInA1FriendInA5_ReturnsFileARank1ExceptA1A5A6A7A8()
    {
      // arrange
      var r = new Rook(Squares.A1);
      var friend = new Bitboard()
        .Set(Squares.A5);

      Bitboard expected = (Files.A | Ranks.One)
        .Clear(Squares.A1)
        .Clear(Squares.A5)
        .Clear(Squares.A6)
        .Clear(Squares.A7)
        .Clear(Squares.A8);

      // act
      var mb = r.GetMoveBoard(friend, 0);

      // assert
      mb.Should().Be(expected);
    }


    [Test]
    public void GetMoveBoard_RookInA1FriendInF1_ReturnsFileARank1ExceptA1F1G1H1()
    {
      // arrange
      var r = new Rook(Squares.A1);
      var friend = new Bitboard()
        .Set(Squares.F1);

      Bitboard expected = (Files.A | Ranks.One)
        .Clear(Squares.A1)
        .Clear(Squares.F1)
        .Clear(Squares.G1)
        .Clear(Squares.H1);

      // act
      var mb = r.GetMoveBoard(friend, 0);

      // assert
      mb.Should().Be(expected);
    }

    [Test]
    public void GetMoveBoard_RookInH1FriendInB1_ReturnsFileHRank1ExceptH1A1B1()
    {
      // arrange 
      var r = new Rook(Squares.H1);
      var friend = new Bitboard()
        .Set(Squares.B1);

      Bitboard expected = (Files.H | Ranks.One)
        .Clear(Squares.A1)
        .Clear(Squares.B1)
        .Clear(Squares.H1);

      // act
      var mb = r.GetMoveBoard(friend, 0);

      // assert
      mb.Should().Be(expected);
    }

    [Test]
    public void GetMoveBoard_RookInD4FriendInD2B4_ReturnsFileDRank4ExceptB4D2D4D1A4()
    {
      // arrange 
      var r = new Rook(Squares.D4);
      var friend = new Bitboard()
        .Set(Squares.D2)
        .Set(Squares.B4);

      Bitboard expected = (Files.D | Ranks.Four)
        .Clear(Squares.D4)
        .Clear(Squares.B4)
        .Clear(Squares.D2)
        .Clear(Squares.D1)
        .Clear(Squares.A4);

      // act
      var mb = r.GetMoveBoard(friend, 0);

      // assert
      mb.Should().Be(expected);
    }

  }
}
