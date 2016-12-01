using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models;
using FlooringMastery.Models.Models;

namespace FlooringMastery.Data
{
    public class FileOrderRepository : IOrderRepository
    {
        private const string FILENAME =
            @"C:\_repos\brandoncarroll-flooringmastery\FlooringMastery\FlooringMastery.UI\DataFiles\Orders_";

        private const string FILEEXT = ".txt";

        private const string header =
                "OrderNumber,CustomerName,StateName,StateAb,TaxRate,ProductType,CostPerSqFt,LaborCostPerSqFt,Area,OrderDate"

            ;

        // GET ORDER BY DATE ------
        public List<Order> GetOrdersByDate(DateTime orderDate)
        {
            var orders = ReadFromFile(orderDate);

            foreach (var date in orders)
            {
                if (date.OrderDate == orderDate)
                {
                    return orders;
                }
            }
            return null;
        }

        // GET ORDERS ------
        public List<Order> GetOrders()
        {
            return null;
        }

        // GET ORDER BY NUMBER ------
        public Order GetOrderByNumber(string orderNumber)
        {
            throw new NotImplementedException();
            //var orders = ReadFromFile(Convert.ToDateTime(orderNumber));
            //return orders.FirstOrDefault(a => a.OrderNumber == orderNumber);
        }

        // GET ORDER BY DATE AND NUMBER ------
        public Order GetOrderByDateAndNumber(DateTime orderDate, string orderNumber)
        {
            var orders = ReadFromFile(Convert.ToDateTime(orderDate));
            return orders.FirstOrDefault(a => a.OrderNumber == orderNumber && a.OrderDate == orderDate);
        }

        // ADD ------
        public bool Add(Order order)
        {
            var orders = ReadFromFile(order.OrderDate);
            orders.Add(order);

            var fileName = FILENAME + order.OrderDate.ToString("MMddyyyy") + FILEEXT;

            WriteToFile(orders, fileName);

            return true;
        }

        // EDIT ------
        public bool Edit(Order order)
        {
            // BROKEN! not removing old order.
            var orders = ReadFromFile(order.OrderDate);
            string file = (FILENAME + order.OrderDate.ToString("MMddyyyy") + FILEEXT);

            var oldLines = File.ReadAllLines(file);
            oldLines.Where(line => !line.Contains(order.OrderNumber));
            File.Delete(file);

            orders.Add(order);
            WriteToFile(orders, file);

            return true;
        }

        // REMOVE ------
        public bool Remove(Order order)
        {
            ReadFromFile(order.OrderDate);

            var file = FILENAME + order.OrderDate.ToString("MMddyyyy") + FILEEXT;

            var oldLines = File.ReadAllLines(file);
            var newLines = oldLines.Where(line => !line.Contains(order.OrderNumber));
            File.WriteAllLines(file, newLines);

            return true;
        }

        // Order GET BY ORDER DATE ------
        public Order GetOrderByDate(DateTime orderDate)
        {
            var orders = ReadFromFile(orderDate);
            return orders.FirstOrDefault(a => a.OrderNumber == Convert.ToString(orderDate));
        }

        // READ FROM FILE ------
        private List<Order> ReadFromFile(DateTime orderDate)
        {
            orderDate = DateTime.Parse(orderDate.ToShortDateString());
            var fileName = FILENAME + orderDate.ToShortDateString().Replace("/", "") + FILEEXT;

            List<Order> orders = new List<Order>();

            if (File.Exists(fileName))
            {
                using (StreamReader sr = File.OpenText(fileName))
                {
                    sr.ReadLine();

                    string inputLine = "";
                    while ((inputLine = sr.ReadLine()) != null)
                    {
                        string[] inputParts = inputLine.Split(',');
                        Order newOrder = new Order()
                        {
                            OrderNumber = inputParts[0],
                            CustomerName = inputParts[1],
                            StateName = inputParts[2],
                            StateAb = inputParts[3],
                            TaxRate = decimal.Parse(inputParts[4]),
                            ProductType = inputParts[5],
                            CostPerSqFt = decimal.Parse(inputParts[6]),
                            LaborCostPerSqFt = decimal.Parse(inputParts[7]),
                            Area = decimal.Parse(inputParts[8]),
                            OrderDate = orderDate
                            //OrderDate = DateTime.Parse(inputParts[9])
                        };

                        orders.Add(newOrder);
                    }
                }
            }
            return orders;
        }

        // WRITE TO FILE ------
        private void WriteToFile(List<Order> orders, string FileName)
        {
            using (StreamWriter sw = new StreamWriter(FileName, false))
            {
                sw.WriteLine(header);
                foreach (var order in orders)
                {
                    sw.WriteLine(
                        $"{order.OrderNumber},{order.CustomerName},{order.StateName},{order.StateAb},{order.TaxRate},{order.ProductType},{order.CostPerSqFt},{order.LaborCostPerSqFt},{order.Area},{order.OrderDate}");
                }
            }
        }

    }
}
