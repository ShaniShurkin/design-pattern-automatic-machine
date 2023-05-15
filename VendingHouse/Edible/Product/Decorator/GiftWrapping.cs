using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingHouse.Decorator
{
    internal class GiftWrapping : Product
    {
        public GiftWrapping(Product product) : base(product)
        {
        }
        public override string GetProduct()
        {
            return $"{_Product.GetProduct()} + gift wrapping";
        }
    }
}
