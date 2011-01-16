using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrongChess.Model
{
    public struct Square : IBoardUnit
    {
        private int index;
        public int Index { get { return index; } }

        public Rank Rank { get { return index >> 3; } }
        public File File { get { return index & 7; } }
        public DiagonalNE DiagonalNE { get { return new DiagonalNE(File - Rank + 7); } }
        public DiagonalNW DiagonalNW { get { return new DiagonalNW(File + Rank); } }

        public bool IsValid
        {
            get { return File.IsValid && Rank.IsValid; }
        }

        public Bitboard AsBoard { get { return masks[index]; } }

        public Square(int index) : this() { this.index = index; }
        public Square(Rank rank, File file) : this(IndexOf(rank, file)) { }
        public Square(string name) : this(name[1].ToString(), name[0].ToString()) { }

        public override string ToString()
        {
            return File.ToString() + Rank.ToString();
        }

        #region static
        public static int IndexOf(Rank rank, File file)
        {
            if (!rank.IsValid || !file.IsValid) return -8;

            return rank * 8 + file;
        }


        static readonly Bitboard[] masks = new Bitboard[64];
        static Square()
        {
            for (Rank i = 0; i < 8; i++)
                for (File j = 0; j < 8; j++)
                    masks[IndexOf(i, j)] = i.AsBoard.Intersect(j);
        }


        public static implicit operator int(Square square)
        {
            return square.index;
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