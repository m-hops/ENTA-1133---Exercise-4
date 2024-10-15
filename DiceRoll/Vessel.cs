using System;
using System.Collections.Generic;

namespace Monobius
{
    public class Vessel
    {
        public string Name;
        public int Health;

        //HARD CODED WEAPON COUNT//
        //AS OF NOW, EVERYONE HAS 4//
        public const int kWeaponCount = 4;
        public Weapon[] Weapons = new Weapon[kWeaponCount];

        public List<int> weaponsReady = new List<int>();

        public Vessel(string name, int health)
        {
            Name = name;
            Health = health;
        }

        //SETS UP DIFFERENT WEAPONS BASED ON VALUES IN GAME MANAGER//
        public void SetWeapon(Weapon weapon, int weaponSlotIndex)
        {
            Weapons[weaponSlotIndex] = weapon;
            if (!weaponsReady.Contains(weaponSlotIndex)) 
            {
                weaponsReady.Add(weaponSlotIndex);
            }
        }
        //CHECKS ARRAY TO SEE IF WEAPON IS AVAILABLE//
        public int GetAvailableWeaponIndexByName(string weaponName)
        {
            for (int i = 0; i < weaponsReady.Count; i++)
            {
                int weaponIndex = weaponsReady[i];
                if (Weapons[weaponIndex].Name == weaponName)
                {
                    weaponsReady.RemoveAt(i);
                    return weaponIndex;
                }
            }

            //IF WEAPON NOT AVAILABLE, -1 WILL RE PROMPT PLAYER FOR INPUT//
            return -1;
        }
        //WEAPON RANDOMIZER FOR CPU ENEMY//
        public int GetRandomAvailableWeaponIndex(DieRoller dice)
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

            for (int i = 0; i < kWeaponCount; i++)
            {
                weaponsReady.Add(i);
            }
        }
    }
}

