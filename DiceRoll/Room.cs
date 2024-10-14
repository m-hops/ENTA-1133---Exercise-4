using System;
using System.Security.Permissions;

namespace Monobius
{
    //INDIVIDUAL ROOM CREATOR//
    internal class Room
    {
        Dialog dialog;
        public int name;
        public int posX;
        public int posY;
        public bool isSearched;

        public Room(int name, int posX, int posY, bool isSearched)
        {
            this.name = name;
            this.posX = posX;
            this.posY = posY;
            this.isSearched = isSearched;
        }

        //WHEN PLAYER ENTERS A ROOM, DO *THIS* FOR THAT ROOM//
        public void OnRoomEnter()
        {
            

        }

        //WHEN PLAYER "DECIPHERS" A ROOM, DO *THIS* FOR THAT ROOM//
        public void OnRoomSearch()
        {
            if (isSearched)
            {
                dialog.Write("GEOINT IS ALREADY DECIPHERED");
            }
            else
            {
                dialog.Write("GEOINT NOW BEING DECIPHERED");
            }
        }

        //WHEN PLAYER LEAVES A ROOM, DO *THIS* FOR THAT ROOM//
        public void OnRoomExit()
        {

        }
    }
}


