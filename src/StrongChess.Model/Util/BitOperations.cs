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

        public static int BitScanReverse(ulong value)
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


        static int[] index64 = new[] 
        {
           63,  0, 58,  1, 59, 47, 53,  2,
           60, 39, 48, 27, 54, 33, 42,  3,
           61, 51, 37, 40, 49, 18, 28, 20,
           55, 30, 34, 11, 43, 14, 22,  4,
           62, 57, 46, 52, 38, 26, 32, 41,
           50, 36, 17, 19, 29, 10, 13, 21,
           56, 45, 25, 31, 35, 16,  9, 12,
           44, 24, 15,  8, 23,  7,  6,  5
        };

        public static int BitScanForward(ulong value)
        {
            if (value == 0) return -1;
            const ulong debruijn64 = 0x07EDD5E59A4E28C2ul;
            return index64[((value & ~value + 1) * debruijn64) >> 58];
        }
    }
}
