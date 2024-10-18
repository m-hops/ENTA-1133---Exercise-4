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
        int RollLimit;
        public ItemRepairHP(string name, int rollLimit): base(ItemType.Consumable, "REPAIR KIT")
        {
            RollLimit = rollLimit;
        }
        public override void Consume(GameManagerV2 gm)
        {
            int diceRoll = gm.Dice.Roll(RollLimit);
            gm.Player.Vessel.Health += diceRoll;

            gm.Dialog.Write("You gained back some health " + diceRoll);
        }
    }
    public class ItemDamageNegator : Item
    {
        int NegateAmount;

        public ItemDamageNegator(string name, int negateAmount) : base(ItemType.Passive, "CEREBRUM")
        {
            NegateAmount = negateAmount;
        }
        public override void Consume(GameManagerV2 gm)
        {
            gm.Player.DefenseBonus += NegateAmount;

            gm.Dialog.Write("Your defense bonus was increase by " + NegateAmount);
            gm.Dialog.Write("Your defense bonus is now at " + gm.Player.DefenseBonus);
        }
    }
}


