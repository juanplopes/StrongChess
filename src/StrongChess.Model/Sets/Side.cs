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
        public PieceSet<Queen> Queens { get; private set; }
        public PieceSet<Rook> Rooks { get; private set; }
        public PieceSet<Bishop> Bishops { get; private set; }
        public PieceSet<Knight> Knights { get; private set; }
        public IPawns Pawns { get; private set; }

        PieceSet<King> _King;
        public Square KingLocation
        { get { return _King.Locations.Squares.First(); } }

        public Boolean IsWhite 
        {get { return Pawns.GetType() == typeof(WhitePawns); } }

        public Boolean IsBlack
        { get { return Pawns.GetType() == typeof(BlackPawns); } }



        public Bitboard Occupation
        { get; private set; }

        public Side(
            Square kingLocation,
            PieceSet<Queen> queens,
            PieceSet<Bishop> bishops,
            PieceSet<Knight> knights,
            PieceSet<Rook> rooks,
            IPawns pawns
            )
            : this()
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

        public IEnumerable<Move> GetCheckMoves(Side opponent, Square? enpassant)
        {
            return GetDirectAttackMoves(opponent.KingLocation, opponent.Occupation, enpassant)
                .Union(GetDiscoveredAttackMoves(opponent.KingLocation, opponent.Occupation, enpassant));
        }

        public IEnumerable<Move> GetDirectAttackMoves(Square target, Bitboard enemies, Square? enpassant = null, bool includeKingAttacks = false)
        {
            var t = target.AsBoard;
            var notblockers = ~(this.Occupation | enemies);
            Bitboard pawnsFilterTo = t.Shift(-1, -1).And(t.Shift(-1, 1));
            
            var result = Pawns.GetCaptures(enemies, Bitboard.Full, pawnsFilterTo, enpassant)
                .Union(Pawns.GetMovesOneSquareForward(notblockers, Bitboard.Full, pawnsFilterTo))
                .Union(Pawns.GetMovesTwoSquaresForward(notblockers, Bitboard.Full, pawnsFilterTo))
                ;

            result = result
                .Union(Queens.GetDirectAttackMoves(target, Occupation, enemies))
                .Union(Bishops.GetDirectAttackMoves(target, Occupation, enemies))
                .Union(Knights.GetDirectAttackMoves(target, Occupation, enemies))
                .Union(Rooks.GetDirectAttackMoves(target, Occupation, enemies));

            if (includeKingAttacks)
                result = result.Union(_King.GetDirectAttackMoves(target, Occupation, enemies));

            return result;
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
                int offset = target - kl;
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

        public IEnumerable<Move> GetDiscoveredAttackMoves(Square target, Bitboard enemies, Square? enpassant)
        {
            return GetDiscoveredDiagonalAttackMoves(target, enemies, enpassant)
                .Union(GetDiscoverdStraightAttackMoves(target, enemies, enpassant));
        }

        public IEnumerable<Move> GetDiscoverdStraightAttackMoves(Square target, Bitboard enemies, Square? enpassant = null)
        {
            var filterFrom = GetBlockersToStraightAttacks(target, enemies);

            var result = Knights.GetMoves(Occupation, enemies, filterFrom, Bitboard.Full)
                .Union(Bishops.GetMoves(Occupation, enemies, filterFrom, Bitboard.Full));

            if ((_King.Locations & filterFrom) > 0)
            {
                Bitboard filterTo;
                if (KingLocation.File == target.File)
                    filterTo = ~(target.File.AsBoard);
                else
                    filterTo = ~(target.Rank.AsBoard);

                result = result.Union(_King.GetMoves(Occupation, enemies, filterFrom, filterTo));
            }

            if ((Pawns.Locations & filterFrom) > 0)
            {
                Bitboard notblockers = ~(Occupation | enemies);
                if ((Pawns.Locations & target.File.AsBoard) > 0)
                    result = result.Union(Pawns.GetCaptures(enemies, Pawns.Locations & target.File.AsBoard, Bitboard.Full, enpassant));

                if ((Pawns.Locations & target.Rank.AsBoard) > 0)
                    result = result.Union(Pawns.GetCaptures(enemies, Pawns.Locations & target.Rank.AsBoard, Bitboard.Full, enpassant))
                        .Union(Pawns.GetMovesOneSquareForward(notblockers, Pawns.Locations & target.Rank.AsBoard, Bitboard.Full))
                        .Union(Pawns.GetMovesTwoSquaresForward(notblockers, Pawns.Locations & target.Rank.AsBoard, Bitboard.Full));
            }

            return result;
        }

        public Bitboard GetBlockersToStraightAttacks(Square target, Bitboard enemies)
        {
            var allpieces = enemies | Occupation;
            var blockers = Rules.For<Rook>().GetMoveBoard(target, Bitboard.Empty, allpieces);
            blockers = blockers & (_King.Locations | Bishops.Locations | Knights.Locations | Pawns.Locations);

            allpieces = allpieces & ~blockers;
            var checkers = Rules.For<Rook>().GetMoveBoard(target, Bitboard.Empty, allpieces);
            checkers = checkers & (Rooks.Locations | Queens.Locations);

            var rayTo = target.RayTo;
            var n = rayTo.N;
            if ((n & checkers) == 0)
                blockers &= ~n; 

            var s = rayTo.S;
            if ((s & checkers) == 0)
                blockers &= ~s;

            var e = rayTo.E;
            if ((e & checkers) == 0)
                blockers &= ~e;

            var w = rayTo.W;
            if ((w & checkers) == 0)
                blockers &= ~w;

            return blockers;
        }

        public Bitboard GetBlockersToDiagonalAttacks(Square target, Bitboard enemies)
        {
            var allpieces = enemies | Occupation;
            var blockers = Rules.For<Bishop>().GetMoveBoard(target, Bitboard.Empty, allpieces);
            blockers = blockers & (_King.Locations | Rooks.Locations | Knights.Locations | Pawns.Locations);

            allpieces = allpieces & ~blockers;
            var checkers = Rules.For<Bishop>().GetMoveBoard(target, Bitboard.Empty, allpieces);
            checkers = checkers & (Bishops.Locations | Queens.Locations);

            var rays = new Rays(target);
            var ne = rays.NE;
            if ((ne & checkers) == 0)
                blockers &= ~ne;

            var nw = rays.NW;
            if ((nw & checkers) == 0)
                blockers &= ~nw;

            var se = rays.SE;
            if ((se & checkers) == 0)
                blockers &= ~se;

            var sw = rays.SW;
            if ((sw & checkers) == 0)
                blockers &= ~sw;

            return blockers;
        }

        public bool Attacks(Square target, Bitboard enemies)
        {
            AttackMasks m = new AttackMasks(target);
            if (this.IsWhite && ((m.WhitePawns & this.Pawns.Locations) != 0)) return true;
            if (this.IsBlack && ((m.BlackPawns & this.Pawns.Locations) != 0)) return true;

            if ((m.Knights & Knights.Locations) != 0) return true;

            var allpieces = this.Occupation | enemies;
            
            Bitboard bsliders = (Bishops.Locations | Queens.Locations) & m.Bishops;
            if (bsliders != Bitboard.Empty)
                if ((bsliders & Rules.For<Bishop>().GetMoveBoard(target, Bitboard.Empty, allpieces)) > 0) return true;

            Bitboard rsliders = (Rooks.Locations | Queens.Locations) & m.Rooks;
            if (rsliders != Bitboard.Empty)
                if ((rsliders & Rules.For<Rook>().GetMoveBoard(target, Bitboard.Empty, allpieces)) > 0) return true;

            return false;
                
        }
        
        public IEnumerable<Move> GetCheckEvasionMoves(Side enemy, Square? enpassant = null)
        {
            return 
                GetCheckEvasionKingMoves(enemy)
                .Union(GetCheckEvasionPinningPiecesMoves(enemy, enpassant));
        }

        public IEnumerable<Move> GetCheckEvasionKingMoves(Side enemy)
        {
            var alternatives = Rules.For<King>().GetMoveBoard(KingLocation, this.Occupation, enemy.Occupation);
            foreach (var sq in alternatives.Squares)
                if (!enemy.Attacks(sq, this.Occupation))
                    yield return new Move(KingLocation, sq);
        }

        public IEnumerable<Move> GetCheckEvasionPinningPiecesMoves(Side enemy, Square? enpassant = null)
        {
            var black = enemy; var white = this;
            if (this.IsBlack) { black = this; white = enemy; }
            Bitboard checkers = KingLocation.AttackedFrom(white, black) & enemy.Occupation;

            if (checkers.BitCount != 1) return Enumerable.Empty<Move>();
            if ((checkers & Knights.Locations) != 0) return Enumerable.Empty<Move>();

            Bitboard path = new AttackPath(checkers.HighestSquare, KingLocation).AsBoard
             | checkers.HighestSquare.AsBoard;

            Bitboard notblockers = ~(this.Occupation | enemy.Occupation);

            return Knights.GetMoves(this.Occupation, enemy.Occupation, Bitboard.Full, path)
                .Union(Bishops.GetMoves(this.Occupation, enemy.Occupation, Bitboard.Full, path))
                .Union(Rooks.GetMoves(this.Occupation, enemy.Occupation, Bitboard.Full, path))
                .Union(Queens.GetMoves(this.Occupation, enemy.Occupation, Bitboard.Full, path))
                .Union(Pawns.GetMovesTwoSquaresForward(notblockers, Bitboard.Full, path))
                .Union(Pawns.GetMovesOneSquareForward(notblockers, Bitboard.Full, path))
                .Union(Pawns.GetCaptures(enemy.Occupation, Bitboard.Full, path, enpassant));
                

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
