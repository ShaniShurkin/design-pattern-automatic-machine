using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingHouse.Decorator
{
    internal class Bag : Product
    {
        protected Product product;
        

        public Bag(string name, int amount, int minAmount, Supplier supplier, double price) : 
            base(name, amount, minAmount, supplier, price)
        {
            
        }
        public 



    }
}
