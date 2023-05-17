using System;
using System.Collections.Generic;
using VendingHouse.Edible.PersonalPreparationDrink;

namespace VendingHouse
{
    internal class Machine
    {
        public Dictionary<string, List<Product>> Products { get; private set; }
        public Dictionary<string, HotDrink> HotDrinks { get; private set; }
        public Dictionary<string, ColdDrink> ColdDrinks { get; private set; }
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

            HotDrinks = new Dictionary<string, HotDrink>();
            HotDrinks.Add("coffee", new HotDrink("coffee", new CoffeeMaker(), 8));
            HotDrinks.Add("chocolate milk", new HotDrink("chocolate milk", new ChocolateMilkMaker(), 6));
            HotDrinks.Add("tea", new HotDrink("tea", new TeaMaker(), 6));

            ColdDrinks = new Dictionary<string, ColdDrink>();
            ColdDrinks.Add("orange juice", new ColdDrink("orange juice", 6));
            ColdDrinks.Add("apple juice", new ColdDrink("apple juice", 5));
            ColdDrinks.Add("water", new ColdDrink("water", 4));

            Ingredients = new Dictionary<string, Ingredient>();
            Ingredients.Add("cups", new Ingredient("cups", 300, 50, 1, "Cup"));
            Ingredients.Add("hot water", new Ingredient("hot water", 4000, 500, 50, "ML"));
            Ingredients.Add("sugar", new Ingredient("sugar", 170, 30, 5, "g"));
            Ingredients.Add("milk", new Ingredient("milk", 3000, 500, 50, "ML"));
            Ingredients.Add("coffee", new Ingredient("coffee", 1000, 50, 3, "g"));
            Ingredients.Add("chocolate", new Ingredient("chocolate", 300, 20, 6, "g"));
            Ingredients.Add("tea", new Ingredient("tea", 300, 20, 5, "g"));
            Ingredients.Add("cocoa", new Ingredient("cocoa", 300, 20, 3, "g"));
            Ingredients.Add("whipped cream", new Ingredient("whipped cream", 200, 20, 5, "g"));
            Ingredients.Add("tea leaves", new Ingredient("tea leaves", 200, 20, 5, "g"));
        }
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

        public bool RemoveIngredient(string ingredient)
        {
            if(ingredient != "")
            {
                Ingredient selectedIngredient = Ingredients[ingredient.ToLower()];
                selectedIngredient.Amount -= selectedIngredient.UnitQuantity;
                return selectedIngredient.Amount < selectedIngredient.MinAmount ? true : false;
            }
            return false;
        }

        public bool RemoveProduct(string product,string type)
        {
            Product selectedProduct = Products[type].Find((p) => p.Name == product);
            selectedProduct.Amount--;
            return selectedProduct.Amount < Product.MinAmount ? true : false;
        }




    }
}
