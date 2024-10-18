using System;
using System.Security.Permissions;

namespace Monobius
{
    //INDIVIDUAL ROOM CREATOR//
    public class Room
    {
        public int Name;
        public int PosX;
        public int PosY;
        public string Description;
        public EventManager Event;

        public Room(int name, int posX, int posY, string description, EventManager roomEvent)
        {
            Name = name;
            PosX = posX;
            PosY = posY;
            Description = description;
            Event = roomEvent;
        }

        //WHEN PLAYER ENTERS A ROOM, DO *THIS* FOR THAT ROOM//
        public void OnRoomEnter()
        {
            

        }

        //WHEN PLAYER LEAVES A ROOM, DO *THIS* FOR THAT ROOM//
        public void OnRoomExit()
        {

        }
    }
}


