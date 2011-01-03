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

            int r = 0, shift = 0;

            shift = (value > 0xFFFFFFFF ? 1 : 0) << 5; value >>= shift; r |= shift;
            shift = (value > 0xFFFF ? 1 : 0) << 4; value >>= shift; r |= shift;
            shift = (value > 0xFF ? 1 : 0) << 3; value >>= shift; r |= shift;
            shift = (value > 0xF ? 1 : 0) << 2; value >>= shift; r |= shift;
            shift = (value > 0x3 ? 1 : 0) << 1; value >>= shift; r |= shift;
            r |= (int)(value >> 1);
            return r;
        }
    }
}
