using System;
using System.Collections.Generic;

namespace Monobius
{
    public class GameManagerV2
    {
        //CLASS INSTANCE VARIABLES//
        public DieRoller Dice = new DieRoller();
        public Dialog Dialog = new Dialog();
        public Player Player;
        public Map Map;
        public int MapWidth = 3;
        public int MapHeight = 3;
        public List<Vessel> EnemyVessels;
        public List<Weapon> TreasurePoolWeapons = new List<Weapon>();
        public List<Item> TreasurePoolConsumable = new List<Item>();
        public List<Item> TreasurePoolPassive = new List<Item>();

        public bool IsGameRunning = false;
        public bool IsPlayerAlive = false;
        public Room CurrentPlayerRoom => Map.Rooms[Player.CurrentX, Player.CurrentY];


        //PRESET SHIP POOLS//
        //FIRST 3 ARE PLAYER CHOICE & THE REST ARE ENEMY NPCS//
        public readonly string[] kVesselPresetTypes = new string[]
        {
            "BODY",
            "MIND",
            "HOLISTIC",
            "THE TRU MAN",
            "SIXTY ONE PIGS",
            "DALLAS"
        };
        public readonly string[][] kVesselPresetWeaponNames = new string[][]
        {
            new string[] {"INVESTIGATE", "QUESTION", "PUNCH", "HANDGUN"},
            new string[] {"INVESTIGATE", "QUESTION", "MEDITATE", "DOWSING"},
            new string[] {"INVESTIGATE", "INVESTIGATE", "PUNCH", "DREAM"},
            new string[] {"ENOLA", "NATO", "POINT FOUR", "BIRTH"},
            new string[] {"DWISEN", "AIR STRIKE", "SEED", "CMC SIXTY TWO"},
            new string[] {"JACK", "ELM", "GNOLL", "REVENGE"}
        };
        public readonly int[][] kVesselPresetWeaponAttacks = new int[][]
        {
            new int[] {5, 10, 20, 25},
            new int[] {5, 10, 15, 35},
            new int[] {5, 5, 20, 30},
            new int[] {5, 10, 15, 20},
            new int[] {10, 15, 25, 30},
            new int[] {15, 20, 30, 35}
        };
        public readonly int[] kVesselPresetHP = new int[]
        {
            50,
            40,
            45,
            20,
            30,
            40
        };
        public const int k_FirstEnemyVesselPresetIndex = 3;

