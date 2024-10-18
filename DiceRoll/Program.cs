using System;

namespace Monobius
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //JUST LAUNCHES GAME MANAGER//
                GameManagerV2 manager = new GameManagerV2();
                manager.GameLoop();


            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Console.ReadLine();
            }
        }
    }
}
