using System.Collections.Generic;

namespace Monobius
{
    public class Map
    {
        public int RoomName = 0;
        public Room[,] Rooms;

        //MAP GENERATOR//
        public Map(GameManagerV2 gm, int width, int height, DieRoller dice, int startX, int startY)
        {
            Rooms = new Room[width, height];

            //SET ROOMS TO PULL FROM//
            List<Room> availableRooms = new List<Room>();
            Room startingRoom = new Room(0, 0, 0, "Front Lobby", new TreasureEvent());
            availableRooms.Add(new Room(1, 0, 0, "Egg of Life", new CombatEvent()));
            availableRooms.Add(new Room(2, 0, 0, "Fruit of Life", new CombatEvent()));
            availableRooms.Add(new Room(3, 0, 0, "Metatron's Cube", new CombatEvent()));
            availableRooms.Add(new Room(4, 0, 0, "The Tower", new TreasureEvent()));
            availableRooms.Add(new Room(5, 0, 0, "Kryptos", new TreasureEvent()));
            availableRooms.Add(new Room(6, 0, 0, "GHWB Intelligence Center", new TreasureEvent()));
            availableRooms.Add(new Room(7, 0, 0, "The Fool", new TreasureEvent()));
            availableRooms.Add(new Room(8, 0, 0, "Black Site", new TreasureEvent()));

            Rooms[startX, startY] = startingRoom;

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Room r = Rooms[x, y];
                    if (r == null)
                    {
                        int roomIndex = gm.Dice.Roll(availableRooms.Count) - 1;
                        r = availableRooms[roomIndex];
                        availableRooms.RemoveAt(roomIndex);
                    }
                    r.PosX = x;
                    r.PosY = y;
                    Rooms[x, y] = r;
                }
            }
        }
    }
}

