using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WDIUnitTests.DatabaseLayer.Data
{
    public class Order : DataModel
    {
        public Order()
        {

        }

        public Order(string id, double amount, bool isCompleted)
        {
            IsCompleted =   isCompleted; 
            Amount = amount;
            Id = id;
        }

        public double Amount { get; set; }
        public bool IsCompleted { get; set; }
    }
}
