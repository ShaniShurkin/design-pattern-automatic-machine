using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingHouse
{
    internal class Can : Drink
    {
        protected Product product;
        public Can(string name, int amount, int minAmount, double price) :
            base(name, amount, minAmount, price)
        {
   
        }

        public Can(Product product) : base(product)
        {
        }

        public override string GetProduct()
        {
            return $"I'm a {Name} can ";
        }
    }
}
