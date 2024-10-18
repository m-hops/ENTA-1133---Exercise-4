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

        public Item GetConsumableItemByName(string name)
        {
            for (int i = 0; i < ConsumableItems.Count; i++)
            {
                if (ConsumableItems[i].Name == name)
                {
                    return ConsumableItems[i];
                }
            }

            return null;
        }

        public void RemoveItem(Item item) 
        { 
            ConsumableItems.Remove(item);
            PassiveItems.Remove(item);
        }

    }
}