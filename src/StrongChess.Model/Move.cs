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

        public static bool operator ==(Move move1, Move move2)
        {
            return move1.From == move2.From &&
                move1.To == move2.To &&
                move1.Type == move2.Type;
        }

        public static bool operator !=(Move move1, Move move2)
        {
            return move1.From != move2.From ||
                move1.To != move2.To ||
                move1.Type != move2.Type;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Move)) return false;
            return this == (Move) obj;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    public static class MoveExtensionMethods
    {
        public static Bitboard AsMoveboard(this IEnumerable<Move> moves)
        {
            var targets = from m in moves
                          select m.To.AsBoard;

            return targets.Aggregate((a, b) => a | b);
        }
    }
}
