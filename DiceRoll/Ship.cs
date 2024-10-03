using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    internal class Ship
    {
        public string shipName;
        public string shipType;
        public int shipHealth;

        public const int kWeaponCount = 4;
        
        public int[] weaponAttacks = new int[kWeaponCount];
        public string[] weaponNames = new string[kWeaponCount];
        public List<int> weaponsReady = new List<int>();

        public Ship(string shipName, string shipType, int shipHealth) 
        { 
            this.shipName = shipName;
            this.shipType = shipType; 
            this.shipHealth = shipHealth; 
        }

        public void SetWeapon(string weaponName, int weaponAttack, int weaponSlotIndex)
        {
            weaponAttacks[weaponSlotIndex] = weaponAttack;
            weaponNames[weaponSlotIndex] = weaponName;
            weaponsReady.Add(weaponSlotIndex);
        }

        public int GetWeapon(string weaponName) 
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

            return -1;
        }

        public int GetRandomWeapon(DieRoller dice)
        {
            int result = dice.Roll(weaponsReady.Count) - 1;
            int weaponIndex = weaponsReady[result];
            weaponsReady.RemoveAt(result);
            return weaponIndex;

        } 

        public void ResetWeapons()
        {
            weaponsReady.Clear();

            for (int i = 0;i < kWeaponCount;i++)
            {
                weaponsReady.Add(i);
            }
        }
    }
}

