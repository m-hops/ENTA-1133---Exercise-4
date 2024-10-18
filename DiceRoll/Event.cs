namespace Monobius
{
    public abstract class Event
    {
        public bool IsDecrypted = false;
        public bool IsEventConcluded = false;
        public abstract void Execute(GameManagerV2 gm);
    }
}

