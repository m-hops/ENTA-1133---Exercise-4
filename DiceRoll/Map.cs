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

        public void Setup(int rows, int cols, DieRoller dice)
        {
            Rooms = new Room[rows, cols];

            for (int currentRow = 0; currentRow < rows; currentRow++)
            {
                for (int currentCol = 0; currentCol < cols; currentCol++)
                {
                    Rooms[currentRow, currentCol] = new Room(RoomName, currentRow, currentCol, false, "");
                    //Console.Write("GEOINT [" + rooms[currentRow, currentCol].name + "] ({0:0}, {1:0}) ", rooms[currentRow, currentCol].posX, rooms[currentRow, currentCol].posY);
                    //Console.WriteLine("");
                    RoomName++;
                }
            }

            EnemyVessels = new List<Vessel>();
            EnemyVessels.Add(CreateEnemyVessel("THE TRU MAN", 30));
            EnemyVessels.Add(CreateEnemyVessel("61 PIGS", 40));
            EnemyVessels.Add(CreateEnemyVessel("DALLAS", 50));

            Event myEvent = Event.MakeCombatEvent();

            Rooms[1,1].Event = myEvent;

        }

        //VESSEL CONSTRUCTOR//
        public Vessel CreateEnemyVessel(string name, int hp)
        {
            Vessel v = new Vessel(name, hp);

            //for (int i = 0; i < Vessel.kWeaponCount; i++)
            //{
            //    v.SetWeapon(kVesselPresetWeaponNames[presetIndex][i], kVesselPresetWeaponAttacks[presetIndex][i], i);
            //}
            return v;
        }
    }
}

