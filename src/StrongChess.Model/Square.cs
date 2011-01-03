using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrongChess.Model
{
    public struct Square : IBoardUnit
    {

        public Rank Rank { get; private set; }
        public File File { get; private set; }

        public int Index { get { return IndexOf(Rank, File); } }

        public ulong Bitmask { get { return _Bitmasks[Index]; } }

        public Square(Rank rank, File file)
            : this()
        {
            Rank = rank;
            File = file;
        }

        public static int IndexOf(Rank rank, File file)
        {
            return rank * 8 + file;
        }


        private static ulong[] _Bitmasks = new ulong[64];
        static Square()
        {
            for (Rank i = 0; i < 8; i++)
                for (File j = 0; j < 8; j++)
                    _Bitmasks[IndexOf(i, j)] = i.Bitmask & j.Bitmask;
        }

        #region converters
        public static implicit operator int(Square square)
        {
            return square.Index;
        }

        public static implicit operator Square(int square)
        {
            return Square.FromIndex(square);
        }

        public static Square FromIndex(int index)
        {
            return new Square(index / 8, index % 8);
        }

        public static Square FromName(string name)
        {
            return new Square(Rank.FromName(name[1]), File.FromName(name[0]));
        }
        #endregion

        #region object overrides
        public override int GetHashCode()
        {
            return Index.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (object.ReferenceEquals(this, obj)) return true;
            if (!(obj is Square)) return false;
            return Index == ((Square)obj).Index;
        }

        public override string ToString()
        {
            return File.ToString() + Rank.ToString();
        }
        #endregion
    }
}