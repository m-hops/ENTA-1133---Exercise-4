
using System;
using System.Collections.Generic;

namespace Monobius
{
    //TREASURE ROOM HANDLER//
    public class TreasureEvent : Event
    {
        public override void Execute(GameManagerV2 gm)
        {

            int roomSelection = gm.Dice.Roll(3);
            List<Weapon> weaponPool = gm.TreasurePoolWeapons;
            List<Item> consumablePool = gm.TreasurePoolConsumable;
            List<Item> passivePool = gm.TreasurePoolPassive;
            Item selectedItem;
            switch (roomSelection)
            {
                //WEAPON TREASURE//
                case 1:
                    {
                        int poolSize = weaponPool.Count;
                        int selectedIndex = gm.Dice.Roll(poolSize) - 1;
                        Weapon weapon = weaponPool[selectedIndex];
                        weaponPool.RemoveAt(selectedIndex);
                        TreasureWeapon(gm, weapon);
                    }
                    break;
                //CONSUMABLE TREASURE//
                case 2:
                    {
                        int poolSize = consumablePool.Count;
                        int selectedIndex = gm.Dice.Roll(poolSize) - 1;
                        selectedItem = consumablePool[selectedIndex];
                        consumablePool.RemoveAt(selectedIndex);
                        TreasureItem(gm, selectedItem);
                    }
                    break;
                //PASSIVE TREASURE//
                case 3:
                    {
                        int poolSize = passivePool.Count;
                        int selectedIndex = gm.Dice.Roll(poolSize) - 1;
                        selectedItem = passivePool[selectedIndex];
                        passivePool.RemoveAt(selectedIndex);
                        TreasureItem(gm, selectedItem);
                        selectedItem.Consume(gm);
                    }
                    break;
                default:
                    throw new NotImplementedException();
            }

            IsDecrypted = true;
        }
        //WHAT TO DO FOR WEAPON TREASURE CASES//
        public void TreasureWeapon(GameManagerV2 gm, Weapon weapon)
        {
            bool isInvalidInput;
            do
            {
                gm.Dialog.TreasureWeaponSelect0(weapon.Name);
                isInvalidInput = false;
                switch (gm.Dialog.Read())
                {
                    case "REPLACE":
                    case "R":
                        gm.Dialog.TreasureWeaponSelect1(gm);

                        string userInput = gm.Dialog.Read();
                        int weaponIndex = gm.Player.Vessel.GetWeaponIndexByName(userInput);
                        if (weaponIndex < 0)
                        {
                            gm.Dialog.SelectionError();
                            isInvalidInput = true;
                        }
                        else
                        {
                            gm.Player.Vessel.SetWeapon(weapon, weaponIndex);
                        }
                        break;
                    case "DESTROY":
                    case "D":
                        gm.Dialog.TreasureWeaponSelect2();
                        break;
                    default:
                        gm.Dialog.SelectionError();
                        isInvalidInput = true;
                        break;
                }
            } while (isInvalidInput);



        }
        //WHAT TO DO FOR CONSUMABLE & PASSIVE CASES//
        public void TreasureItem(GameManagerV2 gm, Item item)
        {
            gm.Dialog.ItemSelect(item);
            gm.Player.Inventory.AddItem(item);
        }
    }
}