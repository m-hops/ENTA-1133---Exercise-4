using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//HUMAN PLAYER INFORMATION//
namespace Monobius
{
    public class Player
    {
        public string Name;
        public int CurrentX;
        public int CurrentY;
        public Inventory Inventory = new Inventory();
        Dialog Dialog = new Dialog();

        //INITIAL PLAYER SERTUP//
        //CALLED ONLY ONCE TO CREATE A NEW PLAYER//
        public void Setup()
        {
            bool isInvalidInput = true;

            while (isInvalidInput)
            {
                Dialog.IDPlayer();
                Name = Console.ReadLine();

                switch (Name)
                {
                    case "":
                    case " ":
                        Dialog.SelectionError();
                        break;
                    default:
                        isInvalidInput = false;
                        break;
                }
            }
        }
    } 
}

