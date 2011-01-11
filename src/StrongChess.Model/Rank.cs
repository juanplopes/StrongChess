using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrongChess.Model
{
  public struct Rank : IBoardUnit
  {
    public int Index { get; private set; }
    public ulong Bitmask { get { return _Bitmasks[Index]; } }

    public bool IsValid
    {
      get { return Index >= 0 && Index < 8; }
    }

    public Rank(int index) : this() { Index = index; }
    public Rank(string name) : this(name[0] - '1') { }

    public int DistanceFrom(Rank otherRank)
    {
      return Math.Abs(Index - otherRank.Index);
    }

    public bool Contains(IBoardUnit bu)
    {
      return (this.Bitmask & bu.Bitmask) > 0;
    }

    public bool Contains(ulong board)
    {
      return (this.Bitmask & board) > 0;
    }

    public override string ToString()
    {
      if (!IsValid) return "#";

      return ((char)(Index + '1')).ToString();
    }

    #region static
    static readonly ulong[] _Bitmasks = new ulong[64];
    static Rank()
    {
      for (int i = 0; i < 8; i++)
        _Bitmasks[i] = 0xFFul << i * 8;
    }

    public static implicit operator int(Rank rank)
    {
      return rank.Index;
    }

    public static implicit operator Rank(int rank)
    {
      return new Rank(rank);
    }

    public static implicit operator Rank(string rank)
    {
      return new Rank(rank);
    }

    public static Bitboard operator |(Rank rank, IBoardUnit bu)
    {
      return rank.Bitmask | bu.Bitmask;
    }


    #endregion
  }

  public static class Ranks
  {
    public readonly static Rank One = new Rank(0);
    public readonly static Rank Two = new Rank(1);
    public readonly static Rank Three = new Rank(2);
    public readonly static Rank Four = new Rank(3);
    public readonly static Rank Five = new Rank(4);
    public readonly static Rank Six = new Rank(5);
    public readonly static Rank Seven = new Rank(6);
    public readonly static Rank Eight = new Rank(7);
  }
}
