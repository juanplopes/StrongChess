using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrongChess.Model.Tests.Sets
{
	using NUnit.Framework;
	using SharpTestsEx;
	using StrongChess.Model.Sets;
	using StrongChess.Model.Pieces;

	[TestFixture]
	class SideTests_GetPieceAt
	{
				
		[Test]
        public void GetPieceAt_A1InWhiteInitialPosition_ReturnsRook()
        {
            // arrange
            var side = Side.WhiteInitialPosition;
            // act
            var piece = side.GetPieceAt("A1");
            // assert
            piece.Should().Be(ChessPieces.Rook);
        }
		
		[Test]
		public void GetPieceAt_A8InBlackInitialPosition_ReturnsRook()
        {
            // arrange
            var side = Side.BlackInitialPosition;
            // act
            var piece = side.GetPieceAt("A8");
            // assert
            piece.Should().Be(ChessPieces.Rook);
        }
        		
		[Test]
        public void GetPieceAt_B1InWhiteInitialPosition_ReturnsKnight()
        {
            // arrange
            var side = Side.WhiteInitialPosition;
            // act
            var piece = side.GetPieceAt("B1");
            // assert
            piece.Should().Be(ChessPieces.Knight);
        }
		
		[Test]
		public void GetPieceAt_B8InBlackInitialPosition_ReturnsKnight()
        {
            // arrange
            var side = Side.BlackInitialPosition;
            // act
            var piece = side.GetPieceAt("B8");
            // assert
            piece.Should().Be(ChessPieces.Knight);
        }
        		
		[Test]
        public void GetPieceAt_C1InWhiteInitialPosition_ReturnsBishop()
        {
            // arrange
            var side = Side.WhiteInitialPosition;
            // act
            var piece = side.GetPieceAt("C1");
            // assert
            piece.Should().Be(ChessPieces.Bishop);
        }
		
		[Test]
		public void GetPieceAt_C8InBlackInitialPosition_ReturnsBishop()
        {
            // arrange
            var side = Side.BlackInitialPosition;
            // act
            var piece = side.GetPieceAt("C8");
            // assert
            piece.Should().Be(ChessPieces.Bishop);
        }
        		
		[Test]
        public void GetPieceAt_D1InWhiteInitialPosition_ReturnsQueen()
        {
            // arrange
            var side = Side.WhiteInitialPosition;
            // act
            var piece = side.GetPieceAt("D1");
            // assert
            piece.Should().Be(ChessPieces.Queen);
        }
		
		[Test]
		public void GetPieceAt_D8InBlackInitialPosition_ReturnsQueen()
        {
            // arrange
            var side = Side.BlackInitialPosition;
            // act
            var piece = side.GetPieceAt("D8");
            // assert
            piece.Should().Be(ChessPieces.Queen);
        }
        		
		[Test]
        public void GetPieceAt_E1InWhiteInitialPosition_ReturnsKing()
        {
            // arrange
            var side = Side.WhiteInitialPosition;
            // act
            var piece = side.GetPieceAt("E1");
            // assert
            piece.Should().Be(ChessPieces.King);
        }
		
		[Test]
		public void GetPieceAt_E8InBlackInitialPosition_ReturnsKing()
        {
            // arrange
            var side = Side.BlackInitialPosition;
            // act
            var piece = side.GetPieceAt("E8");
            // assert
            piece.Should().Be(ChessPieces.King);
        }
        		
		[Test]
        public void GetPieceAt_F1InWhiteInitialPosition_ReturnsBishop()
        {
            // arrange
            var side = Side.WhiteInitialPosition;
            // act
            var piece = side.GetPieceAt("F1");
            // assert
            piece.Should().Be(ChessPieces.Bishop);
        }
		
		[Test]
		public void GetPieceAt_F8InBlackInitialPosition_ReturnsBishop()
        {
            // arrange
            var side = Side.BlackInitialPosition;
            // act
            var piece = side.GetPieceAt("F8");
            // assert
            piece.Should().Be(ChessPieces.Bishop);
        }
        		
		[Test]
        public void GetPieceAt_G1InWhiteInitialPosition_ReturnsKnight()
        {
            // arrange
            var side = Side.WhiteInitialPosition;
            // act
            var piece = side.GetPieceAt("G1");
            // assert
            piece.Should().Be(ChessPieces.Knight);
        }
		
		[Test]
		public void GetPieceAt_G8InBlackInitialPosition_ReturnsKnight()
        {
            // arrange
            var side = Side.BlackInitialPosition;
            // act
            var piece = side.GetPieceAt("G8");
            // assert
            piece.Should().Be(ChessPieces.Knight);
        }
        		
		[Test]
        public void GetPieceAt_H1InWhiteInitialPosition_ReturnsRook()
        {
            // arrange
            var side = Side.WhiteInitialPosition;
            // act
            var piece = side.GetPieceAt("H1");
            // assert
            piece.Should().Be(ChessPieces.Rook);
        }
		
		[Test]
		public void GetPieceAt_H8InBlackInitialPosition_ReturnsRook()
        {
            // arrange
            var side = Side.BlackInitialPosition;
            // act
            var piece = side.GetPieceAt("H8");
            // assert
            piece.Should().Be(ChessPieces.Rook);
        }
        		
		[Test]
        public void GetPieceAt_E4InWhiteInitialPosition_ReturnsNone()
        {
            // arrange
            var side = Side.WhiteInitialPosition;
            // act
            var piece = side.GetPieceAt("E4");
            // assert
            piece.Should().Be(ChessPieces.None);
        }
	}
}
