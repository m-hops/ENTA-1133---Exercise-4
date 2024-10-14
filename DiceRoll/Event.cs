using System;

namespace Monobius
{
    public class Event
    {
        //ALL EVENT TYPES//
        enum Events
        {
            Combat,
            Treasure,
            Lose,
            Win
        }

        Dialog dialog;

        public Event()
        {
            //EVENT CONSTRUCTOR//
        }

        public void Combat()
        {
            //COMBAT SCENARIO//
        }

        public void Treasure()
        {
            //TREASURE ROOM SCENARIO//
        }

        public void Lose()
        {
            //GAME OVER IF PLAYER DIES//
        }

        public void Win()
        {
            //GAME OVER IF PLAYER WINS//
        }
    }
}

