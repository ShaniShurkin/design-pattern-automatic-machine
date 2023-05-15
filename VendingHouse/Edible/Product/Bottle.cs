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

        public Bottle(string name, int amount, double price) :
            base(name, amount, price)
        {
            MinAmount = 20;
        }
        public Bottle(Product product) : base(product)
        {
            MinAmount = 20; ;
        }
        public override string GetProduct()
        {
            return $"I'm a {Name} bottle ";
        }
    }
}
