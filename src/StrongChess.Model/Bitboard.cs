using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StrongChess.Model.Util;

namespace StrongChess.Model
{
    public struct Bitboard
    {
        public ulong Value { get; private set; }

        public Bitboard(ulong value)
            : this()
        {
            this.Value = value;
        }

        public Bitboard Set(params IBoardUnit[] unit)
        {
            return new Bitboard(
                Value | unit.Aggregate(0ul, (s, v) => s | v.Bitmask));
        }

        public Bitboard Clear(params IBoardUnit[] unit)
        {
            return new Bitboard(
                Value & unit.Aggregate(~0ul, (s, v) => s & ~v.Bitmask));
        }

        public bool IsSet(IBoardUnit unit)
        {
            return (Value & unit.Bitmask) != 0;
        }

        public bool IsClear(IBoardUnit unit)
        {
            return !IsSet(unit);
        }

        public bool IsEmpty
        {
            get { return Value == 0; }
        }

        public int BitCount
        {
            get
            {
                return BitOperations.PopCountIn(Value);
            }
        }

        public Square? LeadingSquare
        {
            get
            {
                var index = BitOperations.HighestBitPosition(Value);
                if (index == -1) return null;
                return Square.FromIndex(index);
            }
        }

        public IEnumerable<Square> GetSetSquares()
        {
            var bcopy = this;
            while (!bcopy.IsEmpty)
            {
                var lead = bcopy.LeadingSquare;
                yield return lead.Value;
                bcopy = bcopy.Clear(lead);
            }


        }

    }
}
