using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.BLL;
using FlooringMastery.Models.Models;
using FlooringMastery.Data;
using FlooringMastery.Models;

namespace FlooringMastery.UI.Workflows
{
    public class LookupWF
    {
        OrderOperations ops = new OrderOperations();

        public void LookupExecute()
        {

            DateTime orderDate = GetOrderDateFromInput();
            Execute(orderDate);
        }

        // Prompts the user for date input.
        public DateTime GetOrderDateFromInput()
        {
            Console.Clear();
            Console.WriteLine("╔═══════════════════════════════╗");
            Console.WriteLine("║        Display Orders         ║");
            Console.WriteLine("╚═══════════════════════════════╝");
            Console.Write("Enter Date of Order: ");
            var orderDate = Console.ReadLine();

            // Validates input is in Date format.
            DateTime ValiDATE;
            if (DateTime.TryParse(orderDate, out ValiDATE))
            {
                return ValiDATE;
            }
            if (orderDate == "")
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
                LookupExecute();
            }
            Console.Clear();
            return ValiDATE;
        }

        // If the date entered exists then it will display the orders.
        public void Execute(DateTime orderDate)
        {
            var order = RetrieveOrderByDate(orderDate);

            if (order != null)
            {
                DisplayOrderInfo(order);
            }
        }

        // Checks to see if the date exists or not.
        private List<Order> RetrieveOrderByDate(DateTime orderDate)
        {
            var response = ops.GetOrder(orderDate);
            List<Order> orders = new List<Order>();
            if (response.Success)
            {
                orders = response.OrderList;
                return orders;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("╔═══════════════════════════════╗");
                Console.WriteLine("║            Error!             ║");
                Console.WriteLine("╚═══════════════════════════════╝");
                Console.WriteLine(response.Message);
                Console.WriteLine();
                Console.WriteLine("Press enter to go back.");
                Console.ReadLine();
                LookupExecute();
            }

            return null;
        }

        // Display Order info if it exists. (With equations and currency!)
        public static void DisplayOrderInfo(List<Order> orders)
        {
            var customers = new List<Order>();
            Order order = new Order();
            var nothing = from s in customers
                where s.OrderDate == order.OrderDate
                select s;

            Console.Clear();
            Console.WriteLine("╔═══════════════════════════════╗");
            Console.WriteLine("║       Order Information       ║");
            Console.WriteLine("╚═══════════════════════════════╝");

            foreach (Order customer in orders)
            {
                Console.WriteLine($"Order Date: {customer.OrderDate.ToShortDateString()}");
                Console.WriteLine($"Order Number: {customer.OrderNumber}");
                Console.WriteLine($"Name: {customer.CustomerName}");
                Console.WriteLine($"State: {customer.StateName} ({customer.StateAb})");
                Console.WriteLine($"Tax Rate: {customer.TaxRate}%");
                Console.WriteLine($"Product Type: {customer.ProductType}");
                Console.WriteLine($"Cost Per SqFt: {customer.CostPerSqFt:C}");
                Console.WriteLine($"Labor Cost Per SqFt: {customer.LaborCostPerSqFt:C}");
                Console.WriteLine($"Area: {customer.Area} SqFt.");
                Console.WriteLine($"Material Cost: {(customer.CostPerSqFt*customer.Area):C}");
                Console.WriteLine($"Labor Cost: {(customer.LaborCostPerSqFt*customer.Area):C}");
                Console.WriteLine($"Tax: {(customer.CostPerSqFt*customer.Area)/customer.TaxRate:C}");
                Console.WriteLine(
                    $"Total: {(customer.CostPerSqFt*customer.Area) + (customer.LaborCostPerSqFt*customer.Area) + (customer.Area/customer.TaxRate):C}");
                Console.WriteLine();
            }
            Console.WriteLine("Press enter to go back.");
            Console.ReadLine();

            var reset = new LookupWF();
            reset.LookupExecute();
        }
    }
}
