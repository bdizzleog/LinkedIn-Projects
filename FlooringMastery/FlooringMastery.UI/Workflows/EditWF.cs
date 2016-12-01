using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.BLL;
using FlooringMastery.Data;
using FlooringMastery.Models.Models;

namespace FlooringMastery.UI.Workflows
{
    public class EditWF
    {
        private Order order;
        private List<Order> finddate;
        OrderOperations ops = new OrderOperations();

        public void FindOrder(DateTime orderDate, string orderNumber)
        {
            order = RetrieveOrderByNumber(orderDate, orderNumber);
        }


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
                StartEdit();
            }

            return null;
        }

        public void StartEdit()
        {
            var orderDate = PromptUserForDate("Enter Order Date: ");
            finddate = RetrieveOrderByDate(orderDate);

            if (finddate != null)
            {
                Console.Clear();
                Console.WriteLine("╔═══════════════════════════════╗");
                Console.WriteLine("║           Edit Order          ║");
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

        public static void DisplayOrderInfo(List<Order> finddate)
        {
            var customers = new List<Order>();
            Order order = new Order();

            // set the var to nothing, but it only works if i use a variable. ?? not sure why
            var nothing = from s in customers
                          where s.OrderDate == order.OrderDate
                          select s;

            
            foreach (var customer in finddate)
            {
                Console.WriteLine(customer.OrderNumber);
            }
        }

        public Order Execute(Order order)
        {
            var editOrder = PromptUserforEdit(order);
            ConfirmEdit(editOrder);
            var orderToReturn = ProcessEditOrder(editOrder);

            if (orderToReturn == null)
            {
                orderToReturn = order;
            }

            return orderToReturn;
        }

        private Order PromptUserforEdit(Order order)
        {
            var editOrder = new Order();

            editOrder.OrderDate = PromptForDateValue(order.OrderDate, "Order Date");
            editOrder.OrderNumber = PromptForStringValue(order.OrderNumber, "Order Number");
            editOrder.CustomerName = PromptForStringValue(order.CustomerName, "Customer Name");
            editOrder.StateName = PromptForStringValue(order.StateName, "State Name");
            editOrder.StateAb = PromptForStringValue(order.StateAb, "State Abbreviation");
            editOrder.TaxRate = PromptForDecimalValue(order.TaxRate, "Tax Rate");
            editOrder.ProductType = PromptForStringValue(order.ProductType, "Product Type");
            editOrder.Area = PromptForDecimalValue(order.Area, "Area");
            editOrder.CostPerSqFt = PromptForDecimalValue(order.CostPerSqFt, "Material Cost/SqFt");
            editOrder.LaborCostPerSqFt = PromptForDecimalValue(order.LaborCostPerSqFt, "Labor Cost/SqFt");

            return editOrder;
        }
    
        

        public void ConfirmEdit(Order editOrder)
        {
            Console.Clear();
            Console.WriteLine("╔═══════════════════════════════╗");
            Console.WriteLine("║           Edit Order          ║");
            Console.WriteLine("╚═══════════════════════════════╝");

            Console.WriteLine($"Date: {order.OrderDate.ToShortDateString()} --> {editOrder.OrderDate.ToShortDateString()}");
            Console.WriteLine($"Number: {order.OrderNumber} --> {editOrder.OrderNumber}");
            Console.WriteLine($"Name: {order.CustomerName} --> {editOrder.CustomerName}");
            Console.WriteLine($"State: {order.StateName} ({order.StateAb}) --> {editOrder.StateName} ({editOrder.StateAb})");
            Console.WriteLine($"Tax Rate: {order.TaxRate} --> {editOrder.TaxRate} ");
            Console.WriteLine($"Type: {order.ProductType} --> {editOrder.ProductType}");
            Console.WriteLine($"Area: {order.Area} --> {editOrder.Area}");
            Console.WriteLine($"Cost/SqFt: {order.CostPerSqFt} --> {editOrder.CostPerSqFt}");
            Console.WriteLine($"LaborCost/SqFt: {order.LaborCostPerSqFt} --> {editOrder.LaborCostPerSqFt}");

            Console.WriteLine();
            Console.WriteLine("Do you want to save these changes? (Y/N)");
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

        private decimal PromptForDecimalValue(decimal CurrentValue, string field)
        {
            
            string newValue = "";
            decimal newDecValue;
            Console.Clear();
            Console.WriteLine("╔═══════════════════════════════╗");
            Console.WriteLine("║           Edit Order          ║");
            Console.WriteLine("╚═══════════════════════════════╝");
            Console.WriteLine("(Hit enter to skip edit)");
            Console.WriteLine($"{field}: {CurrentValue}");
            Console.Write("Enter New Value: ");
            newValue = Console.ReadLine();

            if (decimal.TryParse(newValue, out newDecValue))
            {
                return newDecValue;
            }
            if (string.IsNullOrEmpty(newValue) || newValue == "")
            {
                newDecValue = CurrentValue;
            }
            return newDecValue;
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

        private DateTime PromptUserForDate(string message)
        {
            Console.Clear();
            Console.WriteLine("╔═══════════════════════════════╗");
            Console.WriteLine("║           Edit Order          ║");
            Console.WriteLine("╚═══════════════════════════════╝");
            Console.Write(message);
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
                StartEdit();
            }
            Console.Clear();
            return ValiDATE;
        }

        private DateTime PromptForDateValue(DateTime CurrentValue, string field)
        {
            string newValue = "";
            Console.Clear();
            Console.WriteLine("╔═══════════════════════════════╗");
            Console.WriteLine("║           Edit Order          ║");
            Console.WriteLine("╚═══════════════════════════════╝");
            Console.WriteLine("(Hit enter to skip edit)");
            Console.WriteLine($"{field}: {CurrentValue.ToShortDateString()}");
            Console.Write("Enter New Value: ");
            newValue = Console.ReadLine();
            DateTime ValiDATE;
            if (DateTime.TryParse(newValue, out ValiDATE))
            {
                return ValiDATE;
            }
            if (string.IsNullOrEmpty(newValue))
            {
                DateTime.TryParse(newValue, out ValiDATE);
                ValiDATE = CurrentValue;
            }
            return ValiDATE;
        }

        private string PromptForStringValue(string CurrentValue, string field)
        {
            string newValue = "";
            Console.Clear();
            Console.WriteLine("╔═══════════════════════════════╗");
            Console.WriteLine("║           Edit Order          ║");
            Console.WriteLine("╚═══════════════════════════════╝");
            Console.WriteLine("(Hit enter to skip edit)");
            Console.WriteLine($"{field}: {CurrentValue}");
            Console.Write("Enter New Value: ");
            newValue = Console.ReadLine();

            if (string.IsNullOrEmpty(newValue))
            {
                newValue = CurrentValue;
            }
            return newValue;
        }

        private Order ProcessEditOrder(Order order)
        {
            var ops = new OrderOperations();
            var response = ops.EditOrder(order);

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

        private List<Order> RetrieveOrderByDate(DateTime orderDate)
        {
            var response = ops.GetOrder(orderDate);
            List<Order> orders = new List<Order>();
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
                StartEdit();
            }

            return orders;
        }


    }
}
