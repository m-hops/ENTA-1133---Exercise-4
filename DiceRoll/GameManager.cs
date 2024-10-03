using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Media;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    internal class GameManager
    {
      
        DieRoller dice = new DieRoller();
        Dialog dialog = new Dialog();
        Player player0 = new Player();
        Player player1 = new Player();
        Ship ship0;
        Ship ship1;
        bool isGameRunning = false;
        bool isShip0Alive = false;
        int roundCounter = 0;

        readonly string[] kShipPresetTypes = new string[]
        {
            "01",
            "02",
            "03"
        };

        readonly string[][] kShipPresetWeaponNames = new string[][]
        {
            new string[] {"Laser", "Missle", "Torpedo", "Nuke"},
            new string[] {"Missle", "Missle", "Torpedo", "Torpedo"},
            new string[] {"Laser", "Laser", "Nuke", "Nuke"}
        };

        readonly int[][] kShipPresetWeaponAttacks = new int[][]
        {
            new int[] {6, 10, 12, 20},
            new int[] {10, 10, 12, 12},
            new int[] {6, 6, 20, 20}
        };

        public void GameLoop()
        {
            dialog.Welcome();
            dialog.Rules();
            Identification();
            GameStartConfirm();

            while (isGameRunning) 
            {
                CombatRound();

                roundCounter++;
                if (roundCounter % Ship.kWeaponCount == 0)
                {
                    ship0.ResetWeapons();
                    ship1.ResetWeapons();
                    Console.WriteLine("Weapons have been reset.");
                }
            }

            GameSummary();
            End();
        }

        public void Identification()
        {
            dialog.IDPlayer();
            player0.pName = Console.ReadLine();

            dialog.IDShipName();
            string shipName = Console.ReadLine();

            dialog.IDShipType();
            bool isInvalidInput;
            do
            {
                isInvalidInput = false;
                switch (Console.ReadLine())
                {
                    case "01":
                        ship0 = CreateShip(0, shipName);
                        ship1 = CreateShip(dice.Roll(3) - 1, "ISS Bad Ship");
                        break;
                    case "02":
                        ship0 = CreateShip(1, shipName);
                        ship1 = CreateShip(dice.Roll(3) - 1, "ISS Marie Antoinette");
                        break;
                    case "03":
                        ship0 = CreateShip(2, shipName);
                        ship1 = CreateShip(dice.Roll(3) - 1, "ISS Fallout");
                        break;
                    default:
                        dialog.SelectionError();
                        isInvalidInput = true;
                        break;

                }
            } while (isInvalidInput);
           

        }

        public void GameStartConfirm()
        {
            isGameRunning = true;
        }

        public void CombatRound()
        {
            Console.WriteLine("Current Weapons Online: ");

            for (int i = 0; i < ship0.weaponsReady.Count; i++) 
            {
                int weaponIndex = ship0.weaponsReady[i];
                Console.WriteLine(ship0.weaponNames[weaponIndex]);
            }

            dialog.SelectWeapon();

            int ship0WeaponIndex = -1;

            while (ship0WeaponIndex < 0)
            {
                string ship0WeaponSelection = Console.ReadLine();
                ship0WeaponIndex = ship0.GetWeapon(ship0WeaponSelection);
                
                if (ship0WeaponIndex < 0)
                {
                    dialog.SelectionError();
                }
            }

            int ship1WeaponIndex = ship1.GetRandomWeapon(dice);
            int ship0Dice = ship0.weaponAttacks[ship0WeaponIndex];
            int ship1Dice = ship1.weaponAttacks[ship1WeaponIndex];
            int ship0RollResult = dice.Roll(ship0Dice);
            int ship1RollResult = dice.Roll(ship1Dice);

            Console.WriteLine("Ship0 rolled a " + ship0RollResult);
            Console.WriteLine("Ship1 rolled a " + ship1RollResult);

            if (ship0RollResult > ship1RollResult)
            {
                int dmg = ship0RollResult - ship1RollResult;
                ship1.shipHealth -= dmg;
                Console.WriteLine("Damage to enemy is: " + dmg + ".");

            } 
            else if (ship0RollResult < ship1RollResult)
            {
                int dmg = ship1RollResult - ship0RollResult;
                ship0.shipHealth -= dmg;
                Console.WriteLine("Damage to player is: " + dmg + ".");

            }
            else 
            {
                Console.WriteLine("Weapons cancel each other out.");

            }

            Console.WriteLine("Ship 0 is now at " + ship0.shipHealth + ".");
            Console.WriteLine("Ship 1 is now at " + ship1.shipHealth + ".");

            Console.ReadLine();

            if (ship0.shipHealth <= 0)
            {
                isGameRunning = false;
            }
            
            if (ship1.shipHealth <= 0)
            {
                isGameRunning = false;
            } 


        }

        public void GameSummary()
        {

        }

        public void End()
        {

        }

        public Ship CreateShip(int presetIndex, string name)
        {
            Ship ship = new Ship(name, kShipPresetTypes[presetIndex], 100);

            for (int i = 0; i < Ship.kWeaponCount; i++)
            {
                ship.SetWeapon(kShipPresetWeaponNames[presetIndex][i], kShipPresetWeaponAttacks[presetIndex][i], i);
            }

            return ship;
        }


    } 
}
