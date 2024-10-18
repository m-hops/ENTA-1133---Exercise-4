using System;

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
            return txt;
        }

        //STANDARD DIALOG CLASSES//
        public void Welcome()
        {
            Write("\r\n  ░▒▓██████████████▓▒░ ░▒▓██████▓▒░░▒▓███████▓▒░ ░▒▓██████▓▒░░▒▓███████▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░░▒▓███████▓▒░      \r\n  ░▒▓█▓▒░░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░             \r\n  ░▒▓█▓▒░░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░             \r\n  ░▒▓█▓▒░░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░▒▓███████▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░░▒▓██████▓▒░       \r\n  ░▒▓█▓▒░░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░      ░▒▓█▓▒░      \r\n  ░▒▓█▓▒░░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░      ░▒▓█▓▒░      \r\n  ░▒▓█▓▒░░▒▓█▓▒░░▒▓█▓▒░░▒▓██████▓▒░░▒▓█▓▒░░▒▓█▓▒░░▒▓██████▓▒░░▒▓███████▓▒░░▒▓█▓▒░░▒▓██████▓▒░░▒▓███████▓▒░       \r\n                                                                                                                \r\n                                                                                                                 \r\n");
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
            Write("Hello candidate, what is your name?");
        }
        public void IDVesselType(string playerName)
        {
            Write("");
            Write("Welcome candidate " + playerName + ".");
            Write("");
            Write("In accordance with the agency mandate , please select your VESSEL for navigation:");
            Write("");
            Write("[BODY]");
            Write("[MIND]");
            Write("[HOLISTIC]");
            Write("");
        }
        public void GameStart(string playerName, string vesselName)
        {
            Write("Candidate: " + playerName);
            Write("Vessel: " + vesselName);
            Write("");
            Write("Generating 'THE FARM'.....................................100%");
            Write("Syncronizing " + playerName + " with " + vesselName + "......................100%");
            Write("Preparing GEOINTS for decryption.....................100%");
            Write("Erasing " + playerName + " civilian profile......................100%");
            Write("");
            Write("Setup Complete");
            Write("Press enter to begin navigating THE FARM...");
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
        public void NavigationError()
        {
            Write("You can't go that way.");
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
        public void RollRecap(string playerName, string enemyVesselName, int playerRoll, int enemyRoll, string playerAttackName, string enemyAttackName)
        {
            Write("");
            Write(playerName + " used a " + playerAttackName + " with " + playerRoll + " attack power.");
            Write(enemyVesselName + " used a " + enemyAttackName + " with " + enemyRoll + " attack power.");
        }
        public void RoundRecap(string ship0Name, string ship1Name, int ship0Health, int ship1Health)
        {
            Write("");
            Write("The hull of the " + ship0Name + " is at " + ship0Health + " HP.");
            Write("The hull of the " + ship1Name + " is at " + ship1Health + " HP.");
            Write("");
        }
        public void IntroduceRoom(Room room)
        {
            Write("Room Name: " + room.Name);
            Write("Room PosX: " + room.PosX);
            Write("Room PosY: " + room.PosY);
            Write("Room Description: " + room.Description);

        }
        public void FailDecryption()
        {
            Write("This GEOINT has already been decrypted.");
        }
        public void TreasureWeaponSelect0(string weapon)
        {
            Write("You've discovered [" + weapon + "].");
            Write("Would you like to REPLACE an existing weapon or DESTROY this one?");
            Write("");
        }
        public void TreasureWeaponSelect1(GameManagerV2 gm)
        {
            Write("Which weapon would you like to replace?");
            Write(gm.Player.Vessel.Weapons[0].Name);
            Write(gm.Player.Vessel.Weapons[1].Name);
            Write(gm.Player.Vessel.Weapons[2].Name);
            Write(gm.Player.Vessel.Weapons[3].Name);
            Write("");
        }
        public void TreasureWeaponSelect2()  
        {
            Write("You discard the item and carry on");
        }
        public void ItemSelect(Item item)
        {
            Write("You just added a " + item.Name + " to your inventory.");
        }
    }
}


