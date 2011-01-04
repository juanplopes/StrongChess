using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace StrongChess.Model.Util
{
    public static class BitOperations
    {
        public static int PopCountIn(ulong x)
        {
            unchecked
            {
                const ulong h01 = 0x0101010101010101;
                const ulong m1 = 0x5555555555555555;
                const ulong m2 = 0x3333333333333333;
                const ulong m4 = 0x0f0f0f0f0f0f0f0f;

                x -= (x >> 1) & m1;
                x = (x & m2) + ((x >> 2) & m2);
                x = (x + (x >> 4)) & m4;
                return (int)((x * h01) >> 56);
            }
        }

        public static int HighestBitPosition(ulong value)
        {
            unchecked
            {
                if (value == 0) return -1;

                int r = 0;

                if (value > 0x00000000FFFFFFFF) { value >>= 32; r += 32; }
                if (value > 0x000000000000FFFF) { value >>= 16; r += 16; }
                if (value > 0x00000000000000FF) { value >>= 08; r += 08; }
                if (value > 0x000000000000000F) { value >>= 04; r += 04; }
                if (value > 0x0000000000000003) { value >>= 02; r += 02; }
                if (value > 0x0000000000000001) { value >>= 01; r += 01; }

                return r;
            }
        }
    }
}
