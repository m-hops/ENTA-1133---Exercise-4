namespace Monobius
{
    //INDIVIDUAL ROOM CREATOR//
    public class Room
    {
        public int Name;
        public int PosX;
        public int PosY;
        public string Description;
        public Event Event;

        public Room(int name, int posX, int posY, string description, Event roomEvent)
        {
            Name = name;
            PosX = posX;
            PosY = posY;
            Description = description;
            Event = roomEvent;
        }

        public void OnDecript(GameManagerV2 gm)
        {
            if (Event == null || Event.IsDecrypted)
            {
                gm.Dialog.FailDecryption();
            }
            else
            {
                Event.Execute(gm);
            }
        }

    }
}


