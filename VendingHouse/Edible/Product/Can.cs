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
        public Can(string name, int amount, double price, string path) :
            base(name, amount, price, path)
        {
            MinAmount = 25;
        }

        public Can(Product product) : base(product)
        {
            MinAmount = 20; ;
        }

        public override string GetProduct()
        {
            return $"I'm a {Name} can ";
        }
    }
}
