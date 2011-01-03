using System;
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

        public File(int index) : this() { Index = index; }
        public File(string name) : this(char.ToUpperInvariant(name[0]) - 'A') { }

        public int DistanceFrom(File otherFile)
        {
            return Math.Abs(Index - otherFile.Index);
        }

        public override string ToString()
        {
            if (!IsValid) return "#";

            return ((char)(Index + 'A')).ToString();
        }

        #region static

        static readonly ulong[] _Bitmasks = new ulong[64];
        static File()
        {
            for (int i = 0; i < 8; i++)
                _Bitmasks[i] = 0x0101010101010101ul << i;
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

        #endregion
    }

}
