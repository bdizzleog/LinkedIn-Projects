using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models.Models;

namespace FlooringMastery.Data
{
    public interface IOrderRepository
    {
        Order GetOrderByNumber(string orderNumber);

        Order GetOrderByDateAndNumber(DateTime orderDate, string orderNumber);

        List<Order> GetOrdersByDate(DateTime orderDate);

        List<Order> GetOrders();

        bool Add(Order order);

        bool Edit(Order order);

        bool Remove(Order order);
        
    }
}
