using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingHouse
{
    internal class Bottle : Drink
    {
        protected Product product;
        
        public Bottle(string name, int amount, int minAmount, Supplier supplier, double price) :
            base(name, amount, minAmount, price)
        {
        }
        public Bottle(Product product) : base(product)
        {
        }
        public override string GetProduct()
        {
            return $"I'm a {Name} bottle ";
        }
    }
}
