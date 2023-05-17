﻿

namespace VendingHouse
{
    internal abstract class Drink : Product
    {
        
        
        public Drink(string name, int amount, double price, string path) : 
            base(name, amount, price, path)
        {
            this.Supplier = new Supplier("Shay", "0542342322");
        }
        public Drink(Product product) : base(product)
        {
        }
    }
}
