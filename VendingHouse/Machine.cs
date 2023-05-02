using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingHouse
{
    internal class Machine
    {
        List<List<Product>> products;
        List<Ingredient> ingredients;

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
