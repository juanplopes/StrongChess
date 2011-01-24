using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StrongChess.Model.Sets;
using StrongChess.Model.Pieces;

namespace StrongChess.Model
{
    public struct Square : IBoardUnit
    {
        private int index;
        public int Index { get { return index; } }

        public Rank Rank { get { return index >> 3; } }
        public File File { get { return index & 7; } }
        public DiagonalNE DiagonalNE { get { return File - Rank + 7; } }
        public DiagonalNW DiagonalNW { get { return File + Rank; } }
        public Rays RayTo { get { return new Rays(this); } }

        public bool IsValid
        {
            get { return index >= 0 && index <= 64; }
        }

        public Bitboard AsBoard { get { return masks[index]; } }

        public Square(int index) : this() { this.index = index; }
        public Square(Rank rank, File file) : this(IndexOf(rank, file)) { }
        public Square(string name) : this(name[1].ToString(), name[0].ToString()) { }

        public override string ToString()
        {
            return File.ToString() + Rank.ToString();
        }

        public Bitboard AttackedFrom(Side white, Side black)
        {
            var allpieces = white.Occupation | black.Occupation;
            AttackMasks m = new AttackMasks(this);

            Bitboard result =
                (white.Pawns.Locations & m.WhitePawns) |
                (black.Pawns.Locations & m.BlackPawns);

            result |= (m.Knights & (white.Knights.Locations | black.Knights.Locations));

            Bitboard bsliders = (white.Bishops.Locations | black.Bishops.Locations |
                white.Queens.Locations | black.Queens.Locations) & m.Bishops;

            Bitboard rsliders = (white.Rooks.Locations | black.Rooks.Locations |
                white.Queens.Locations | black.Queens.Locations) & m.Rooks;

            if (bsliders != Bitboard.Empty)
                result |= (bsliders & Rules.For<Bishop>().GetMoveBoard(this, Bitboard.Empty, allpieces));

            if (rsliders != Bitboard.Empty)
                result |= (rsliders & Rules.For<Rook>().GetMoveBoard(this, Bitboard.Empty, allpieces));

            return result;
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