using System;

namespace Monobius
{
    
    public class Item
    {
        public enum ItemType
        {
            Consumable,
            Passive,
            Weapon
        }
        public ItemType Type;
        public string Name;

        //public List<string> itemsAvailable = new List<string>();

        public Item(ItemType type, string name)
        {
            Type = type;
            Name = name;
        }

        public virtual void Consume(GameManagerV2 gm)
        {

        }
    }

    public class ItemRepairHP: Item
    {
        public ItemRepairHP(): base(ItemType.Consumable, "REPAIR KIT")
        {

        }
        public override void Consume(GameManagerV2 gm)
        {
            gm.PlayerVessel.Health += gm.Dice.Roll(10);
        }
    }
    public class ItemDamageNegator : Item
    {
        public ItemDamageNegator() : base(ItemType.Passive, "CEREBRUM")
        {

        }
    }
}


