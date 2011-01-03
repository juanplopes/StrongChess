using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrongChess.Model.Util
{
    public static class BitOperations
    {
        public static int PopCountIn(ulong value)
        {
            unchecked
            {
                const ulong mask0 = 0x0101010101010101;
                const ulong mask1 = ~0ul / 3 << 1;
                const ulong mask2 = ~0ul / 5;
                const ulong mask3 = ~0ul / 17;
                value -= (mask1 & value) >> 1;
                value = (value & mask2) + ((value >> 2) & mask2);
                value += value >> 4;
                value &= mask3;
                return (int)(((value * mask0) >> 56));
            }
        }

        public static int HighestBitPosition(ulong value)
        {
            if (value == 0) return -1;

            int r = 0;

            if (value > 0xFFFFFFFFul) { value >>= 32; r += 32; }
            if (value > 0xFFFFul) { value >>= 16; r += 16; }
            if (value > 0xFFul) { value >>= 8; r += 8; }
            if (value > 0xFul) { value >>= 4; r += 4; }
            if (value > 0x3ul) { value >>= 2; r += 2; }
            if (value > 0x1ul) { r += 1; };

            return r;
        }
    }
}
