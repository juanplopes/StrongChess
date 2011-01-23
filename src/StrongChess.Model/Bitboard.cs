using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StrongChess.Model.Util;

namespace StrongChess.Model
{
    public struct Bitboard : IBoardUnit
    {
        private ulong value;

        public ulong Value { get { return value; } }
        public Bitboard AsBoard { get { return this; } }
        public bool IsValid { get { return true; } }


        public Bitboard(ulong value) : this() { this.value = value; }

        public Bitboard And(params IBoardUnit[] unit)
        {
            return value |
                unit.Aggregate(0ul, (s, v) => s | v.AsBoard.value);
        }

        public Bitboard Except(params IBoardUnit[] unit)
        {
            return value &
                unit.Aggregate(~0ul, (s, v) => s & ~v.AsBoard.value);
        }

        public Bitboard Shift(int ranks, int files)
        {
            return value.ChessShift(ranks, files);
        }

        public bool IsSet(IBoardUnit unit)
        {
            var board = unit.AsBoard;
            return (value & board.value) == board.value;
        }

        public bool IsClear(IBoardUnit unit)
        {
            return !Contains(unit);
        }

        public bool Contains(IBoardUnit bu)
        {
            return (this.value & bu.AsBoard.value) > 0;
        }

        public Bitboard Intersect(IBoardUnit unit)
        {
            return value & unit.AsBoard.value;
        }


        public Bitboard Inverted
        {
            get { return ~value; }
        }

        public bool IsEmpty
        {
            get { return value == 0; }
        }

        public int BitCount
        {
            get { return value.PopCount(); }
        }

        public Square LowestSquare { get { return value.BitScanForward(); } }
        public Square HighestSquare { get { return value.BitScanReverse(); } }

        public IEnumerable<Square> Squares
        {
            get
            {
                var bcopy = value;
                while (bcopy != 0)
                {
                    Square lead = bcopy.BitScanForward();
                    yield return lead;
                    bcopy = bcopy & ~lead.AsBoard.value;
                }
            }
        }

        #region static

        public static implicit operator ulong(Bitboard board)
        {
            return board.value;
        }

        public static Bitboard Full { get { return new Bitboard(~0ul); } }
        public static Bitboard Empty { get { return new Bitboard(0ul); } }

        public static BoardBuilder With
        {
            get { return new BoardBuilder(); }
        }

        public static implicit operator Bitboard(ulong board)
        {
            return new Bitboard(board);
        }

        public override string ToString()
        {
            return "[" + string.Join("; ", Squares.Select(x => x.ToString()).ToArray()) + "]";
        }

        #endregion

    }
}
