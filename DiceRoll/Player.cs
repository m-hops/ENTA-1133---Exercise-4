//HUMAN PLAYER INFORMATION//
namespace Monobius
{
    public class Player
    {
        public string Name;
        public int CurrentX;
        public int CurrentY;
        public int AttackBonus = 0;
        public int DefenseBonus = 0;
        public Vessel Vessel;
        public Inventory Inventory = new Inventory();
    } 
}

