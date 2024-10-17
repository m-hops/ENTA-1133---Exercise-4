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

            for (int currentRow = 0; currentRow < rows; currentRow++)
            {
                for (int currentCol = 0; currentCol < cols; currentCol++)
                {
                    Rooms[currentRow, currentCol] = new Room(RoomName, currentRow, currentCol, "");
                    //Console.Write("GEOINT [" + rooms[currentRow, currentCol].name + "] ({0:0}, {1:0}) ", rooms[currentRow, currentCol].posX, rooms[currentRow, currentCol].posY);
                    //Console.WriteLine("");
                    RoomName++;
                }
            }

            //SETUP ALL ENEMY VESSELS//
            EnemyVessels = new List<Vessel>();
            for (int i = GameManagerV2.k_FirstEnemyVesselPresetIndex; i < gm.kVesselPresetTypes.Length; i++) 
            {
                EnemyVessels.Add(gm.CreateVesselFromPreset(i));
            }

            EventManager myEvent = new EventManager(EventManager.Events.Treasure);

            Rooms[1,1].Event = myEvent;

        }
    }
}

