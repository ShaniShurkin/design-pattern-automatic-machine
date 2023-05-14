using System;
using System.Collections.Generic;

namespace VendingHouse
{
    internal class Machine
    {
        public Dictionary<string, List<Product>> Products { get; private set; }
        public Dictionary<string, Ingredient> Ingredients { get; private set; }
        static Machine myMachine;
        static object locker = new object();
        public static Machine MyMachine
        {
            get
            {
                if (myMachine == null)
                {
                    lock (locker)
                    {
                        if (myMachine == null)
                        {
                            myMachine = new Machine();
                        }
                    }
                }
                return myMachine;
            }
        }
        private Machine()
        {
            Products = new Dictionary<string, List<Product>>();
            Products.Add("bottles", new List<Product>());
            Products.Add("cans", new List<Product>());
            Products.Add("snacks", new List<Product>());

            Ingredients = new Dictionary<string, Ingredient>();
            Ingredients.Add("cups", new Ingredient("cups", 300, 50,1,"Cup"));
            Ingredients.Add("hot water", new Ingredient("hot water", 4000, 500,50,"ML"));
            Ingredients.Add("sugar", new Ingredient("sugar", 170, 30,5,"g"));
            Ingredients.Add("milk", new Ingredient("milk", 3000, 500,50,"ML"));
            Ingredients.Add("coffee", new Ingredient("coffee", 1000, 50,3,"g"));
            Ingredients.Add("chocolate", new Ingredient("chocolate", 300, 20,6,"g"));
            Ingredients.Add("tea", new Ingredient("tea", 300, 20,5,"g"));
            Ingredients.Add("cocoa", new Ingredient("cocoa", 300, 20,3,"g"));
            Ingredients.Add("whipped cream", new Ingredient("whipped cream", 200, 20,5,"g"));
            Ingredients.Add("tea leaves", new Ingredient("tea leaves", 200, 20,5,"g"));
        }

        /// <summary>
        /// Adds new product 
        /// </summary>
        /// <param name="product"></param>
        public void Add(Iedible product)
        {
            Type type = product.GetType().BaseType;

            if (type == typeof(Product))
            {
                Product selectedProduct = Products[product.GetType().ToString().ToLower() + "s"].Find((p) => p.Name == product.Name);
                if (selectedProduct != null)
                    selectedProduct.Amount += product.Amount;
                else
                {
                    Products[product.GetType().ToString().ToLower() + "s"].Add((Product)product);
                }
            }
            else
            {
                Ingredient selectedIngredient = Ingredients[product.Name];
                selectedIngredient.Amount += product.Amount;
            }


        }

        /// <summary>
        /// Removes the product from the list
        /// and checks if the product's amount came to the min amount 
        /// </summary>
        /// <param name="ingredient"></param>
        /// <returns>
        /// True - If the product's amount equals to the min amount 
        /// </returns>
        public bool RemoveIngredient(string ingredient)
        {
            
            Ingredient selectedIngredient = Ingredients[ingredient.ToLower()];
            selectedIngredient.Amount -= selectedIngredient.UnitQuantity;
            return selectedIngredient.Amount < selectedIngredient.MinAmount ? true : false;
        }

        /// <summary>
        /// Removes the product from the list
        /// and checks if the product's amount came to the min amount 
        /// </summary>
        /// <param name="product"></param>
        /// <returns>
        /// True - If the product's amount equals to the min amount 
        /// </returns>
        public bool RemoveProduct(string product)
        {

                Product selectedProduct = Products[product.GetType().ToString().ToLower() + "s"].Find((p) => p.Name == product);
                selectedProduct.Amount--;
                return selectedProduct.Amount < selectedProduct.MinAmount ? true : false;
        }




    }
}
