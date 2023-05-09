using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingHouse.Decorator
{
    internal class Bag : Product
    {
        public Bag(Product product) : base(product)
        {
        }
        public override string GetProduct()
        {
            return $"{this._Product.GetProduct()} with bag";  
        }
    }
}
