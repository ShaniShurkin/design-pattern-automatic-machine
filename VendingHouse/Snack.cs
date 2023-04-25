using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingHouse
{
    internal class Snack : Product
    {
        protected Product product;
        public Snack(string name, int amount, int minAmount, Supplier supplier, double price) : 
            base(name, amount, minAmount, supplier, price)
        {
        }

        public override string GetProduct()
        {
            return "";
        }
    }
}
