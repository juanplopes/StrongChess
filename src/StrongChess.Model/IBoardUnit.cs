using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrongChess.Model
{
    public interface IBoardUnit
    {
        Bitboard AsBoard { get; }
        bool IsValid { get; }
    }
}
