using System;
using System.Security.Permissions;

namespace Monobius
{
    //INDIVIDUAL ROOM CREATOR//
    public class Room
    {
        Dialog Dialog;
        public int Name;
        public int PosX;
        public int PosY;
        public bool IsSearched;
        public string Description;

        public Room(int name, int posX, int posY, bool isSearched, string description)
        {
            Name = name;
            PosX = posX;
            PosY = posY;
            IsSearched = isSearched;
            Description = description;
        }

        //WHEN PLAYER ENTERS A ROOM, DO *THIS* FOR THAT ROOM//
        public void OnRoomEnter()
        {
            

        }

        //WHEN PLAYER "DECIPHERS" A ROOM, DO *THIS* FOR THAT ROOM//
        public void OnRoomSearch()
        {
            if (IsSearched)
            {
                Dialog.Write("GEOINT IS ALREADY DECIPHERED");
            }
            else
            {
                Dialog.Write("GEOINT NOW BEING DECIPHERED");
            }
        }

        //WHEN PLAYER LEAVES A ROOM, DO *THIS* FOR THAT ROOM//
        public void OnRoomExit()
        {

        }
    }
}


