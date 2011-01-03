using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrongChess.Model
{
    public interface IBoardUnit
    {
        int Index { get; }
        ulong Bitmask { get; }
    }
}
