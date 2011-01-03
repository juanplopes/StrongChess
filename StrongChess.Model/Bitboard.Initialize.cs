using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrongChess.Model
{
    partial class Bitboard
    {
        private static void InitializeMasks()
        {
            InitializeSquareMasks();
            InitializeRankMasks();
            InitializeFileMasks();
            InitializeLeadingBitHelperArray();
            InitializeBitCountHelperArray();

            InitializeKinightAttacksBitboards();
        }

        private static void InitializeFileMasks()
        {
            Bitboard.SetFileMasksField[0] = 1;
            for (int i = 1; i < 8; i++)
                SetFileMasksField[0] = SetFileMasksField[0] | (SetFileMasksField[0] << 8);

            for (int i = 1; i < 8; i++)
                SetFileMasksField[i] = SetFileMasksField[i - 1] << 1;

            for (int i = 0; i < 8; i++)
                ClearFileMasksField[i] = ~SetFileMasksField[i];
        }

        private static void InitializeRankMasks()
        {
            SetRankMasksField[0] = 255;
            ClearRankMasksField[0] = ~((UInt64)255);
            for (int i = 1; i < 8; i++)
            {
                SetRankMasksField[i] =
                    SetRankMasksField[i - 1] << 8;
                ClearRankMasksField[i] =
                    ~SetRankMasksField[i - 1] << 8;
            }
        }

        private static void InitializeSquareMasks()
        {
            for (int i = 0; i < 64; i++)
            {
                SetMasksField[i] =
                    (UInt64)1 << i;

                ClearMasksField[i] =
                    ~SetMasksField[i];
            }
        }

        private static void InitializeBitCountHelperArray ()
        {
           int i, j, n;

           BitCountHelperArrayField[0] = 0;
           BitCountHelperArrayField[1] = 1; 
           i = 1;
           for (n = 2; n <= 16; n++)
           {
              i <<= 1;
              for (j = i; j <= i + (i-1); j++)
                  BitCountHelperArrayField[j] = 
                      (byte)(1 + BitCountHelperArrayField[j - i]); 
           }
        }
        
        static readonly byte[] BitCountHelperArrayField =
            new byte[65536];

        private static void InitializeLeadingBitHelperArray()
        {
            int i, j, n;
            
            n = 1;
            for (i = 0; i < 16; i++)
            {
                for (j = n; j < n + n; j++)
                    LeadingBitHelperArrayField[j] = (byte)(i);
                n += n;
            }
        }

        static readonly byte[] LeadingBitHelperArrayField =
            new byte[65536];

        static readonly UInt64[] SetRankMasksField =
            new UInt64[8];

        static readonly UInt64[] ClearRankMasksField =
            new UInt64[8];

        static readonly UInt64[] SetFileMasksField =
            new UInt64[8];

        static readonly UInt64[] ClearFileMasksField =
            new UInt64[8];

        static readonly UInt64[] ClearMasksField =
            new UInt64[64];

        static readonly UInt64[] SetMasksField =
            new UInt64[64];
    }
}
