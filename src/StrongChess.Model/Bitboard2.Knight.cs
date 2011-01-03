using System;
using System.Collections.Generic;f
using System.Linq;
using System.Text;

namespace StrongChess.Model
{
    //partial class Bitboard2
    //{

    //    static readonly UInt64[] KnightAttacksBitboardsField =
    //        new UInt64[64];

    //    static void InitializeKinightAttacksBitboards()
    //    {
    //        int[] knightsq = new int[] { -17, -15, -10, -6, 6, 10, 15, 17 };
    //        for (int i = 0; i < 64; i++)
    //        {
    //            UInt64 bboard = 0;
    //            int source_rank = i / 8;
    //            int source_file = i % 8;

    //            for (int j = 0; j < 8; j++)
    //            {
    //                int target = i + knightsq[j];
    //                if (target >= 0 && target <= 63)
    //                {
    //                    int target_rank = target / 8;
    //                    int target_file = target % 8;
    //                    if (Math.Abs(target_file - source_file) <= 2
    //                        && Math.Abs(target_rank - source_rank) <= 2)
    //                        bboard |= SetMasksField[target];
    //                }
    //            }
    //            KnightAttacksBitboardsField[i] = bboard;
    //        }
    //    }

    //    public static UInt64
    //        GetKnightAttacksBitboard(Squares square)
    //    {
    //        return KnightAttacksBitboardsField[(int)square];
    //    }

    //    public static UInt64
    //        GetKnightAttacksBitboard(UInt64 knightsBitboard)
    //    {
    //        return GetKnightAttacksBitboard(knightsBitboard, knightsBitboard);
    //    }

    //    public static UInt64
    //        GetKnightAttacksBitboard(UInt64 knightsBitboard, UInt64 friends)
    //    {
    //        UInt64 result = 0;
    //        while (knightsBitboard > 0)
    //        {
    //            var sq = knightsBitboard.GetLeadingSquare();
    //            knightsBitboard = knightsBitboard.Clear(sq);
    //            result |= GetKnightAttacksBitboard(sq);
    //        }
    //        return result & (~friends);
    //    }
    //}
}
