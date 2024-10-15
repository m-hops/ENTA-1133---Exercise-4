using System;
using System.ComponentModel;

namespace Monobius
{
    public class Map
    {
        public int RoomName = 0;
        public Room[,] Rooms;

        public void Setup(int rows, int cols)
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
        }
    }
}

