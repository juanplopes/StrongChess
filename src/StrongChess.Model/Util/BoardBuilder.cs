using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrongChess.Model.Util
{
    public partial struct BoardBuilder
    {
        private Bitboard result;
        private bool inverted;

        private BoardBuilder(Bitboard board, bool inverted)
            : this()
        {
            this.result = board;
            this.inverted = inverted;
        }

        public Bitboard Build()
        {
            return inverted ? result.Inverted : result;
        }

        public BoardBuilder And(IBoardUnit unit)
        {
            return new BoardBuilder(result.Set(unit), inverted);
        }

        public BoardBuilder Except
        {
            get { return new BoardBuilder(~result, !inverted); }
        }

        public static implicit operator Bitboard(BoardBuilder builder)
        {
            return builder.Build();
        }
    }
}
