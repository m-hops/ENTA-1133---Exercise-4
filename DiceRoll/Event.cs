using System;

namespace Monobius
{
    public class EventManager
    {
        //ALL EVENT TYPES//
        public enum Events
        {
            Combat,
            Treasure,
            Lose,
            Win
        }

        public Events Type;

        public static Event MakeCombatEvent()
        {
            return new Event
            {
                Type = Events.Combat,
            };
        }

        public void Combat()
        {
            
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

