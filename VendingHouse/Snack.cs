using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingHouse
{
    internal class Snack : Product
    {
        public Snack(string name, int amount, int minAmount, Supplier supplier, double price) : 
            base(name, amount, minAmount, supplier, price)
        {
        }
        public Snack(Product product):base(product)
        {
        }

        public override string GetProduct()
        {
            return $"I'm a {Name} snack";
        }
    }
}
