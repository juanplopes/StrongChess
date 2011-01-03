using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrongChess.Model
{
    public struct Rank : IBoardUnit
    {
        public int Index { get; private set; }
        public ulong Bitmask { get { return _Bitmasks[Index]; } }

        public Rank(int index)
            : this()
        {
            Index = index;
        }

        public static implicit operator int(Rank rank)
        {
            return rank.Index;
        }

        public static implicit operator Rank(int rank)
        {
            return new Rank(rank);
        }

        private static ulong[] _Bitmasks = new ulong[8];
        static Rank()
        {
            for (int i = 0; i < 8; i++)
                _Bitmasks[i] = 0xFFul << i * 8;
        }

        public static Rank FromName(char name)
        {
            return new Rank(name - '1');
        }

        #region object overrides
        public override int GetHashCode()
        {
            return Index.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (object.ReferenceEquals(this, obj)) return true;
            if (!(obj is Rank)) return false;
            return Index == ((Rank)obj).Index;
        }

        public override string ToString()
        {
            return ((char)(Index + '1')).ToString();
        }
        #endregion
    }
}
