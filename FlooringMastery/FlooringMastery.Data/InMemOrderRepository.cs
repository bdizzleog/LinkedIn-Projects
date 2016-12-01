using FlooringMastery.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Data
{
    public class InMemOrderRepository : IOrderRepository
    {
        private static List<Order> _orders;

        public InMemOrderRepository()
        {
            if (_orders == null)
            {
                _orders = new List<Order>
                {
                    new Order()
                    {
                        OrderDate = DateTime.Parse("10/11/2016"),
                        OrderNumber = "123456",
                        CustomerName = "Brandon",
                        StateName = "Ohio",
                        StateAb = "OH",
                        TaxRate = 5.75m,
                        ProductType = "Tile",
                        CostPerSqFt = 1.33m,
                        LaborCostPerSqFt = 0.18m,
                        Area = 168m,
                    },

                    new Order()
                    {
                        OrderDate = DateTime.Parse("10/11/2016"),
                        OrderNumber = "982394",
                        CustomerName = "Travis",
                        StateName = "Arizona",
                        StateAb = "AZ",
                        TaxRate = 5.6m,
                        ProductType = "Wood Plank",
                        CostPerSqFt = 1.08m,
                        LaborCostPerSqFt = 0.59m,
                        Area = 238m,
                    },

                    new Order()
                    {
                        OrderDate = DateTime.Parse("10/11/2016"),
                        OrderNumber = "123465",
                        CustomerName = "Scott",
                        StateName = "Michigan",
                        StateAb = "MI",
                        TaxRate = 4.25m,
                        ProductType = "Carpet",
                        CostPerSqFt = 2.00m,
                        LaborCostPerSqFt = 1.00m,
                        Area = 100m,
                    },

                    new Order()
                    {
                        OrderDate = DateTime.Parse("10/12/2016"),
                        OrderNumber = "734512",
                        CustomerName = "Shaun",
                        StateName = "California",
                        StateAb = "CA",
                        TaxRate = 7.5m,
                        ProductType = "Vinyl Tile",
                        CostPerSqFt = 4.99m,
                        LaborCostPerSqFt = 0.98m,
                        Area = 90m,
                    }

                };
            }
        }

        public List<Order> GetAllOrdersByDate()
        {
            return _orders;
        }

        public List<Order> GetOrdersByDate(DateTime orderDate)
        {
            var results = from o in _orders
                where o.OrderDate == orderDate
                select o;

            // will not display null - fix this
            return results.ToList();
        }

        public Order GetOrderByNumber(string orderNumber)
        {
            return _orders.FirstOrDefault(a => a.OrderNumber == orderNumber);
        }

        //Gets Date and Number
        public Order GetOrderByDateAndNumber(DateTime orderDate, string orderNumber)
        {
            return _orders.FirstOrDefault(a => a.OrderNumber == orderNumber && a.OrderDate == orderDate);
        }

        public List<Order> GetOrders()
        {
            return _orders;
        }

        public bool Add(Order order)
        {
            _orders.Add(order);

            return true;
        }

        public bool Edit(Order order)
        {
            var orderToEdit = _orders.FirstOrDefault();
            _orders.Remove(orderToEdit);
            _orders.Add(order);

            return true;
        }

        public bool Remove(Order order)
        {
            _orders.Remove(order);

            return true;
        }
    }
}
