using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Monobius
{
    public class GameManagerV2
    {
        //CLASS INSTANCE VARIABLES//
        DieRoller Dice = new DieRoller();
        Dialog Dialog = new Dialog();
        Player Player = new Player();
        Random Random = new Random();
        Room CurrentPlayerRoom;
        Map Map = new Map();
        Vessel PlayerVessel;

        bool IsGameRunning = false;
        bool IsPlayerAlive = false;
        int RoundCounter = 0;
        int MapRows = 3;
        int MapCols = 3;
        string PlayerVesselCurrentWeapon;

        //PRESET SHIP POOLS//
        //FIRST 3 ARE PLAYER CHOICE & THE REST ARE ENEMY NPCS//
        readonly string[] kVesselPresetTypes = new string[]
        {
            "BODY",
            "MIND",
            "HOLISTIC",
            "THE TRU MAN",
            "SIXTY ONE PIGS",
            "DALLAS"
        };
        readonly string[][] kVesselPresetWeaponNames = new string[][]
        {
            new string[] {"INVESTIGATE", "QUESTION", "PUNCH", "HANDGUN"},
            new string[] {"INVESTIGATE", "QUESTION", "MEDITATE", "DOWSING"},
            new string[] {"INVESTIGATE", "INVESTIGATE", "PUNCH", "DREAM"},
            new string[] {"ENOLA", "NATO", "POINT FOUR", "BIRTH"},
            new string[] {"DWISEN", "AIR STRIKE", "SEED", "CMC SIXTY TWO"},
            new string[] {"JACK", "ELM", "GNOLL", "REVENGE"}
        };
        readonly int[][] kVesselPresetWeaponAttacks = new int[][]
        {
            new int[] {5, 10, 20, 25},
            new int[] {5, 10, 15, 35},
            new int[] {5, 5, 20, 30},
            new int[] {5, 10, 15, 20},
            new int[] {10, 15, 25, 30},
            new int[] {15, 20, 30, 35}
        };

        List<Weapon> AvailableWeapons = new List<Weapon>();

        //FULL WEAPONS LIST AT GAME START//
        public void GenerateAvailableWeapons()
        {
            AvailableWeapons.Add(new Weapon("INVESTIGATE", 5));
            AvailableWeapons.Add(new Weapon("QUESTION", 10));
            AvailableWeapons.Add(new Weapon("MEDITATE", 15));
            AvailableWeapons.Add(new Weapon("PUNCH", 20));
            AvailableWeapons.Add(new Weapon("HANDGUN", 25));
            AvailableWeapons.Add(new Weapon("DREAM", 30));
            AvailableWeapons.Add(new Weapon("DOWSING", 35));
            AvailableWeapons.Add(new Weapon("XENOGLOSSY", 40));
            AvailableWeapons.Add(new Weapon("WARRANT", 45));
            AvailableWeapons.Add(new Weapon("INSECTOTHOPTER", 60));
            AvailableWeapons.Add(new Weapon("INSIGHT", 70));
            AvailableWeapons.Add(new Weapon("PROPHECY", 80));
            AvailableWeapons.Add(new Weapon("M91", 100));
        }

        //ONE TIME SETUPS//
        public void GameSetup()
        {
            Dialog.Welcome();
            //Dialog.Rules();
            Player.Setup();
            VesselSelect();
            Dialog.GameStart();
            Player.CurrentX = 1;
            Player.CurrentY = 1;
            Map.Setup(MapRows,MapCols,Dice);
            IsGameRunning = true;

            Console.Clear();
        }
        //CORE GAME LOOP//
        public void GameLoop()
        {
            GameSetup();

            while (IsGameRunning)
            {
                int currentX = Player.CurrentX;
                int currentY = Player.CurrentY;
                CurrentPlayerRoom = Map.Rooms[currentX, currentY];

                Dialog.IntroduceRoom(CurrentPlayerRoom);
                PlayerControl();
            }
        }

        //VESSEL CONSTRUCTOR//
        public Vessel CreateVessel(string name, int hp)
        {
            Vessel v = new Vessel(name, hp);

            //for (int i = 0; i < Vessel.kWeaponCount; i++)
            //{
            //    v.SetWeapon(kVesselPresetWeaponNames[presetIndex][i], kVesselPresetWeaponAttacks[presetIndex][i], i);
            //}
            return v;
        }
        //PLAYER VESSEL SELECTION//
        public void VesselSelect()
        {
            Dialog.IDVesselType(Player.Name);
            bool isInvalidInput;
            do
            {
                isInvalidInput = false;
                switch (Dialog.Read())
                {

                    case "BODY":
                        PlayerVessel = CreateVessel("BODY", 50);
                        break;
                    case "MIND":
                        PlayerVessel = CreateVessel("MIND", 40);
                        break;
                    case "HOLISTIC":
                        PlayerVessel = CreateVessel("HOLISTIC", 45);
                        break;
                    default:
                        Dialog.SelectionError();
                        isInvalidInput = true;
                        break;

                }
                //CHECKS FOR INVALID INPUTS//
            } while (isInvalidInput);

            Console.Clear();
        }
        public void HandleDecryption() 
        {
            switch (CurrentPlayerRoom.Event.Type)
            {
                case Event.Events.Combat:
                    
                    break;
            }
        }
        //PLAYER NAVIGATION CHECKS//
        public void PlayerControl()
        {
            bool isInvalidInput;
            do
            {
                Dialog.Write("Please select a cardinal direction to navigate.");
                isInvalidInput = false;
                switch (Dialog.Read())
                {
                    case "DECRYPT":
                        if (CurrentPlayerRoom.IsSearched)
                        {
                            Dialog.FailDecryption();
                        } else
                        {
                            HandleDecryption();
                        }
                        break;
                    case "NORTH":
                    case "N":
                        if (Player.CurrentY <= 0)
                        {
                            Dialog.NavigationError();
                        } else
                        {
                            Player.CurrentY--;
                        }
                        break;
                    case "SOUTH":
                    case "S":
                        if (Player.CurrentY >= MapCols - 1)
                        {
                            Dialog.NavigationError();
                        }
                        else
                        {
                            Player.CurrentY++;
                        }
                        break;
                    case "EAST":
                    case "E":
                        if (Player.CurrentX >= MapRows - 1)
                        {
                            Dialog.NavigationError();
                        }
                        else
                        {
                            Player.CurrentX++;
                        }
                        break;
                    case "WEST":
                    case "W":
                        if (Player.CurrentX <= 0)
                        {
                            Dialog.NavigationError();
                        }
                        else
                        {
                            Player.CurrentX--;
                        }
                        break;
                    default:
                        Dialog.SelectionError();
                        isInvalidInput = true;
                        return;
                }
            } while (isInvalidInput);
            
            Dialog.Write(Player.CurrentY + " and " + Player.CurrentX);
        }
    }
}

