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

            foreach (var e in new[] { 32, 16, 8, 4, 2, 1 })
                if (value >= 1ul << e)  { value >>= e; r += e; }

            return r;
        }
    }
}
