using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FlooringMastery.UI.Workflows;
using FlooringMastery.Models.Models;

namespace FlooringMastery.UI
{
    public class MainMenu
    {
        // Pretty little menu created by myself.
        // User can always return(go back) if they press enter. (Input must be empty)
        string input = "";
        public void Display()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("╔═══════════════════════════════╗");
                Console.WriteLine("║       Flooring Program        ║");
                Console.WriteLine("╠═══════════════════════════════╣");
                Console.WriteLine("║                               ║");
                Console.WriteLine("║ 1. Display Orders             ║");
                Console.WriteLine("║ 2. Add an Order               ║");
                Console.WriteLine("║ 3. Edit an Order              ║");
                Console.WriteLine("║ 4. Remove an Order            ║");
                Console.WriteLine("║ Q. Quit                       ║");
                Console.WriteLine("║                               ║");
                Console.WriteLine("╠═══════════════════════════════╣");
                Console.WriteLine("║ Tip: Press enter to return    ║");
                Console.WriteLine("╚═══════════════════════════════╝");
                Console.Write("Enter choice: ");
                input = Console.ReadLine();
                
                if (input != null)
                {
                    ProcessChoice(input);
                }
            } while (true);
        }

        private void ProcessChoice(string choice)
        {
            switch (choice)
            {
                case "1":
                    LookupWF lookup = new LookupWF();
                    lookup.LookupExecute();
                    break;
                case "2":
                    AddWF add = new AddWF();
                    add.Execute();
                    break;
                case "3":
                    EditWF edit = new EditWF();
                    edit.StartEdit();
                    break;
                case "4":
                    RemoveWF remove = new RemoveWF();
                    remove.RemoveOrder();
                    break;
                // I prefer q instead of 5. (Prevents headaches)
                case "q":
                case "Q":
                    Goodbye();
                    break;
                case "":
                    Console.Clear();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("╔═══════════════════════════════╗");
                    Console.WriteLine("║            Error!             ║");
                    Console.WriteLine("╚═══════════════════════════════╝");
                    Console.WriteLine($"{choice} is not valid!");
                    Console.WriteLine();
                    Console.WriteLine("Press enter to go back.");
                    Console.ReadLine();
                    Console.Clear();
                    break;
            }
        }

        // IT ADDS PRETTY LITTLE PERIODS
        public void Goodbye()
        {
            Console.Clear();
            Console.WriteLine("╔═══════════════════════════════╗");
            Console.WriteLine("║           Goodbye!            ║");
            Console.WriteLine("╚═══════════════════════════════╝");
            Console.WriteLine("Exiting.");
            Thread.Sleep(100);
            Console.Clear();
            Console.WriteLine("╔═══════════════════════════════╗");
            Console.WriteLine("║           Goodbye!            ║");
            Console.WriteLine("╚═══════════════════════════════╝");
            Console.WriteLine("Exiting..");
            Thread.Sleep(100);
            Console.Clear();
            Console.WriteLine("╔═══════════════════════════════╗");
            Console.WriteLine("║           Goodbye!            ║");
            Console.WriteLine("╚═══════════════════════════════╝");
            Console.WriteLine("Exiting...");
            Thread.Sleep(100);
            Thread.Sleep(300);
            Environment.Exit(0);
            // Environment is the current environment. Which is the Console window.
            // Exit is self-explanatory.
            // (0) means that it will exit with 0 parameters.
        }
    }
}