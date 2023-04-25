using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingHouse
{
    internal class Buttle : Drink
    {
        protected Product product;
        public Buttle(string name, int amount, int minAmount, Supplier supplier, double price) :
            base(name, amount, minAmount, supplier, price)
        {
        }
        public override string GetProduct()
        {
            return "";
        }
    }
}
