using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Media;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Monobius
{
    internal class GameManager
    {
        //GLOBAL VARIABLES//
        DieRoller dice = new DieRoller();
        Dialog dialog = new Dialog();
        Player player0 = new Player();
        Ship ship0;
        Ship ship1;
        Random rnd = new Random();
        bool isGameRunning = false;
        bool isShip0Alive = false;
        bool isFirstTimePlaying = true;
        int roundCounter = 0;
        int playerHP = 40;
        string ship0CurrentWeapon;

        //SETS UP VALUES FOR ARRAY OF SHIPS ALONG WITH WEAPON NAME AND DAMAGE//
        readonly string[] kShipPresetTypes = new string[]
        {
            "01",
            "02",
            "03"
        };
        readonly string[][] kShipPresetWeaponNames = new string[][]
        {
            new string[] {"laser", "missle", "torpedo", "nuke"},
            new string[] {"missle", "missle", "torpedo", "torpedo"},
            new string[] {"laser", "laser", "nuke", "nuke"}
        };
        readonly int[][] kShipPresetWeaponAttacks = new int[][]
        {
            new int[] {6, 10, 12, 20},
            new int[] {10, 10, 12, 12},
            new int[] {6, 6, 20, 20}
        };
        List<Weapon> AvailableWeapons = new List<Weapon>();

        public void GenerateAvailableWeapons()
        {
            AvailableWeapons.Add(new Weapon("MEDITATE", 6));
        }

        //PRIMARY GAMELOOP//
        public void GameLoop()
        {
            if (isFirstTimePlaying)
            {
                dialog.Welcome();
                dialog.Rules();
                isFirstTimePlaying= false;
            }

            player0.Setup();
            ShipSelect();
            GameStartConfirm();

            //WHILE LOOPS RESETS WEAPON COOLDOWNS AFTER SET AMOUNT OF TURNS//
            while (isGameRunning) 
            {
                CombatRound();

                roundCounter++;
                if (roundCounter % Ship.kWeaponCount == 0)
                {
                    ship0.ResetWeapons();
                    ship1.ResetWeapons();
                    dialog.Write("***WEAPONS HAVE BEEN RESET***");
                    dialog.Write("");
                }
            }

            GameSummary();
            End();
        }

        //SETS GAME RUNNING TO TRUE AND DISPLAYS INITIAL FLAVOUR TEXT//
        public void GameStartConfirm()
        {
            isGameRunning = true;

            dialog.GameStart(player0.Name, ship0.shipName, ship1.shipName);

            Console.Clear();

            dialog.RoundRecap(ship0.shipName, ship1.shipName, ship0.shipHealth, ship1.shipHealth);
        }

        //NORMAL ROUND OF COMBAT//
        public void CombatRound()
        {
            dialog.Write("Current ASSETS Online: ");
            dialog.Write("----------------------");

            //RUNS THROUGH ARRAY AND LIST TO RETURN STILL VALID WEAPONS OR QUEUE WEAPON RESET//
            for (int i = 0; i < ship0.weaponsReady.Count; i++) 
            {
                int weaponIndex = ship0.weaponsReady[i];
                dialog.Write(ship0.weaponNames[weaponIndex]);
            }

            dialog.Write("----------------------");

            dialog.SelectWeapon();

            int ship0WeaponIndex = -1;

            //COLLECT PLAYER WEAPON INPUT//
            while (ship0WeaponIndex < 0)
            {
                string ship0WeaponSelection = Console.ReadLine();
                ship0CurrentWeapon = ship0WeaponSelection;
                ship0WeaponIndex = ship0.GetWeaponByIndexName(ship0WeaponSelection);
                
                if (ship0WeaponIndex < 0)
                {
                    dialog.SelectionError();
                }
            }

            //VALUES FOR COMBAT ROLLS//
            int ship1WeaponIndex = ship1.GetRandomWeapon(dice);
            string ship1CurrentWeapon = ship1.weaponNames[ship1WeaponIndex];
            int ship0Dice = ship0.weaponAttacks[ship0WeaponIndex];
            int ship1Dice = ship1.weaponAttacks[ship1WeaponIndex];
            int ship0RollResult = dice.Roll(ship0Dice);
            int ship1RollResult = dice.Roll(ship1Dice);

            dialog.RollRecap(player0.Name, ship1.shipName, ship0RollResult, ship1RollResult, ship0CurrentWeapon, ship1CurrentWeapon);

            //IF PLAYER ROLES HIGHER...//
            if (ship0RollResult > ship1RollResult)
            {
                int dmg = ship0RollResult - ship1RollResult;
                ship1.shipHealth -= dmg;
                dialog.Write("");
                dialog.Write("The " + ship1.shipName + " takes " + dmg + " damage.");

            } 
            //IF ENEMY ROLES HIGHER...//
            else if (ship0RollResult < ship1RollResult)
            {
                int dmg = ship1RollResult - ship0RollResult;
                ship0.shipHealth -= dmg;
                dialog.Write("");
                dialog.Write("The " + ship0.shipName + " takes " + dmg + " damage.");

            }
            //IF BOTH SHIPS ROLL THE SAME//
            else 
            {
                dialog.Write("");
                dialog.Write("Weapons cancel each other out.");
                dialog.Write("No one takes damage.");

            }

            dialog.RoundRecap(ship0.shipName, ship1.shipName, ship0.shipHealth, ship1.shipHealth);

            //COMBAT END CONDITIONS//
            //IF PLAYER HP HITS 0...//
            if (ship0.shipHealth <= 0)
            {
                dialog.Write(player0.Name + " was killed by the enemy.");
                isShip0Alive = false;
                isGameRunning = false;
                Console.ReadLine();
            }
            
            //IF ENEMY HP HITS 0...//
            if (ship1.shipHealth <= 0)
            {
                dialog.Write( "The enemy was killed by " + player0.Name + ".");
                isShip0Alive = true;
                isGameRunning = false;
                Console.ReadLine();
            } 
        }

        public void GameSummary()
        {
            if (isShip0Alive)
            {
                dialog.PlayerWin(player0.Name, ship0.shipName);
            }
            else
            {
                dialog.CompWin(ship1.shipName);
            }
        }

        //END LOOP IF PLAYER WISHES TO PLAY AGAIN//
        public void End()
        {
            dialog.Write("Would you like to play again?[Y/N}");

            string playerInput = Console.ReadLine();

            if (playerInput == "Yes" || playerInput == "Y" || playerInput == "YES" || playerInput == "yes" || playerInput == "y")
            {
                DefaultSetupValues();
                Console.Clear();
                GameLoop();
            } else
            {
                dialog.Write("Goodbye, and thanks for playing :)");
                Console.ReadLine();
            }
        }

        //DEFAULT GAME VALUES//
        public void DefaultSetupValues()
        {
            isGameRunning = false;
            isShip0Alive = false;
            roundCounter = 0;
            playerHP = 50;

            player0 = new Player();

        }

        //SHIP RELATED FUNCTIONS//
        //CREATES EVERY SHIP FOR BOTH PLAYER AND COMP//
        public Ship CreateShip( int presetIndex, string name, int hullPoints)
        {
            Ship ship = new Ship("TEST", kShipPresetTypes[presetIndex], hullPoints);

            for (int i = 0; i < Ship.kWeaponCount; i++)
            {
                ship.SetWeapon(kShipPresetWeaponNames[presetIndex][i], kShipPresetWeaponAttacks[presetIndex][i], i);
            }

            return ship;
        }
        //PLAYER SHIP SELECTION// 
        public void ShipSelect()
        {
            //RANDOMIZES ENEMY HEALTH LEVEL//
            int compHP = rnd.Next(30, 51);

            //CAPTURE PLAYER SHIP TYPE//
            dialog.IDShipType(player0.Name, "TEST");
            bool isInvalidInput;
            do
            {
                isInvalidInput = false;
                switch (Console.ReadLine())
                {

                    case "01":
                        ship0 = CreateShip(0, "TEST", playerHP);
                        ship1 = CreateShip(dice.Roll(3) - 1, "ISS Bad Ship", compHP);
                        break;
                    case "02":
                        ship0 = CreateShip(1, "TEST", playerHP);
                        ship1 = CreateShip(dice.Roll(3) - 1, "ISS Marie Antoinette", compHP);
                        break;
                    case "03":
                        ship0 = CreateShip(2, "TEST", playerHP);
                        ship1 = CreateShip(dice.Roll(3) - 1, "ISS Fallout", compHP);
                        break;
                    default:
                        dialog.SelectionError();
                        isInvalidInput = true;
                        break;

                }
                //CHECKS FOR INVALID INPUTS//
            } while (isInvalidInput);

            Console.Clear();
        }
    } 
}
