﻿

namespace VendingHouse
{
    internal class Snack : Product
    {
        public Snack(string name, int amount, double price, string path) : 
            base(name, amount, price, path )
        {
            MinAmount =15; 
            this.Supplier = new Supplier("Dan", "0519993231");
            MinAmount = 15;
        }
        public Snack(Product product):base(product)
        {
        }

        public override string GetProduct()
        {
            return $"{Name} snack ";
        }
    }
}
