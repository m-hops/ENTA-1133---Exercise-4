using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//DIALOG CLASS IS USED FOR LARGER DIALOG BASED VALUES//
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
            Console.WriteLine("Enter any key to display instructions and continue...");
            Console.ReadLine();
        }

        public void Rules()
        {
            System.Diagnostics.Process.Start(@"..\..\RuleText.txt");
        }

        public void IDPlayer()
        {
            Console.WriteLine("What is your name?");
        }

        public void IDShipName(string playerName)
        {
            Console.WriteLine("And what is the name of your ship, " + playerName + "?");
            Console.WriteLine("What is your ship name?");
        }

        public void IDShipType(string playerName, string shipName)
        {
            Console.WriteLine("");
            Console.WriteLine("Welcome " + playerName + ", captain of the " + shipName + ".");
            Console.WriteLine("");
            Console.WriteLine("Please confirm a ship type. (01, 02, or 03)");
        }

        public void GameStart(string playerName, string playerShipName, string enemyShipName)
        {
            Console.WriteLine("");
            Console.WriteLine("While out on a scouting mission, Captain " + playerName + " recieves a transmission from a nearby ship.");
            Console.WriteLine("");
            Console.WriteLine("'Attention captain of the " + playerShipName + "! This is the captain of the " + enemyShipName + "!'");
            Console.WriteLine("");
            Console.WriteLine("'Prepared to be fired upon because I think you suck.'");
            Console.WriteLine("");
            Console.WriteLine("Enter any key to begin combat...");
            Console.ReadLine();
        }
        public void SelectWeapon()
        {
            Console.WriteLine("Select a weapon to fire:");
        }

        public void SelectionError()
        {
            Console.WriteLine("Input invalid. Please try again.");
        }

        public void PlayerWin(string playerName, string shipName)
        {
            Console.WriteLine(playerName + ", captain of the " + shipName + " is the winner.");
            Console.WriteLine("");
        }

        public void CompWin(string shipname)
        {
            Console.WriteLine("The " + shipname + " is the winner.");
            Console.WriteLine("");
        }
        
        public void RollRecap(string playerName, string enemyShipName, int ship0Roll, int ship1Roll, string ship0AttackName, string ship1AttackName)
        {
            Console.WriteLine("");
            Console.WriteLine(playerName + " used a " + ship0AttackName + " with " + ship0Roll + " attack power.");
            Console.WriteLine(enemyShipName + " used a " + ship1AttackName + " with " + ship1Roll + " attack power.");
        }

        public void RoundRecap(string ship0Name, string ship1Name, int ship0Health, int ship1Health)
        {
            Console.WriteLine("");
            Console.WriteLine("The hull of the " + ship0Name + " is at " + ship0Health + " HP.");
            Console.WriteLine("The hull of the " + ship1Name + " is at " + ship1Health + " HP.");
            Console.WriteLine("");
        }
    }
}


