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

        public IEnumerable<Move> GetDiscoveredDiagonalAttackMoves(Square target, Bitboard enemies, Square? enpassant = null)
        {
            var filterFrom = GetBlockersToDiagonalAttacks(target, enemies);

            var result = Knights.GetMoves(Occupation, enemies, filterFrom, Bitboard.Full)
                .Union(Rooks.GetMoves(Occupation, enemies, filterFrom, Bitboard.Full))
                ;

            if ((_King.Locations & filterFrom) > 0)
            {
                var kl = KingLocation;
                int offset = target - kl ;
                Bitboard filterTo = Bitboard.Full;

                if (offset % 9 == 0)
                    filterTo = ~(kl.AsBoard.Shift(1, 1) | kl.AsBoard.Shift(-1, -1));
                else if (offset % 7 == 0)
                    filterTo = ~(kl.AsBoard.Shift(1, -1) | kl.AsBoard.Shift(-1, 1));

                result = result.Union(_King.GetMoves(Occupation, enemies, filterFrom, filterTo));
            }

            if ((Pawns.Locations & filterFrom) > 0)
            {
                Bitboard notblockers = ~(Occupation | enemies);
                result = result.Union(Pawns.GetMovesOneSquareForward(notblockers, filterFrom, Bitboard.Full))
                    .Union(Pawns.GetMovesTwoSquaresForward(notblockers, filterFrom, Bitboard.Full))
                    .Union(Pawns.GetCaptures(enemies, filterFrom, Bitboard.Full, enpassant));
            }

            return result;
        }

        public Bitboard GetBlockersToDiagonalAttacks(Square target, Bitboard enemies)
        {
            var allpieces = enemies | Occupation;
            var blockers = Rules.For<Bishop>().GetMoveBoard(target, Bitboard.Empty, allpieces);
            blockers = blockers & (_King.Locations | Rooks.Locations | Knights.Locations | Pawns.Locations);

            allpieces = allpieces & ~blockers;
            var checkers = Rules.For<Bishop>().GetMoveBoard(target, Bitboard.Empty, allpieces);
            checkers = checkers & (Bishops.Locations | Queens.Locations);

            var ne = new Rays(target).NE;
            if ((ne & checkers) == 0)
                blockers &= ~ne;

            var nw = new Rays(target).NW;
            if ((nw & checkers) == 0)
                blockers &= ~nw;

            var se = new Rays(target).SE;
            if ((se & checkers) == 0)
                blockers &= ~se;

            var sw = new Rays(target).SW;
            if ((sw & checkers) == 0)
                blockers &= ~sw;

            return blockers;
        }

        #region static
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
        #endregion
    }
}
