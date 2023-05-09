using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingHouse
{
    internal class Machine
    {
        public Dictionary<string, List<Product>> Products { get; private set; }
        public List<Ingredient> Ingredients { get; private set; }

        public Machine()
        {
            Products = new Dictionary<string, List<Product>>();
            Products.Add("bottles", new List<Product>());
            ///Products["bottles"].Add(new Bottle("d",2,1,new Supplier("r", "r"), 3, new PurchaseMediator()));
            Products.Add("cans", new List<Product>());
            Products.Add("snacks", new List<Product>());
           
        }

        /// <summary>
        /// Adds new product 
        /// </summary>
        /// <param name="product"></param>
        public void Add(Iedible product)
        {

        }

        /// <summary>
        /// Removes the product from the list
        /// and checks if the product's amount came to the min amount 
        /// </summary>
        /// <param name="product"></param>
        /// <returns>
        /// true - If the product's amount equals to the min amount 
        /// </returns>
        public bool Remove(Iedible product)
        {
            return true;
        }


        

    }
}
