using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrongChess.Model
{
    public static partial class Bitboard
    {
        static Bitboard()
        {
            InitializeMasks();
        }

        public static int GetBitCount(this UInt64 bitboard)
        {
            return 
                BitCountHelperArrayField[bitboard >> 48] +
                BitCountHelperArrayField[(bitboard >> 32) & 0xffff] +
                BitCountHelperArrayField[(bitboard >> 16) & 0xffff] + 
                BitCountHelperArrayField[bitboard & 0xffff];
        }

        public static Squares GetLeadingSquare(this UInt64 bitboard)
        {
            if (bitboard == 0) return Squares.INVALID;

            if ((bitboard >> 48) != 0)
                return (Squares)LeadingBitHelperArrayField[bitboard >> 48] + 48;

            if ((bitboard >> 32) != 0)
                return (Squares)LeadingBitHelperArrayField[bitboard >> 32] + 32;

            if ((bitboard >> 16) != 0)
                return (Squares)LeadingBitHelperArrayField[bitboard >> 16] + 16;

            return (Squares)LeadingBitHelperArrayField[bitboard];
        }

        public static UInt64 Set(this UInt64 bitboard, Squares square)
        {
            return bitboard | Bitboard.SetMasksField[(int)square];
        }

        public static UInt64 Clear(this UInt64 bitboard, Squares square)
        {
            return bitboard & Bitboard.ClearMasksField[(int)square];
        }

        public static bool IsSet(this UInt64 bitboard, Squares square)
        {
            return (bitboard & Bitboard.SetMasksField[(int)square]) != 0;
        }

        public static bool IsClear(this UInt64 bitboard, Squares square)
        {
            return (bitboard & Bitboard.SetMasksField[(int)square]) == 0;
        }

        public static UInt64 Set(this UInt64 bitboard, Files file)
        {
            return bitboard | SetFileMasksField[(int)file];
        }

        public static UInt64 Set(this UInt64 bitboard, Ranks rank)
        {
            return bitboard | SetRankMasksField[(int)rank];
        }

        public static UInt64 Clear(this UInt64 bitboard, Files file)
        {
            return bitboard & Bitboard.ClearFileMasksField[(int)file];
        }

        public static UInt64 Clear(this UInt64 bitboard, Ranks rank)
        {
            return bitboard & Bitboard.ClearRankMasksField[(int)rank];
        }

        public static bool IsClear(this UInt64 bitboard, Ranks rank)
        {
            return (bitboard & Bitboard.SetRankMasksField[(int)rank]) == 0;
        }

        public static bool IsClear(this UInt64 bitboard, Files file)
        {
            return (bitboard & Bitboard.SetFileMasksField[(int)file]) == 0;
        }



    }
}
