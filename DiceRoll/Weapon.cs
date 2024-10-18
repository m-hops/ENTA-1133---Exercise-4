namespace Monobius
{
    public class Weapon: Item
    {
        public int Attack;

        public Weapon(string name, int attack)
            :base(ItemType.Weapon, name)
        {
            Attack = attack;
        }
    }

}
