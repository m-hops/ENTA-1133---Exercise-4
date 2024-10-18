namespace Monobius
{
    public class Item
    {
        //LIST ALL ITEM TYPES//
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

    //ITEM TYPES//
    public class ItemRepairHP: Item
    {
        int RollLimit;
        public ItemRepairHP(string name, int rollLimit): base(ItemType.Consumable, name)
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

        public ItemDamageNegator(string name, int negateAmount) : base(ItemType.Passive, name)
        {
            NegateAmount = negateAmount;
        }
        public override void Consume(GameManagerV2 gm)
        {
            gm.Player.DefenseBonus += NegateAmount;

            gm.Dialog.DamageNegator(NegateAmount, gm);
        }
    }
    public class ItemDamageEnhance : Item
    {
        int AddAmount;

        public ItemDamageEnhance(string name, int addAmount) : base(ItemType.Passive, name)
        {
            AddAmount = addAmount;
        }
        public override void Consume(GameManagerV2 gm)
        {
            gm.Player.AttackBonus += AddAmount;

            gm.Dialog.DamageEnhance(AddAmount, gm);
        }
    }
}


