using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingHouse
{
    internal class Payment
    {
        public double Pay(double price, double amountReceived)
        {
            return amountReceived - price;
        }
        
    }
}
