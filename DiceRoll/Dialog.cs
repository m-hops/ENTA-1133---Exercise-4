using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//DIALOG CLASS IS USED FOR LARGER DIALOG BASED VALUES//
namespace Monobius
{
    public class Dialog
    {
        //SIMPLIFIED FUNCTION SO I DONT HAVE TO KEEP WRITING CONSOLE.WRITELINE OVER AND OVER AGAIN AAAAAAHHHHH//
        public void Write(string uInput)
        {
            Console.WriteLine(uInput);
        }

        //TAKE INPUT FROM CONSOLE.READLINE WITH FILTERING//
        public string Read()
        {
            string txt = Console.ReadLine().ToLower();

            while (true)
            {
                //TOP LEVEL INVENTORY CHECK AVAILABLE AT ALL TIMES//
                //RETURNS USER INPUT IF IT DOESNT MEET SPECIAL CONDITIONS//
                switch (txt)
                {
                    case "help":
                    case "h":
                        Rules();
                        break;
                    case "inventory":
                    case "i":
                        Write("Inventory");
                        break;
                    case "":
                    case " ":
                    case null:
                        SelectionError();
                        break;
                    default:
                        return txt;
                }
            }
           
        }

        //STANDARD DIALOG CLASSES//
        public void Welcome()
        {
            Write("-------------------");
            Write("SLOWER THAN LIGHT");
            Write("-------------------");
            Write("");
            Write("Enter any key to display instructions and continue...");
            Console.ReadLine();
        }
        public void Rules()
        {
            System.Diagnostics.Process.Start(@"..\..\RuleText.txt");
        }
        public void IDPlayer()
        {
            Write("What is your name?");
        }
        public void IDShipName(string playerName)
        {
            Write("And what is the name of your ship, " + playerName + "?");
        }
        public void IDShipType(string playerName, string shipName)
        {
            Write("");
            Write("Welcome " + playerName + ", captain of the " + shipName + ".");
            Write("");
            Write("Please confirm a ship type. (01, 02, or 03)");
        }
        public void GameStart(string playerName, string playerShipName, string enemyShipName)
        {
            Write("");
            Write("While out on a scouting mission, Captain " + playerName + " recieves a transmission from a nearby ship.");
            Write("");
            Write("'Attention captain of the " + playerShipName + "! This is the captain of the " + enemyShipName + "!'");
            Write("");
            Write("'Prepared to be fired upon because I think you suck.'");
            Write("");
            Write("Enter any key to begin combat...");
            Console.ReadLine();
        }
        public void SelectWeapon()
        {
            Write("Select a weapon to fire:");
        }
        public void SelectionError()
        {
            Write("Input invalid. Please try again.");
        }
        public void PlayerWin(string playerName, string shipName)
        {
            Write(playerName + ", captain of the " + shipName + " is the winner.");
            Write("");
        }
        public void CompWin(string shipname)
        {
            Write("The " + shipname + " is the winner.");
            Write("");
        }
        public void RollRecap(string playerName, string enemyShipName, int ship0Roll, int ship1Roll, string ship0AttackName, string ship1AttackName)
        {
            Write("");
            Write(playerName + " used a " + ship0AttackName + " with " + ship0Roll + " attack power.");
            Write(enemyShipName + " used a " + ship1AttackName + " with " + ship1Roll + " attack power.");
        }
        public void RoundRecap(string ship0Name, string ship1Name, int ship0Health, int ship1Health)
        {
            Write("");
            Write("The hull of the " + ship0Name + " is at " + ship0Health + " HP.");
            Write("The hull of the " + ship1Name + " is at " + ship1Health + " HP.");
            Write("");
        }
    }
}


