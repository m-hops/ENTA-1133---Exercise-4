using System.Collections.Generic;

namespace Monobius
{
    public class Inventory
    {
        public List<Item> Items = new List<Item>();
        public void AddItem(Item item)
        {
            Items.Add(item);
        }

        public Item GetConsumableItemByName(string name)
        {
            for (int i = 0; i < Items.Count; i++)
            {
                if (Items[i].Type == Item.ItemType.Consumable && Items[i].Name == name)
                {
                    return Items[i];
                }
            }
            return null;
        }

        public void RemoveItem(Item item) 
        {
            Items.Remove(item);
        }

    }
}