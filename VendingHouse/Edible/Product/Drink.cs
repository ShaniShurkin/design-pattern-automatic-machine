using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingHouse
{
    internal abstract class Drink : Product
    {
        
        
        public Drink(string name, int amount, double price) : 
            base(name, amount,price)
        {
            //We have to solve this problem with using injection and interface
            this.Supplier = new Supplier("Shay", "0542342322");
        }
        public Drink(Product product) : base(product)
        {
        }
    }
}
