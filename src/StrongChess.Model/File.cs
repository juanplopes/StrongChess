﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrongChess.Model
{
    public struct File : IBoardUnit
    {
        public int Index { get; private set; }
        public ulong Bitmask { get { return _Bitmasks[Index]; } }

        public bool IsValid
        {
            get { return Index >= 0 && Index < 8; }
        }


        public File(int index)
            : this()
        {
            Index = index;
        }

        public File(string name) 
            : this(char.ToUpperInvariant(name[0]) - 'A') {}

        public int DistanceFrom(File otherFile)
        {
            return Math.Abs(Index - otherFile.Index);
        }


        public static implicit operator int(File file)
        {
            return file.Index;
        }

        public static implicit operator File(int file)
        {
            return new File(file);
        }
        public static implicit operator File(string file)
        {
            return new File(file);
        }


        private static ulong[] _Bitmasks = new ulong[8];
        static File()
        {
            for (int i = 0; i < 8; i++)
                _Bitmasks[i] = 0x0101010101010101ul << i;
        }



        #region object overrides
        public override int GetHashCode()
        {
            return Index.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (object.ReferenceEquals(this, obj)) return true;
            if (!(obj is File)) return false;
            return Index == ((File)obj).Index;
        }

        public override string ToString()
        {
            return ((char)(Index + 'A')).ToString();
        }
        #endregion


    }

}
