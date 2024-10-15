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
            string txt = Console.ReadLine().ToUpper();

            while (true)
            {
                //TOP LEVEL INVENTORY CHECK AVAILABLE AT ALL TIMES//
                //RETURNS USER INPUT IF IT DOESNT MEET SPECIAL CONDITIONS//
                switch (txt)
                {
                    case "HELP":
                    case "H":
                        Rules();
                        break;
                    case "INVENTORY":
                    case "I":
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
            Write("MONOBIUS");
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
        public void IDVesselType(string playerName)
        {
            Write("");
            Write("Welcome " + playerName + ".");
            Write("");
            Write("Please select a vessel [BODY, WHEEL, or HOLISTIC]");
        }
        public void GameStart()
        {
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


