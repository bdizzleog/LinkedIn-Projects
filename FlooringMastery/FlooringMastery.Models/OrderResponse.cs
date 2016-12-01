using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models.Models;

namespace FlooringMastery.Models
{
    public class OrderResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public Order OrderInfo { get; set; }
        public List<Order> OrderList { get; set; }
    }
}
