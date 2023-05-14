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
        public int UnitQuantity { get; set; }
        public string UnitOfMeasure { get; set; }
        public static Supplier Supplier { get; set; }

        public Ingredient(string name, int amount, int minAmount, int unitQuantity, string unitOfMeasure)
        {
            this.Name = name;
            this.Amount = amount;
            this.MinAmount = minAmount;
            Supplier = new Supplier("Ingredient supplier", "0502125632");
            this.UnitQuantity = unitQuantity;
            this.UnitOfMeasure = unitOfMeasure;
        }

    }
}
