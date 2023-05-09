using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingHouse
{
    internal abstract class Product :IMediator, Iedible
    {
        public string Name { get; set; }
        public int Amount { get; set; }
        public int MinAmount { get; set; }
        public Supplier Supplier { get; set; }
        public double Price { get; set; }
        protected Product _Product { get; set; }
        public IMediator Mediator { get; set; }


        public Product(string name, int amount, int minAmount, double price, IMediator mediator)
        {
            this.Name = name;
            this.Amount = amount;
            this.MinAmount = minAmount;
            this.Price = price;
            this.Mediator = mediator;
        }

        public Product(Product product)
        {
            this._Product = product;
        }
        public abstract string GetProduct();

        public void Notify(object sender)
        {
            throw new NotImplementedException();
        }
    }
}
