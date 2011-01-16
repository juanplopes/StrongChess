using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrongChess.Model.Util
{
    public partial struct BoardBuilder
    {
        public BoardBuilder A1 { get { return And(new Square(0)); } }
        public BoardBuilder B1 { get { return And(new Square(1)); } }
        public BoardBuilder C1 { get { return And(new Square(2)); } }
        public BoardBuilder D1 { get { return And(new Square(3)); } }
        public BoardBuilder E1 { get { return And(new Square(4)); } }
        public BoardBuilder F1 { get { return And(new Square(5)); } }
        public BoardBuilder G1 { get { return And(new Square(6)); } }
        public BoardBuilder H1 { get { return And(new Square(7)); } }
        public BoardBuilder A2 { get { return And(new Square(8)); } }
        public BoardBuilder B2 { get { return And(new Square(9)); } }
        public BoardBuilder C2 { get { return And(new Square(10)); } }
        public BoardBuilder D2 { get { return And(new Square(11)); } }
        public BoardBuilder E2 { get { return And(new Square(12)); } }
        public BoardBuilder F2 { get { return And(new Square(13)); } }
        public BoardBuilder G2 { get { return And(new Square(14)); } }
        public BoardBuilder H2 { get { return And(new Square(15)); } }
        public BoardBuilder A3 { get { return And(new Square(16)); } }
        public BoardBuilder B3 { get { return And(new Square(17)); } }
        public BoardBuilder C3 { get { return And(new Square(18)); } }
        public BoardBuilder D3 { get { return And(new Square(19)); } }
        public BoardBuilder E3 { get { return And(new Square(20)); } }
        public BoardBuilder F3 { get { return And(new Square(21)); } }
        public BoardBuilder G3 { get { return And(new Square(22)); } }
        public BoardBuilder H3 { get { return And(new Square(23)); } }
        public BoardBuilder A4 { get { return And(new Square(24)); } }
        public BoardBuilder B4 { get { return And(new Square(25)); } }
        public BoardBuilder C4 { get { return And(new Square(26)); } }
        public BoardBuilder D4 { get { return And(new Square(27)); } }
        public BoardBuilder E4 { get { return And(new Square(28)); } }
        public BoardBuilder F4 { get { return And(new Square(29)); } }
        public BoardBuilder G4 { get { return And(new Square(30)); } }
        public BoardBuilder H4 { get { return And(new Square(31)); } }
        public BoardBuilder A5 { get { return And(new Square(32)); } }
        public BoardBuilder B5 { get { return And(new Square(33)); } }
        public BoardBuilder C5 { get { return And(new Square(34)); } }
        public BoardBuilder D5 { get { return And(new Square(35)); } }
        public BoardBuilder E5 { get { return And(new Square(36)); } }
        public BoardBuilder F5 { get { return And(new Square(37)); } }
        public BoardBuilder G5 { get { return And(new Square(38)); } }
        public BoardBuilder H5 { get { return And(new Square(39)); } }
        public BoardBuilder A6 { get { return And(new Square(40)); } }
        public BoardBuilder B6 { get { return And(new Square(41)); } }
        public BoardBuilder C6 { get { return And(new Square(42)); } }
        public BoardBuilder D6 { get { return And(new Square(43)); } }
        public BoardBuilder E6 { get { return And(new Square(44)); } }
        public BoardBuilder F6 { get { return And(new Square(45)); } }
        public BoardBuilder G6 { get { return And(new Square(46)); } }
        public BoardBuilder H6 { get { return And(new Square(47)); } }
        public BoardBuilder A7 { get { return And(new Square(48)); } }
        public BoardBuilder B7 { get { return And(new Square(49)); } }
        public BoardBuilder C7 { get { return And(new Square(50)); } }
        public BoardBuilder D7 { get { return And(new Square(51)); } }
        public BoardBuilder E7 { get { return And(new Square(52)); } }
        public BoardBuilder F7 { get { return And(new Square(53)); } }
        public BoardBuilder G7 { get { return And(new Square(54)); } }
        public BoardBuilder H7 { get { return And(new Square(55)); } }
        public BoardBuilder A8 { get { return And(new Square(56)); } }
        public BoardBuilder B8 { get { return And(new Square(57)); } }
        public BoardBuilder C8 { get { return And(new Square(58)); } }
        public BoardBuilder D8 { get { return And(new Square(59)); } }
        public BoardBuilder E8 { get { return And(new Square(60)); } }
        public BoardBuilder F8 { get { return And(new Square(61)); } }
        public BoardBuilder G8 { get { return And(new Square(62)); } }
        public BoardBuilder H8 { get { return And(new Square(63)); } }

        public BoardBuilder Rank1 { get { return And(new Rank(0)); } }
        public BoardBuilder Rank2 { get { return And(new Rank(1)); } }
        public BoardBuilder Rank3 { get { return And(new Rank(2)); } }
        public BoardBuilder Rank4 { get { return And(new Rank(3)); } }
        public BoardBuilder Rank5 { get { return And(new Rank(4)); } }
        public BoardBuilder Rank6 { get { return And(new Rank(5)); } }
        public BoardBuilder Rank7 { get { return And(new Rank(6)); } }
        public BoardBuilder Rank8 { get { return And(new Rank(7)); } }

        public BoardBuilder FileA { get { return And(new File(0)); } }
        public BoardBuilder FileB { get { return And(new File(1)); } }
        public BoardBuilder FileC { get { return And(new File(2)); } }
        public BoardBuilder FileD { get { return And(new File(3)); } }
        public BoardBuilder FileE { get { return And(new File(4)); } }
        public BoardBuilder FileF { get { return And(new File(5)); } }
        public BoardBuilder FileG { get { return And(new File(6)); } }
        public BoardBuilder FileH { get { return And(new File(7)); } }


		public BoardBuilder DiagonalA1H8 { get { return And(new DiagonalNE(7)); } }
		public BoardBuilder DiagonalH1A8 { get { return And(new DiagonalNW(7)); } }
        public BoardBuilder DiagonalA2G8 { get { return And(new DiagonalNE(6)); } }
        public BoardBuilder DiagonalB1H7 { get { return And(new DiagonalNE(8)); } }
        public BoardBuilder DiagonalH2B8 { get { return And(new DiagonalNW(8)); } }
        public BoardBuilder DiagonalG1A7 { get { return And(new DiagonalNW(6)); } }
        public BoardBuilder DiagonalA3F8 { get { return And(new DiagonalNE(5)); } }
        public BoardBuilder DiagonalC1H6 { get { return And(new DiagonalNE(9)); } }
        public BoardBuilder DiagonalH3C8 { get { return And(new DiagonalNW(9)); } }
        public BoardBuilder DiagonalF1A6 { get { return And(new DiagonalNW(5)); } }
        public BoardBuilder DiagonalA4E8 { get { return And(new DiagonalNE(4)); } }
        public BoardBuilder DiagonalD1H5 { get { return And(new DiagonalNE(10)); } }
        public BoardBuilder DiagonalH4D8 { get { return And(new DiagonalNW(10)); } }
        public BoardBuilder DiagonalE1A5 { get { return And(new DiagonalNW(4)); } }
        public BoardBuilder DiagonalA5D8 { get { return And(new DiagonalNE(3)); } }
        public BoardBuilder DiagonalE1H4 { get { return And(new DiagonalNE(11)); } }
        public BoardBuilder DiagonalH5E8 { get { return And(new DiagonalNW(11)); } }
        public BoardBuilder DiagonalD1A4 { get { return And(new DiagonalNW(3)); } }
        public BoardBuilder DiagonalA6C8 { get { return And(new DiagonalNE(2)); } }
        public BoardBuilder DiagonalF1H3 { get { return And(new DiagonalNE(12)); } }
        public BoardBuilder DiagonalH6F8 { get { return And(new DiagonalNW(12)); } }
        public BoardBuilder DiagonalC1A3 { get { return And(new DiagonalNW(2)); } }
        public BoardBuilder DiagonalA7B8 { get { return And(new DiagonalNE(1)); } }
        public BoardBuilder DiagonalG1H2 { get { return And(new DiagonalNE(13)); } }
        public BoardBuilder DiagonalH7G8 { get { return And(new DiagonalNW(13)); } }
        public BoardBuilder DiagonalB1A2 { get { return And(new DiagonalNW(1)); } }
        public BoardBuilder DiagonalA8A8 { get { return And(new DiagonalNE(0)); } }
        public BoardBuilder DiagonalH1H1 { get { return And(new DiagonalNE(14)); } }
        public BoardBuilder DiagonalH8H8 { get { return And(new DiagonalNW(14)); } }
        public BoardBuilder DiagonalA1A1 { get { return And(new DiagonalNW(0)); } }

    }
}
