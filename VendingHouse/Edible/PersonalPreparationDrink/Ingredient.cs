using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingHouse
{
    internal class Ingredient : Iedible
    {
        public string Name { get; set; }
        public int Amount { get; set; }
        public int MinAmount { get; set; }
        public Supplier Supplier { get; set; }

        //mediator
        public Ingredient(string name, int amount, int minAmount, Supplier supplier)
        {
            this.Name = name;
            this.Amount = amount;
            this.MinAmount = minAmount;
            this.Supplier = supplier;
        }

        public string GetProduct()
        {
            throw new NotImplementedException();
        }
    }
}
