using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using FlooringMastery.BLL;
using FlooringMastery.Models.Models;

namespace FlooringMastery.UI.Workflows
{
    public class AddWF
    {
        public void Execute()
        {
            var order = PromptUserForNewOrder();

            if (ConfirmOrder(order))
            {
                ProcessAddOrder(order);
            }
        }

        private Order PromptUserForNewOrder()
        {
            Order order = new Order();

            Console.Clear();
            order.OrderDate = PromptUserForDate("Enter Order Date: ");
            order.OrderNumber = PromptUserForNumber("Enter Order Number: ");
            order.CustomerName = PromptUserForString("Enter Customer Name: ");;
            order.StateName = PromptUserForString("Enter State Name: ");
            order.StateAb = PromptUserForString("Enter State Abbreviation: ");
            order.TaxRate = PromptUserForDecimal("Enter State Tax Rate: ");
            order.ProductType = PromptUserForString("Enter Product Type: ");
            order.CostPerSqFt = PromptUserForDecimal("Enter Cost Per SqFt: ");
            order.LaborCostPerSqFt = PromptUserForDecimal("Enter Labor Cost Per SqFt: ");
            order.Area = PromptUserForDecimal("Enter Total Area: ");

            return order;
        }

        // Prompts user for Order Number
        public string PromptUserForNumber(string message)
        {
            int userInput;
            string value = "";
            do
            {
            Console.Clear();
            Console.WriteLine("╔═══════════════════════════════╗");
            Console.WriteLine("║          Add New Order        ║");
            Console.WriteLine("╚═══════════════════════════════╝");
            Console.Write(message);
            value = Console.ReadLine();
            // Validates the input is an integer.
            } while (!int.TryParse(value, out userInput));
            return value;
        }

        private DateTime PromptUserForDate(string message)
        {
            string value = "";

            do
            {
                Console.Clear();
                Console.WriteLine("╔═══════════════════════════════╗");
                Console.WriteLine("║          Add New Order        ║");
                Console.WriteLine("╚═══════════════════════════════╝");
                Console.Write(message);
                value = Console.ReadLine();
                // Validates input is in Date format.
                DateTime ValiDATE;
                if (DateTime.TryParse(value, out ValiDATE))
                {
                    return ValiDATE;
                }
                if (value == "")
                {
                    Console.Clear();
                    MainMenu menu = new MainMenu();
                    menu.Display();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("╔═══════════════════════════════╗");
                    Console.WriteLine("║            Error!             ║");
                    Console.WriteLine("╚═══════════════════════════════╝");
                    Console.WriteLine("Please enter order date in the format: MM/DD/YYYY");
                    Console.WriteLine();
                    Console.WriteLine("Press enter to go back.");
                    Console.ReadLine();
                    var exe = new AddWF();
                    exe.Execute();
                }

            } while (string.IsNullOrWhiteSpace(value));
            return new DateTime();
        }

        private decimal PromptUserForDecimal(string message)
        {
            decimal value = 0;
            string userInput = "";

            do
            {
                Console.Clear();
                Console.WriteLine("╔═══════════════════════════════╗");
                Console.WriteLine("║          Add New Order        ║");
                Console.WriteLine("╚═══════════════════════════════╝");
                userInput = PromptUserForString(message);

            } while (!decimal.TryParse(userInput, out value));

            return value;
        }

        private string PromptUserForString(string message)
        {
            string value = "";

            do
            {
                Console.Clear();
                Console.WriteLine("╔═══════════════════════════════╗");
                Console.WriteLine("║          Add New Order        ║");
                Console.WriteLine("╚═══════════════════════════════╝");
                Console.Write(message);
                value = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(value));
            return value;
        }

        private bool ConfirmOrder(Order order)
        {
            bool confirm = false;

            Console.WriteLine($"Order Date: {order.OrderDate.ToShortDateString()}");
            Console.WriteLine($"Order Number: {order.OrderNumber}");
            Console.WriteLine($"Name: {order.CustomerName}");
            Console.WriteLine($"State: {order.StateName} ({order.StateAb})");
            Console.WriteLine($"TaxRate: {order.TaxRate}");
            Console.WriteLine($"Product Type: {order.ProductType}");
            Console.WriteLine($"Cost Per SqFt: {order.CostPerSqFt:C}");
            Console.WriteLine($"Labor Cost Per SqFt: {order.LaborCostPerSqFt:C}");
            Console.WriteLine($"Area: {order.Area} SqFt.");
            Console.WriteLine($"Material Cost: {(order.CostPerSqFt * order.Area):C}");
            Console.WriteLine($"Labor Cost: {(order.LaborCostPerSqFt * order.Area):C}");
            Console.WriteLine($"Tax: {(order.Area / order.TaxRate):C}");
            Console.WriteLine(
                $"Total: {((order.CostPerSqFt * order.Area) + (order.LaborCostPerSqFt * order.Area) + (order.Area / order.TaxRate)):C}");
            Console.WriteLine();

            Console.WriteLine("Commit this New Order? (Y/N)");
            var input = Console.ReadLine();

            switch (input.ToUpper())
            {
                case "Y":
                case "YES":
                    confirm = true;
                    break;
                default:
                    confirm = false;
                    break;
            }
            return confirm;
        }

        public void ProcessAddOrder(Order order)
        {
            var ops = new OrderOperations();
            var response = ops.AddOrder(order);

            if (!response.Success)
            {
                Console.Clear();
                Console.WriteLine("╔═══════════════════════════════╗");
                Console.WriteLine("║            Error!             ║");
                Console.WriteLine("╚═══════════════════════════════╝");
                Console.WriteLine(response.Message);
                Console.ReadLine();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("╔═══════════════════════════════╗");
                Console.WriteLine("║            Success!           ║");
                Console.WriteLine("╚═══════════════════════════════╝");
                Console.WriteLine($"You successfully added Order: {response.OrderInfo.OrderNumber}");
                Console.WriteLine();
                Console.WriteLine("Press Enter to return to the menu.");
                Console.ReadLine();
                MainMenu menu = new MainMenu();
                menu.Display();
            }
        }
        
    }
}
