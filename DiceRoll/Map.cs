using System;
using System.ComponentModel;

namespace Monobius
{
    public class Map
    {
        int rows = 3;
        int cols = 3;
        int roomName = 0;
        int enemyAmount = 3;
        Room[,] rooms;

        public void Setup()
        {
            rooms = new Room[rows, cols];

            for (int currentRow = 0; currentRow < rows; currentRow++)
            {
                for (int currentCol = 0; currentCol < cols; currentCol++)
                {
                    rooms[currentRow, currentCol] = new Room(roomName, currentRow, currentCol, false);
                    Console.Write("GEOINT [" + rooms[currentRow, currentCol].name + "] ({0:0}, {1:0}) ", rooms[currentRow, currentCol].posX, rooms[currentRow, currentCol].posY);
                    Console.WriteLine("");
                    roomName++;
                }
            }
        }
    }
}

