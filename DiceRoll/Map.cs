using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Monobius
{
    public class Map
    {
        public int RoomName = 0;
        public Room[,] Rooms;
        public List<Vessel> EnemyVessels;

        public void Setup(GameManagerV2 gm, int rows, int cols, DieRoller dice)
        {
            Rooms = new Room[rows, cols];

            //SETUP ALL ENEMY VESSELS//
            EnemyVessels = new List<Vessel>();
            for (int i = GameManagerV2.k_FirstEnemyVesselPresetIndex; i < gm.kVesselPresetTypes.Length; i++) 
            {
                EnemyVessels.Add(gm.CreateVesselFromPreset(i));
            }

            List<Room> availableRooms = new List<Room>();
            Room startingRoom = new Room(0, 0, 0, "Starting Room", new EventManager(EventManager.Events.Treasure));
            availableRooms.Add(new Room(1, 0, 0, "Enemy Room", new EventManager(EventManager.Events.Combat)));
            availableRooms.Add(new Room(2, 0, 0, "Enemy Room", new EventManager(EventManager.Events.Combat)));
            availableRooms.Add(new Room(3, 0, 0, "Enemy Room", new EventManager(EventManager.Events.Combat)));
            availableRooms.Add(new Room(4, 0, 0, "Treasure Room", new EventManager(EventManager.Events.Treasure)));
            availableRooms.Add(new Room(5, 0, 0, "Treasure Room", new EventManager(EventManager.Events.Treasure)));
            availableRooms.Add(new Room(6, 0, 0, "Treasure Room", new EventManager(EventManager.Events.Treasure)));
            availableRooms.Add(new Room(7, 0, 0, "Treasure Room", new EventManager(EventManager.Events.Treasure)));
            availableRooms.Add(new Room(8, 0, 0, "Treasure Room", new EventManager(EventManager.Events.Treasure)));

            Rooms[1, 1] = startingRoom;

            for (int currentRow = 0; currentRow < rows; currentRow++)
            {
                for (int currentCol = 0; currentCol < cols; currentCol++)
                {
                    Room r = Rooms[currentRow, currentCol];
                    if (r == null)
                    {
                        int roomIndex = gm.Dice.Roll(availableRooms.Count) - 1;
                        r = availableRooms[roomIndex];
                        availableRooms.RemoveAt(roomIndex);
                    }
                    r.PosX = currentRow;
                    r.PosY = currentCol;
                    Rooms[currentRow, currentCol] = r;
                }
            }
        }
    }
}

