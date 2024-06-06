using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DominoClasses;
using BoneyardClasses;

namespace DominoClasses
{
    public class Hand
    {
        public List<Domino> dominos = new List<Domino>();

        public List<Domino> Dominos
        {
            get
            {
                return dominos;
            }
        }
    }
}