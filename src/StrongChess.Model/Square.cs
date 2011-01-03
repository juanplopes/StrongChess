using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrongChess.Model
{
    public struct Square : IBoardUnit
    {
        public int Index { get; private set; }

        public Rank Rank { get { return Index / 8; } }
        public File File { get { return Index % 8; } }

        public bool IsValid
        {
            get { return File.IsValid && Rank.IsValid; }
        }

        public ulong Bitmask { get { return _Bitmasks[Index]; } }

        public Square(int index) : this() { Index = index; }
        public Square(Rank rank, File file) : this(IndexOf(rank, file)) { }
        public Square(string name) : this(name[1].ToString(), name[0].ToString()) { }

        public override string ToString()
        {
            return File.ToString() + Rank.ToString();
        }

        #region static
        public static int IndexOf(Rank rank, File file)
        {
            return rank * 8 + file;
        }


        static readonly ulong[] _Bitmasks = new ulong[64];
        static Square()
        {
            for (Rank i = 0; i < 8; i++)
                for (File j = 0; j < 8; j++)
                    _Bitmasks[IndexOf(i, j)] = i.Bitmask & j.Bitmask;
        }

        public static implicit operator int(Square square)
        {
            return square.Index;
        }

        public static implicit operator Square(int square)
        {
            return new Square(square);
        }

        public static implicit operator Square(string square)
        {
            return new Square(square);
        }

        #endregion

    }
}