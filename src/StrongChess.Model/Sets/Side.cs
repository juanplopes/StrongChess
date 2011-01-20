using System;
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
