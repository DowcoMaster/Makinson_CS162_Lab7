using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoneyardClasses
{

    public class Domino : IComparable<Domino>
    {
        public int LeftDot { get; set; }
        public int RightDot { get; set; }
        public Domino(int leftDot, int rightDot)
        {
            LeftDot = leftDot;
            RightDot = rightDot;
        }
        public int CompareTo(Domino domino)
        {
            if (domino == null) return 1;
            return this.Value.CompareTo(domino.Value);
        }
        public int Value
        {
            get
            {
                return LeftDot + RightDot;
            }
        }
        public void Flip()
        {
            int temp = LeftDot;
            LeftDot = RightDot;
            RightDot = temp;
        }
        public int OppositeValue()
        {
            return RightDot + LeftDot;
        }
        public override bool Equals(object obj)
        {
            if(obj == null) return false;
            Domino domino = obj as Domino;
            return domino != null && this.LeftDot == domino.LeftDot && this.RightDot == domino.RightDot;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string ToString()
        {
            return ("Left: " + LeftDot + " Right: "+ RightDot);
        }
    }
}