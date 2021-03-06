﻿using System;
using System.Collections.Generic;
using StrongChess.Model;
namespace StrongChess.Model.Sets
{
    public interface IPawns
    {
        Bitboard Locations { get; }
        IEnumerable<Move> GetAllMoves(
            Bitboard notblockers,
            Bitboard enemies,
            Square? enpassant
            );

        IEnumerable<Move> GetCaptures(
            Bitboard enemies,
            Square? enpassant = null
            );

        IEnumerable<Move> GetCaptures(
            Bitboard enemies,
            Bitboard filterFrom,
            Bitboard filterTo,
            Square? enpassant = null
            );

        IEnumerable<Move> GetMovesOneSquareForward();
        IEnumerable<Move> GetMovesOneSquareForward(Bitboard notblockers);
        IEnumerable<Move> GetMovesOneSquareForward(Bitboard notblockers, Bitboard filterFrom, Bitboard filterTo);
        IEnumerable<Move> GetMovesTwoSquaresForward();
        IEnumerable<Move> GetMovesTwoSquaresForward(Bitboard notblockers);
        IEnumerable<Move> GetMovesTwoSquaresForward(Bitboard notblockers, Bitboard filterFrom, Bitboard filterTo);

        Bitboard GetMoveBoard(Bitboard notblockers, Bitboard enemies, Square? enpassant);
        Bitboard GetCapturesMoveBoard(Bitboard notblockers, Bitboard enemies, Square? enpassant);

        bool IsValid { get; }
    }
}
