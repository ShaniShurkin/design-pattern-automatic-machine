using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingHouse
{
    internal abstract class Drink : Product
    {
        
        public Drink(string name, int amount, int minAmount, Supplier supplier, double price) : 
            base(name, amount, minAmount, supplier, price)
        {
        }
        public Drink(Product product) : base(product)
        {
        }
    }
}
