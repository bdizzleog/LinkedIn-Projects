using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Models.Models
{
    public class Order
    {
        public DateTime OrderDate { get; set; }
        public string OrderNumber { get; set; }
        public string CustomerName { get; set; }
        public string StateName { get; set; }
        public string StateAb { get; set; }
        public decimal TaxRate { get; set; }
        public string ProductType { get; set; }
        public decimal CostPerSqFt { get; set; }
        public decimal LaborCostPerSqFt { get; set; }
        public decimal Area { get; set; }
    }
}
