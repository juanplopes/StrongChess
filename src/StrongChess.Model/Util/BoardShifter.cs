using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrongChess.Model.Util
{
    public static class BoardShifter
    {
        static ulong[] vshift = new ulong[15];
        static ulong[] hshift = new ulong[15];

        static BoardShifter()
        {
            vshift[7] = 0;
            hshift[7] = 0;

            for (int i = 6; i >= 0; i--)
                vshift[i] = vshift[i + 1] | (0xFFul << ((6 - i) * 8));

            for (int i = 0; i <= 6; i++)
                vshift[i + 8] = ~vshift[i];

            for (int i = 6; i >= 0; i--)
                hshift[i] = hshift[i + 1] | (0x0101010101010101ul << (6 - i));

            for (int i = 0; i <= 6; i++)
                hshift[i + 8] = ~hshift[i];

        }

        public static ulong ChessShift(this ulong value, int ranks, int files)
        {
            value = value & ~(vshift[ranks + 7] | hshift[files + 7]);
            var shift = ranks * 8 + files;
            return shift > 0 ? value << shift : value >> -shift;
        }
    }
}