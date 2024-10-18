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
            Write("                      Enter any key to display instructions and continue...");
            Console.ReadLine();
        }
        public void Rules()
        {
            System.Diagnostics.Process.Start(@"..\..\RuleText.txt");
        }
        public void IDPlayer()
        {
            Write("Enter your name?");
        }
        public void IDVesselType(string playerName)
        {
            Write("");
            Write("Welcome subject " + playerName + ".");
            Write("");
            Write("In accordance with agency mandate , please select your VESSEL for navigation:");
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
            Write("Generating 'FARM'...............................................100%");
            Write("Preparing GEOINTS for DECRYPTion.................................100%");
            Write("Acctivating **REDACTED** implant inside subject " + playerName + "...................100%");
            Write("");
            Write("Press enter to begin navigating the FARM...");
            Console.ReadLine();
        }
        public void SelectWeapon()
        {
            Write("Select a skill to use:");
        }
        public void SelectionError()
        {
            Write("");
            Write("++Input Invalid++");
            Write("");
        }
        public void NavigationError(GameManagerV2 gm)
        {
            Write("");
            Write(gm.Player.Vessel.Name + " can not go that way.");
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
            Write("GEOINT[" + room.Name + "]");
            Write("Locale X: " + room.PosX);
            Write("Locale Y: " + room.PosY);
            Write("Room Description: " + room.Description);
            Write("-------------------------------------");
            Write("");

        }
        public void FailDecryption()
        {
            Write("");
            Write("This GEOINT has already been decrypted.");
            Write("");
        }
        public void TreasureWeaponSelect0(string weapon)
        {
            Write("");
            Write("You've discovered [" + weapon + "].");
            Write("Would you like to replace an existing ASSET or destroy this one? [Replace/Destroy]");
        }
        public void TreasureWeaponSelect1(GameManagerV2 gm)
        {
            Write("");
            Write("Which ASSET would you like to replace?");
            Write("");
            Write(gm.Player.Vessel.Weapons[0].Name);
            Write(gm.Player.Vessel.Weapons[1].Name);
            Write(gm.Player.Vessel.Weapons[2].Name);
            Write(gm.Player.Vessel.Weapons[3].Name);
            Write("");
        }
        public void TreasureWeaponSelect2()  
        {
            Write("");
            Write("You discard the ASSET and carry on.");
        }
        public void ItemSelect(Item item)
        {
            Write("");
            Write("You just added " + item.Name + " to your inventory.");
        }
        public void Inventory0(GameManagerV2 gm)
        {
            Write("");
            Write("Candidate: " + gm.Player.Name);
            Write("Vessel: " + gm.Player.Vessel.Name);
            Write("Remaining Vitality: " + gm.Player.Vessel.Health);
            Write("Current Attack Bonus: " + gm.Player.AttackBonus);
            Write("Current Defense Bonus: " + gm.Player.DefenseBonus);
            Write("");
            Write("Currently equipped ASSETs:");
            Write("--------------------------");
        }
        public void Inventory1()
        {
            Write("--------------------------");
            Write("");
            Write("Current INVENTORY:");
            Write("--------------------------");
        }
        public void Inventory2()
        {
            Write("--------------------------");
            Write("Type in the name of an item to use it.");
        }
        public void DamageNegator(int amount, GameManagerV2 gm)
        {
            Write("");
            Write("Your defense bonus was increase by " + amount);
            Write("Your defense bonus is now at " + gm.Player.DefenseBonus);
            Write("");
        }
        public void DamageEnhance(int amount, GameManagerV2 gm)
        {
            Write("");
            Write("Your attack bonus was increase by " + amount);
            Write("Your attack bonus is now at " + gm.Player.AttackBonus);
            Write("");
        }
        public void PlayAgain0()
        {
            Write("");
            Write("Would you like to try again? [Y/N]");
        }
        public void PlayAgain1()
        {
            Write("Goodbye");
            Read();
        }
    }
}


