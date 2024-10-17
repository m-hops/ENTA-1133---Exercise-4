using System;
using System.Collections.Generic;

namespace Monobius
{
    public class Inventory
    {
        public List<Item> ConsumableItems = new List<Item>();
        public List<Item> PassiveItems = new List<Item>();

        public void AddItem(Item item)
        {
            switch(item.Type)
            {
                case Item.ItemType.Consumable:
                    ConsumableItems.Add(item);
                    break;
                case Item.ItemType.Passive:
                    PassiveItems.Add(item);
                    break;
            }
        }
    }
}