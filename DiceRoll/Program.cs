using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Monobius
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Map map = new Map();
            try
            {
                //JUST LAUNCHES GAME MANAGER//
                GameManager manager = new GameManager();
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
