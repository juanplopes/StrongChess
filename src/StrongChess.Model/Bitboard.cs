﻿using System;
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
        public Bitboard(ulong value) : this() { this.value = value; }

        public Bitboard Set(params IBoardUnit[] unit)
        {
            return new Bitboard(
                value | unit.Aggregate(0ul, (s, v) => s | v.Bitmask));
        }

        public Bitboard Clear(params IBoardUnit[] unit)
        {
            return new Bitboard(
                value & unit.Aggregate(~0ul, (s, v) => s & ~v.Bitmask));
        }

        public bool IsSet(IBoardUnit unit)
        {
            return (value & unit.Bitmask) != 0;
        }

        public bool IsClear(IBoardUnit unit)
        {
            return !IsSet(unit);
        }

        public bool Contains(IBoardUnit bu)
        {
            return (this.value & bu.Bitmask) > 0;
        }

        public bool Contains(ulong board)
        {
            return (this.value & board) > 0;
        }

        public bool IsEmpty
        {
            get { return value == 0; }
        }

        public int BitCount
        {
            get { return value.PopCount(); }
        }

        public Square? LeadingSquare
        {
            get
            {
                var index = value.BitScanReverse();
                if (index == -1) return null;
                return index;
            }
        }

        public IEnumerable<Square> GetSetSquares()
        {
            var bcopy = value;
            while (bcopy != 0)
            {
                Square lead = bcopy.BitScanForward();
                yield return lead;
                bcopy = bcopy & ~lead.Bitmask;
            }
        }

        #region static

        public static implicit operator ulong(Bitboard board)
        {
            return board.value;
        }

        public static Bitboard Full
        {
            get
            {
                return new Bitboard(ulong.MaxValue);
            }
        }

        public static Bitboard Empty
        {
            get
            {
                return new Bitboard(0);
            }
        }

        public static implicit operator Bitboard(ulong board)
        {
            return new Bitboard(board);
        }


        public static Bitboard operator |(Bitboard bitboard, IBoardUnit bu)
        {
            return new Bitboard(bitboard.Value | bu.Bitmask);
        }

        public override string ToString()
        {
            return "[" + string.Join("; ", GetSetSquares().Select(x => x.ToString()).ToArray()) + "]";
        }

        #endregion

        #region IBoardUnit Members

        public ulong Bitmask
        {
            get { return value; }
        }

        public bool IsValid
        {
            get { return true; }
        }

        #endregion
    }
}
