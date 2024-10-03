using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    public class Dialog
    {
        public void Welcome()
        {
            Console.WriteLine("-------------------");
            Console.WriteLine("|SLOWER THAN LIGHT|");
            Console.WriteLine("-------------------");
            Console.WriteLine("");
            Console.ReadLine();
        }

        public void Rules()
        {
            Console.WriteLine("Rules");
            Console.ReadLine();
        }

        public void IDPlayer()
        {
            Console.WriteLine("What is your name?");
        }

        public void IDShipName()
        {
            Console.WriteLine("What is your ship name?");
        }

        public void IDShipType()
        {
            Console.WriteLine("Please select a ship.");
        }

        public void SelectWeapon()
        {
            Console.WriteLine("Select a weapon to fire:");
        }

        public void SelectionError()
        {
            Console.WriteLine("Input invalid. Please try again.");
        }
    }
}


