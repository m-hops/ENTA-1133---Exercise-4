using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    internal class DieRoller
    {
        Random RNG = new Random();

        public int Roll(int maxVal)
        {
            int rollVal = RNG.Next(1,maxVal+1);
            return rollVal;

        }
    }
}
