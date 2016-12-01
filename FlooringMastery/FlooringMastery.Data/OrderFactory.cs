using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Data
{
    public class OrderFactory
    {
        public static IOrderRepository CreateOrderRepository()
        {
            IOrderRepository repo;

            string mode = ConfigurationManager.AppSettings["mode"].ToString();

            switch (mode.ToUpper())
            {
                case "TEST":
                    repo = new InMemOrderRepository();
                    break;
                case "PROD":
                    repo = new FileOrderRepository();
                    break;
                default:
                    throw new Exception("That mode doesn't exist.");
            }

            return repo;
        }
    }
}
