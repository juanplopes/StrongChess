using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StrongChess.Model.Pieces;

namespace StrongChess.Model
{
    public struct AttackMasks
    {
        public Square Target { get; private set; }

        public Bitboard Knights
        {
            get
            {
                return Rules.For<Knight>().GetMoveBoard(Target);
            }
        }

        public Bitboard Rooks
        {
            get
            {
                var r = new Rays(Target);
                return r.N | r.S | r.E | r.W;
            }
        }

        public Bitboard Bishops
        {
            get
            {
                var r = new Rays(Target);
                return r.NW | r.SW | r.NE | r.SE;
            }
        }

        public Bitboard Queens
        {
            get
            {
                return Rooks | Bishops;
            }
        }

        public Bitboard WhitePawns
        {
            get
            {
                return _WhitePawns[(int)Target];
            }
        }

        public Bitboard BlackPawns
        {
            get
            {
                return _BlackPawns[(int)Target];
            }
        }

        public AttackMasks(Square target)
            : this()
        {
            Target = target;
        }

        static Bitboard[] _WhitePawns = new Bitboard[64];
        static Bitboard[] _BlackPawns = new Bitboard[64];
        static AttackMasks()
        {
            for (int i = 0; i < 64; i++)
            {
                Bitboard target = (1ul << i);
                _WhitePawns[i] = target.Shift(-1, -1) | target.Shift(-1, 1);
                _BlackPawns[i] = target.Shift(1, -1) | target.Shift(1, 1);
            }
        }
    }
}
