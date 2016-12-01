using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Flooring Mastery Project - Brandon Carroll";
            MainMenu menu = new MainMenu();
            menu.Display();
        }
    }
}
