﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StrongChess.Model.Pieces;
using StrongChess.Model.Util;

namespace StrongChess.Model.Sets
{
    public struct Side
    {
        public PieceSet<Queen> Queens
        { get; private set; }
        public PieceSet<Rook> Rooks
        { get; private set; }
        public PieceSet<Bishop> Bishops
        { get; private set; }
        public PieceSet<Knight> Knights
        { get; private set; }
        public IPawns Pawns
        { get; private set; }


        PieceSet<King> _King;
        public Square KingLocation
        { get { return _King.Locations.GetSettedSquares().First(); } }

        public Bitboard Occupation 
        { get; private set; }

        public Side(
            Square kingLocation,
            PieceSet<Queen> queens,
            PieceSet<Bishop> bishops,
            PieceSet<Knight> knights,
            PieceSet<Rook> rooks,
            IPawns pawns
            ) : this()
        {
            _King = new PieceSet<King>(kingLocation.AsBoard);
            Queens = queens;
            Rooks = rooks;
            Bishops = bishops;
            Knights = knights;
            Pawns = pawns;
            Occupation = queens.Locations | rooks.Locations | _King.Locations |
                bishops.Locations | knights.Locations | pawns.Locations;
        }

        public Bitboard GetCapturesMoveBoard(Bitboard enemies, Square? enpassant)
        {
            var notblockers = ~(this.Occupation | enemies);
            return _King.GetMoveBoard(Occupation, enemies, true) |
                Queens.GetMoveBoard(Occupation, enemies, true) |
                Bishops.GetMoveBoard(Occupation, enemies, true) |
                Knights.GetMoveBoard(Occupation, enemies, true) |
                Rooks.GetMoveBoard(Occupation, enemies, true) |
                Pawns.GetCapturesMoveBoard(notblockers, enemies, enpassant);
        }

        public Bitboard GetMoveBoard(Bitboard enemies, Square? enpassant)
        {
            var notblockers = ~(this.Occupation | enemies);
            return _King.GetMoveBoard(Occupation, enemies) |
                Queens.GetMoveBoard(Occupation, enemies) |
                Bishops.GetMoveBoard(Occupation, enemies) |
                Knights.GetMoveBoard(Occupation, enemies) |
                Rooks.GetMoveBoard(Occupation, enemies) |
                Pawns.GetMoveBoard(notblockers, enemies, enpassant);
        }

        public IEnumerable<Move> GetMoves(Bitboard enemies, Square? enpassant)
        {
            Bitboard notblockers = ~(Occupation | enemies);
            return _King.GetMoves(Occupation, enemies)
                .Union(Queens.GetMoves(Occupation, enemies))
                .Union(Rooks.GetMoves(Occupation, enemies))
                .Union(Bishops.GetMoves(Occupation, enemies))
                .Union(Knights.GetMoves(Occupation, enemies))
                .Union(Pawns.GetAllMoves(notblockers, enemies, enpassant));
        }

        public IEnumerable<Move> GetCaptures(Bitboard enemies, Square? enpassant)
        {
            return _King.GetMoves(Occupation, enemies, true)
                .Union(Queens.GetMoves(Occupation, enemies, true))
                .Union(Rooks.GetMoves(Occupation, enemies, true))
                .Union(Bishops.GetMoves(Occupation, enemies, true))
                .Union(Knights.GetMoves(Occupation, enemies, true))
                .Union(Pawns.GetCaptures(enemies, enpassant));
        }

        //public bool InCheck(Side enemy)
        //{
        //    return (enemy.GetCaptures(this.Occupation, null) & _King) == _King;
        //}

        public static Side WhiteInitialPosition
        {
            get
            {
                return new Side(
                    new Square("E1"),
                    new PieceSet<Queen>(Bitboard.With.D1),
                    new PieceSet<Bishop>(Bitboard.With.C1.F1),
                    new PieceSet<Knight>(Bitboard.With.B1.G1),
                    new PieceSet<Rook>(Bitboard.With.A1.H1),
                    WhitePawns.InitialPosition
                    );
            }
        }

        public static Side BlackInicialPosition
        {
            get
            {
                return new Side(
                            new Square("E8"),
                            new PieceSet<Queen>(Bitboard.With.D8),
                            new PieceSet<Bishop>(Bitboard.With.C8.F8),
                            new PieceSet<Knight>(Bitboard.With.B8.G8),
                            new PieceSet<Rook>(Bitboard.With.A8.H8),
                            BlackPawns.InitialPosition
                            );
            }
        }
    }
}
