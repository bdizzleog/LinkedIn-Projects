using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models.Models;
using FlooringMastery.BLL;
using FlooringMastery.Data;

namespace FlooringMastery.UI.Workflows
{
    public class RemoveWF
    {
        private Order order;
        private List<Order> finddate;

        public void RemoveOrder()
        {
            DateTime orderDate = DateTime.Parse($"{PromptUserForDate("Enter Order Date: ")}");
            finddate = RetrieveOrderByDate(orderDate);
            if (finddate != null)
            {
                Console.Clear();
                Console.WriteLine("╔═══════════════════════════════╗");
                Console.WriteLine("║          Remove Order         ║");
                Console.WriteLine("╚═══════════════════════════════╝");
                Console.WriteLine($"Orders with date: {orderDate.ToShortDateString()}");
                DisplayOrderInfo(finddate);
            }
            string orderNumber = PromptUserForNumber("Enter Order Number: ");
            if (orderNumber != null)
            {
                FindOrder(orderDate, orderNumber);
            }
            Execute(order);
        }

        public void FindOrder(DateTime orderDate, string orderNumber)
        {
            order = RetrieveOrderByNumber(orderDate, orderNumber);
        }

        //Number 
        private Order RetrieveOrderByNumber(DateTime orderDate, string orderNumber)
        {
            var ops = new OrderOperations();
            var response = ops.GetOrderbyDateAndNumber(orderDate, orderNumber);
            if (response.Success)
            {
                return response.OrderInfo;
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
                RemoveOrder();
            }

            return null;
        }

        private string PromptUserForDate(string message)
        {
            Console.Clear();
            Console.WriteLine("╔═══════════════════════════════╗");
            Console.WriteLine("║          Remove Order         ║");
            Console.WriteLine("╚═══════════════════════════════╝");
            Console.Write(message);
            var orderDate = Console.ReadLine();

            // Validates input is in Date format.
            DateTime ValiDATE;
            if (DateTime.TryParse(orderDate, out ValiDATE))
            {
                return orderDate;
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
                RemoveOrder();
            }
            Console.Clear();
            return null;
        }

        private List<Order> RetrieveOrderByDate(DateTime orderDate)
        {
            var ops = new OrderOperations();
            var orders = new List<Order>();
            var response = ops.GetOrder(orderDate);
            if (response.Success)
            {
                orders = response.OrderList;
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
                RemoveOrder();
            }

            return orders;
        }
        private void DisplayOrderInfo(List<Order> finddate)
        {
            var customers = new List<Order>();
            Order order = new Order();
            var nothing = from s in customers
                          where s.OrderDate == order.OrderDate
                          select s;
            
            foreach (var customer in finddate)
            {
                Console.WriteLine(customer.OrderNumber);
            }
        }

        public string PromptUserForNumber(string message)
        {
            int userInput;
            string value = "";
            do
            {
                Console.WriteLine();
                Console.Write(message);
                value = Console.ReadLine();
                // Validates the input is an integer.
            } while (!int.TryParse(value, out userInput));
            return value;
        }

        public Order Execute(Order order)
        {
            ConfirmRemove(order);
            var orderToReturn = ProcessRemoveOrder(order);

            if (orderToReturn == null)
            {
                orderToReturn = order;
            }

            return orderToReturn;
        }

        public void ConfirmRemove(Order order)
        {
            Console.Clear();
            Console.WriteLine("╔═══════════════════════════════╗");
            Console.WriteLine("║          Remove Order         ║");
            Console.WriteLine("╚═══════════════════════════════╝");

            Console.WriteLine(order.OrderDate.ToShortDateString());
            Console.WriteLine(order.OrderNumber);

            Console.WriteLine();
            Console.WriteLine("Are you sure you want to remove this order? (Y/N)");
            var input = Console.ReadLine();

            switch (input.ToUpper())
            {
                case "Y":
                case "YES":
                    break;
                case "N":
                case "NO":
                    MainMenu menu = new MainMenu();
                    menu.Display();
                    break;
            }
        }

        private Order ProcessRemoveOrder(Order order)
        {
            var ops = new OrderOperations();
            var response = ops.RemoveOrder(order);

            if (!response.Success)
            {
                Console.Clear();
                Console.WriteLine("╔═══════════════════════════════╗");
                Console.WriteLine("║            Error!             ║");
                Console.WriteLine("╚═══════════════════════════════╝");
                Console.WriteLine(response.Message);
                Console.WriteLine();
                Console.ReadLine();
            }

            return response.OrderInfo;


        }
    }
}
