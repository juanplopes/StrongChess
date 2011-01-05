using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrongChess.Model
{
    public struct Rank : IBoardUnit
    {
        private int index;
        public int Index { get { return index; } }
        public ulong Bitmask { get { return _Bitmasks[index]; } }

        public bool IsValid
        {
            get { return index >= 0 && index < 8; }
        }

        public Rank(int index) : this() { this.index = index; }
        public Rank(string name) : this(name[0] - '1') { }

        public int DistanceFrom(Rank otherRank)
        {
            return Math.Abs(index - otherRank.index);
        }

        public override string ToString()
        {
            if (!IsValid) return "#";

            return ((char)(index + '1')).ToString();
        }

        #region static
        static readonly ulong[] _Bitmasks = new ulong[64];
        static Rank()
        {
            for (int i = 0; i < 8; i++)
                _Bitmasks[i] = 0xFFul << i * 8;
        }

        public static implicit operator int(Rank rank)
        {
            return rank.index;
        }

        public static implicit operator Rank(int rank)
        {
            return new Rank(rank);
        }

        public static implicit operator Rank(string rank)
        {
            return new Rank(rank);
        }
        #endregion
    }
}
