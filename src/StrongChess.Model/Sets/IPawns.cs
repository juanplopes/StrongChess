﻿using System;
using System.Collections.Generic;
using StrongChess.Model;
namespace StrongChess.Model.Sets
{
    public interface IPawns
    {
        Bitboard Bitboard { get; }
        IEnumerable<Move> GetAllMoves(
            Bitboard notblockers,
            Bitboard enemies,
            Square? enpassant
            );

        IEnumerable<Move> GetCaptures(
            Bitboard enemies,
            Square? enpassant = null
            );

        IEnumerable<Move> GetMovesOneSquareForward();
        IEnumerable<Move> GetMovesOneSquareForward(Bitboard notblockers);
        IEnumerable<Move> GetMovesTwoSquaresForward();
        IEnumerable<Move> GetMovesTwoSquaresForward(Bitboard notblockers);
        bool IsValid { get; }
    }
}
