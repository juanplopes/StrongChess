using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrongChess.Model
{
    using StrongChess.Model.Sets;

    public struct Board
    {
        public Side White { get; private set; }
        public Side Black { get; private set; }

        public int Rule50Moves { get; private set; }
        public bool IsWhiteToMove { get; private set; }
        
        public Board MakeMove(Move move)
        {
            var result = this;

            


            return result;
        }

        public static Board NewGame()
        {
            var result = new Board();

            result.White = Side.WhiteInitialPosition;
            result.Black = Side.BlackInitialPosition;

            return result;
        }

        
    }
}