        //ONE TIME SETUPS//
        public void GameSetup()
        {
            Dialog.Welcome();
            Dialog.Rules();
            SetupPlayer();
            SetupPlayerVessel();
            SetupEnemyVessels();
            Map = new Map(this, MapWidth, MapHeight, Dice, 1, 1);
            SetupTreasurePools();
            IsGameRunning = true;
            Dialog.GameStart(Player.Name, Player.Vessel.Name);

            Console.Clear();
        }
        //FULL WEAPONS LIST AT GAME START//
        public void SetupTreasurePools()
        {
            TreasurePoolWeapons.Add(new Weapon("XENOGLOSSY", 40));
            TreasurePoolWeapons.Add(new Weapon("WARRANT", 45));
            TreasurePoolWeapons.Add(new Weapon("INSECTOTHOPTER", 60));
            TreasurePoolWeapons.Add(new Weapon("INSIGHT", 70));
            TreasurePoolWeapons.Add(new Weapon("PROPHECY", 80));
            TreasurePoolWeapons.Add(new Weapon("M91", 100));

            TreasurePoolConsumable.Add(new ItemRepairHP("COFFEE", 10));
            TreasurePoolConsumable.Add(new ItemRepairHP("COFFEE", 10));
            TreasurePoolConsumable.Add(new ItemRepairHP("COFFEE", 10));
            TreasurePoolConsumable.Add(new ItemRepairHP("COFFEE", 10));
            TreasurePoolConsumable.Add(new ItemRepairHP("COFFEE", 10));
            TreasurePoolConsumable.Add(new ItemRepairHP("COFFEE", 10));

            TreasurePoolPassive.Add(new ItemDamageNegator("CEREBRUM", 5));
            TreasurePoolPassive.Add(new ItemDamageNegator("FRONTAL LOBE", 10));
            TreasurePoolPassive.Add(new ItemDamageEnhance("LIMBIC LOBE", 5));
            TreasurePoolPassive.Add(new ItemDamageEnhance("PARIETEL LOBE", 10));
            TreasurePoolPassive.Add(new ItemDamageNegator("OCCIPITAL LOBE", 15));
            TreasurePoolPassive.Add(new ItemDamageEnhance("THIRD EYE", 15));

        }
        //SETS UP PLAYER INFO AND SPAWN POINT ON MAP//
        void SetupPlayer()
        {
            Player = new Player();
            Player.CurrentX = 1;
            Player.CurrentY = 1;

            //READ PLAYER NAME//
            bool isInvalidInput = true;
            while (isInvalidInput)
            {
                Dialog.IDPlayer();
                string Name = Console.ReadLine();
                switch (Name)
                {
                    case "":
                    case " ":
                        Dialog.SelectionError();
                        break;
                    default:
                        Player.Name = Name;
                        isInvalidInput = false;
                        break;
                }
            }

        }
        //PLAYER VESSEL SELECTION//
        public void SetupPlayerVessel()
        {
            Dialog.IDVesselType(Player.Name);

            bool isInvalidInput;
            do
            {
                isInvalidInput = false;
                switch (Dialog.Read())
                {
                    case "BODY":
                        Player.Vessel = CreateVesselFromPreset(0);
                        break;
                    case "MIND":
                        Player.Vessel = CreateVesselFromPreset(1);
                        break;
                    case "HOLISTIC":
                        Player.Vessel = CreateVesselFromPreset(2);
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
        //ENEMY VESSEL SETUP//
        void SetupEnemyVessels()
        {
            //SETUP ALL ENEMY VESSELS//
            EnemyVessels = new List<Vessel>();
            for (int i = k_FirstEnemyVesselPresetIndex; i < kVesselPresetTypes.Length; i++)
            {
                EnemyVessels.Add(CreateVesselFromPreset(i));
            }
        }
        //CORE GAME LOOP//
        public void GameLoop()
        {
            GameSetup();
            while (IsGameRunning)
            {
                Dialog.IntroduceRoom(CurrentPlayerRoom);
                PlayerControl();
            }
        }
        //PLAYER NAVIGATION AND DECRYPTION CHECKS//
        public void PlayerControl()
        {
            bool isInvalidInput;
            do
            {
                Dialog.Write("Please select a cardinal direction to navigate.");
                isInvalidInput = false;
                switch (InGameControlRead())
                {
                    case "DECRYPT":
                        CurrentPlayerRoom.OnDecript(this);
                        break;
                    case "NORTH":
                    case "N":
                        if (Player.CurrentY <= 0)
                        {
                            Dialog.NavigationError(this);
                        } else
                        {
                            Player.CurrentY--;
                        }
                        break;
                    case "SOUTH":
                    case "S":
                        if (Player.CurrentY >= MapHeight - 1)
                        {
                            Dialog.NavigationError(this);
                        }
                        else
                        {
                            Player.CurrentY++;
                        }
                        break;
                    case "EAST":
                    case "E":
                        if (Player.CurrentX >= MapWidth - 1)
                        {
                            Dialog.NavigationError(this);
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
                            Dialog.NavigationError(this);
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
        }
        //SHOWS CURRENT PLAYER INVENTORY WHEN PROMPTED//
        public void DisplayInventory()
        {
            Dialog.Inventory0(this);

            for (int i = 0; i < Vessel.kWeaponCount; i++)
            {
                Dialog.Write(Player.Vessel.Weapons[i].Name);
            }

            Dialog.Inventory1();

            for (int i = 0; i < Player.Inventory.Items.Count; i++)
            {
                if (Player.Inventory.Items[i].Type == Item.ItemType.Consumable)
                {
                    Dialog.Write(Player.Inventory.Items[i].Name + "-(CONSUMABLE)");
                } else
                {
                    Dialog.Write(Player.Inventory.Items[i].Name + "-(PASSIVE)");
                }
            }

            Dialog.Inventory2();
        }
        //LAUNCHES INVENTORY DIALOG WHEN PROMPTED//
        public string InGameControlRead()
        {
            while (true)
            {
                string userInput = Dialog.Read();
                switch (userInput)
                {
                    case "INVENTORY":
                    case "I":
                        DisplayInventory();
                        break;
                    default:
                        Item item = Player.Inventory.GetConsumableItemByName(userInput);

                        if (item != null)
                        {
                            item.Consume(this);
                            Player.Inventory.RemoveItem(item);
                        }
                        else
                        {
                            return userInput;
                        }
                        break;
                }
            }
        }
        //GENERATE VESSELS FROM PRESETS//
        public Vessel CreateVesselFromPreset(int presetIndex)
        {
            Vessel vessel = new Vessel(kVesselPresetTypes[presetIndex], kVesselPresetHP[presetIndex]);
            for (int j = 0; j < Vessel.kWeaponCount; j++)
            {
                Weapon weapon = new Weapon(kVesselPresetWeaponNames[presetIndex][j], kVesselPresetWeaponAttacks[presetIndex][j]);
                vessel.SetWeapon(weapon, j);
            }
            return vessel;
        }
    }
}

