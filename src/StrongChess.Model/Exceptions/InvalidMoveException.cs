using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrongChess.Model.Exceptions
{
    public class InvalidMoveException : Exception
    {
        public Move  Move { get; private set; }
        public Board Board { get; private set;  }

        public InvalidMoveException(Move move, Board board) : 
            base(string.Format("'{0}' is not valid.", move))
            
        {
            this.Board = board;
            this.Move = move;
        }
    }
}
