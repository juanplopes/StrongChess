using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrongChess.Model
{
    public enum MoveTypes
    {
        Normal,
        Castling,
        PawnToQueenPromotion,
        PawnToRookPromotion,
        PawnToKnightPromotion,
        PawnToBishopPromotion
    }

    public struct Move
    {
        public Square From { get; private set; }
        public Square To { get; private set; }
        public MoveTypes Type { get; private set; }

        public Move(Square from, Square to, MoveTypes type = MoveTypes.Normal)
            : this()
        {
            this.From = from;
            this.To = to;
            this.Type = type;
        }

        public bool IsValid
        {
            get
            {
                if (this.From == this.To)
                    return false;

                return true;
            }
        }

        public override string ToString()
        {
            return string.Format("{0} > {1} ({2})", From, To, Type);
        }
    }
}
