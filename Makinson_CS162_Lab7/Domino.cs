using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoneyardClasses
{

    public class Domino
    {
        public int LeftDot { get; set; }
        public int RightDot { get; set; }
        public Domino(int leftDot, int rightDot)
        {
            LeftDot = leftDot;
            RightDot = rightDot;
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
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string ToString()
        {
            return (LeftDot + RightDot).ToString();
        }
    }
}