using FlooringMastery.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models;
using FlooringMastery.Models.Models;

namespace FlooringMastery.BLL
{
    public class OrderOperations
    {
        public OrderResponse GetOrder(DateTime orderDate)
        {
            OrderResponse response = new OrderResponse();

            var repo = OrderFactory.CreateOrderRepository();
            var order = repo.GetOrdersByDate(orderDate);

            if (order != null)
            {
                response.Success = true;
                response.OrderList = order;
            }
            else
            {
                response.Success = false;
                response.Message = $"No Orders found with date: {orderDate.ToShortDateString()}";
            }

            return response;
        }

        public OrderResponse GetOrderbyDateAndNumber(DateTime orderDate, string orderNumber)
        {
            OrderResponse response = new OrderResponse();

            var repo = OrderFactory.CreateOrderRepository();
            var order = repo.GetOrderByDateAndNumber(orderDate, orderNumber);

            if (order != null)
            {
                response.Success = true;
                response.OrderInfo = order;
            }
            else
            {
                response.Success = false;
                response.Message = $"No Orders found with number: {orderNumber}";
            }

            return response;
        }

        public OrderResponse AddOrder(Order order)
        {
            OrderResponse response = new OrderResponse();

            var repo = OrderFactory.CreateOrderRepository();
            repo.GetOrders();

           // order.OrderNumber = orders.FirstOrDefault(a => a.OrderNumber);

            if (repo.Add(order))
            {
                response.Success = true;
                response.OrderInfo = order;
            }
            else
            {
                response.Success = false;
                response.Message = "Failed to Add Order.";
            }

            return response;
        }

        public OrderResponse EditOrder(Order order)
        {
            OrderResponse response = new OrderResponse();
            var repo = OrderFactory.CreateOrderRepository();
            repo.GetOrders();

            if (repo.Edit(order))
            {
                response.Success = true;
                response.OrderInfo = order;
            }
            else
            {
                response.Success = false;
                response.Message = $"Failed to edit order.";
            }

            return response;
        }

        public OrderResponse RemoveOrder(Order order)
        {
            OrderResponse response = new OrderResponse();
            var repo = OrderFactory.CreateOrderRepository();

            if (repo.Remove(order))
            {
                response.Success = true;
                response.OrderInfo = order;
            }
            else
            {
                response.Success = false;
                response.Message = $"Failed to remove order.";
            }

            return response;
        }
    }
}
