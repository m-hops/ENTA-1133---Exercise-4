using System.Collections.Generic;

namespace Monobius
{
    //INVENTORY COMMAND CLASS//
    public class Inventory
    {
        public List<Item> Items = new List<Item>();

        //ADD ITEM TO A LIST//
        public void AddItem(Item item)
        {
            Items.Add(item);
        }
        //FIND INDEX FOR CONSUMABLE BY NAME//
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
        //REMOVE ITEM FROM A LIST//
        public void RemoveItem(Item item) 
        {
            Items.Remove(item);
        }

    }
}