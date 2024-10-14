using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//SHIP GENERATOR//
namespace Monobius
{
    internal class Ship
    {
        //SHIP TYPE VARIABLES//
        public string shipName;
        public string shipType;
        public int shipHealth;

        //HARD CODED WEAPON COUNT//
        //AS OF NOW, EVERYONE HAS 4//
        public const int kWeaponCount = 4;
        
        //ARRAY AND LISTS TO BUNDLE SHIP ATTRIBUTES//
        public int[] weaponAttacks = new  int[kWeaponCount];
        public string[] weaponNames = new string[kWeaponCount];
        public List<int> weaponsReady = new List<int>();

        //SHIP CONSTRUCTOR//
        public Ship(string shipName, string shipType, int shipHealth) 
        { 
            this.shipName = shipName;
            this.shipType = shipType; 
            this.shipHealth = shipHealth; 
        }

        //SETS UP DIFFERENT WEAPONS BASED ON VALUES IN GAME MANAGER//
        public void SetWeapon(string weaponName, int weaponAttack, int weaponSlotIndex)
        {
            weaponAttacks[weaponSlotIndex] = weaponAttack;
            weaponNames[weaponSlotIndex] = weaponName;
            weaponsReady.Add(weaponSlotIndex);
        }

        //CHECKS ARRAY TO SEE IF WEAPON IS AVAILABLE//
        public int GetWeaponByIndexName(string weaponName) 
        {
            for (int i = 0; i < weaponsReady.Count; i++)
            {
                int weaponIndex = weaponsReady[i];
                if (weaponNames[weaponIndex] == weaponName)
                {
                    weaponsReady.RemoveAt(i);
                    return weaponIndex;
                }
            }

            //IF WEAPON NOT AVAILABLE, -1 WILL RE PROMPT PLAYER FOR INPUT//
            return -1;
        }

        //WEAPON RANDOMIZER FOR CPU ENEMY//
        public int GetRandomWeapon(DieRoller dice)
        {
            int result = dice.Roll(weaponsReady.Count) - 1;
            int weaponIndex = weaponsReady[result];
            weaponsReady.RemoveAt(result);
            return weaponIndex;

        } 

        //RESET WEAPONS WHEN WEAPON POOL HAS BEEN DEPLETED//
        public void ResetWeapons()
        {
            weaponsReady.Clear();

            for (int i = 0;i < kWeaponCount;i++)
            {
                weaponsReady.Add(i);
            }
        }

        public void ReplaceWeapon()
        {

        }

    }
}

