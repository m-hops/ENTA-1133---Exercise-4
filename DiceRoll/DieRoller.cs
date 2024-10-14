using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monobius
{
    internal class DieRoller
    {
        //RANDOM NEEDS TO BE ROLLED HERE//
        //ROLLING WITHIN ROLL DOES NOT PRODUCE CONSISTENT RANDOM RESULTS//
        Random RNG = new Random();

        //SINGLE DICE ROLL BASED ON A MAX VALUE//
        //RETURNS AN INT VALUE//
        public int Roll(int maxVal)
        {
            int rollVal = RNG.Next(1, maxVal + 1);
            return rollVal;

        }
    }
}

