using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrongChess.Model
{
  public struct Square : IBoardUnit
  {
    public int Index { get; private set; }

    public Rank Rank { get { return Index / 8; } }
    public File File { get { return Index % 8; } }

    public bool IsValid
    {
      get { return File.IsValid && Rank.IsValid; }
    }

    public ulong Bitmask { get { return _Bitmasks[Index]; } }

    public Square(int index) : this() { Index = index; }
    public Square(Rank rank, File file) : this(IndexOf(rank, file)) { }
    public Square(string name) : this(name[1].ToString(), name[0].ToString()) { }

    public override string ToString()
    {
      return File.ToString() + Rank.ToString();
    }

    #region static
    public static int IndexOf(Rank rank, File file)
    {
      if (!rank.IsValid || !file.IsValid) return -8;

      return rank * 8 + file;
    }


    static readonly ulong[] _Bitmasks = new ulong[64];
    static Square()
    {
      for (Rank i = 0; i < 8; i++)
        for (File j = 0; j < 8; j++)
          _Bitmasks[IndexOf(i, j)] = i.Bitmask & j.Bitmask;
    }


    public static implicit operator int(Square square)
    {
      return square.Index;
    }

    public static implicit operator Square(int square)
    {
      return new Square(square);
    }

    public static implicit operator Square(string square)
    {
      return new Square(square);
    }

    public static Bitboard operator |(Square square, IBoardUnit bu)
    {
      return square.Bitmask | bu.Bitmask;
    }
    #endregion
  }

  public static class Squares
  {
    public readonly static Square A1 = new Square("A1");
    public readonly static Square A2 = new Square("A2");
    public readonly static Square A3 = new Square("A3");
    public readonly static Square A4 = new Square("A4");
    public readonly static Square A5 = new Square("A5");
    public readonly static Square A6 = new Square("A6");
    public readonly static Square A7 = new Square("A7");
    public readonly static Square A8 = new Square("A8");

    public readonly static Square B1 = new Square("B1");
    public readonly static Square B2 = new Square("B2");
    public readonly static Square B3 = new Square("B3");
    public readonly static Square B4 = new Square("B4");
    public readonly static Square B5 = new Square("B5");
    public readonly static Square B6 = new Square("B6");
    public readonly static Square B7 = new Square("B7");
    public readonly static Square B8 = new Square("B8");

    public readonly static Square C1 = new Square("C1");
    public readonly static Square C2 = new Square("C2");
    public readonly static Square C3 = new Square("C3");
    public readonly static Square C4 = new Square("C4");
    public readonly static Square C5 = new Square("C5");
    public readonly static Square C6 = new Square("C6");
    public readonly static Square C7 = new Square("C7");
    public readonly static Square C8 = new Square("C8");

    public readonly static Square D1 = new Square("D1");
    public readonly static Square D2 = new Square("D2");
    public readonly static Square D3 = new Square("D3");
    public readonly static Square D4 = new Square("D4");
    public readonly static Square D5 = new Square("D5");
    public readonly static Square D6 = new Square("D6");
    public readonly static Square D7 = new Square("D7");
    public readonly static Square D8 = new Square("D8");

    public readonly static Square E1 = new Square("E1");
    public readonly static Square E2 = new Square("E2");
    public readonly static Square E3 = new Square("E3");
    public readonly static Square E4 = new Square("E4");
    public readonly static Square E5 = new Square("E5");
    public readonly static Square E6 = new Square("E6");
    public readonly static Square E7 = new Square("E7");
    public readonly static Square E8 = new Square("E8");

    public readonly static Square F1 = new Square("F1");
    public readonly static Square F2 = new Square("F2");
    public readonly static Square F3 = new Square("F3");
    public readonly static Square F4 = new Square("F4");
    public readonly static Square F5 = new Square("F5");
    public readonly static Square F6 = new Square("F6");
    public readonly static Square F7 = new Square("F7");
    public readonly static Square F8 = new Square("F8");

    public readonly static Square G1 = new Square("G1");
    public readonly static Square G2 = new Square("G2");
    public readonly static Square G3 = new Square("G3");
    public readonly static Square G4 = new Square("G4");
    public readonly static Square G5 = new Square("G5");
    public readonly static Square G6 = new Square("G6");
    public readonly static Square G7 = new Square("G7");
    public readonly static Square G8 = new Square("G8");

    public readonly static Square H1 = new Square("H1");
    public readonly static Square H2 = new Square("H2");
    public readonly static Square H3 = new Square("H3");
    public readonly static Square H4 = new Square("H4");
    public readonly static Square H5 = new Square("H5");
    public readonly static Square H6 = new Square("H6");
    public readonly static Square H7 = new Square("H7");
    public readonly static Square H8 = new Square("H8");
  }
  
}