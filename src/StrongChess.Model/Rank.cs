﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrongChess.Model
{
    public struct Rank : IBoardUnit
    {
        public int Index { get; private set; }
        public ulong Bitmask { get { return _Bitmasks[Index]; } }

        public bool IsValid
        {
            get { return Index >= 0 && Index < 8; }
        }


        public Rank(int index)
            : this()
        {
            Index = index;
        }

        public Rank(string name) 
            : this(name[0] - '1') { }

        public int DistanceFrom(Rank otherRank)
        {
            return Math.Abs(Index - otherRank.Index);
        }



        public static implicit operator int(Rank rank)
        {
            return rank.Index;
        }

        public static implicit operator Rank(int rank)
        {
            return new Rank(rank);
        }

        public static implicit operator Rank(string rank)
        {
            return new Rank(rank);
        }

        private static ulong[] _Bitmasks = new ulong[8];
        static Rank()
        {
            for (int i = 0; i < 8; i++)
                _Bitmasks[i] = 0xFFul << i * 8;
        }



        public override string ToString()
        {
            if (!IsValid) return "#";

            return ((char)(Index + '1')).ToString();
        }


    }
}
