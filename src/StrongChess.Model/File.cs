﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrongChess.Model
{
    public struct File : IBoardUnit
    {
        private int index;
        public int Index { get { return index; } }
        public Bitboard AsBoard { get { return Bitmask; } }
        public ulong Bitmask { get { return masks[index]; } }

        public bool IsValid
        {
            get { return index >= 0 && index < 8; }
        }

        public File(int index) : this() { this.index = index; }
        public File(string name) : this(char.ToUpperInvariant(name[0]) - 'A') { }

        public int DistanceFrom(File otherFile)
        {
            return Math.Abs(index - otherFile.index);
        }

        public override string ToString()
        {
            if (!IsValid) return "#";

            return ((char)(index + 'A')).ToString();
        }

        public bool Contains(IBoardUnit bu)
        {
            return (this.Bitmask & bu.Bitmask) > 0;
        }

        public bool Contains(ulong board)
        {
            return (this.Bitmask & board) > 0;
        }


        #region static

        static readonly ulong[] masks = new ulong[64];
        static File()
        {
            for (int i = 0; i < 8; i++)
                masks[i] = 0x0101010101010101ul << i;
        }

        public static implicit operator int(File file)
        {
            return file.index;
        }

        public static implicit operator File(int file)
        {
            return new File(file);
        }
        public static implicit operator File(string file)
        {
            return new File(file);
        }
        #endregion
    }


}
