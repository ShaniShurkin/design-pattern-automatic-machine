using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingHouse
{
    internal class Snack : Product
    {
        public Snack(string name, int amount, int minAmount, double price) : 
            base(name, amount, minAmount, price)
        {
            this.Supplier = new Supplier("Dan", "0519993231");
        }
        //not sure yet.......
        public Snack(Product product):base(product)
        {
        }

        public override string GetProduct()
        {
            return $"I'm a {Name} snack ";
        }
    }
}
