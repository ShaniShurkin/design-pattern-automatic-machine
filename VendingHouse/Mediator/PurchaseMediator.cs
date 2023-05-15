
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using VendingHouse.Decorator;
using VendingHouse.Edible.PersonalPreparationDrink;
using VendingHouse.Report;

namespace VendingHouse
{
    internal class PurchaseMediator : IMediator
    {
        private Machine machine;

        private Product product;

        private HotDrink hotDrink;
        
        private ColdDrink coldDrink;

        private Payment payment;

        private Supplier supplier;

        private DailyReport dailyReport;

        private readonly IPrintingManager printingManager;

        public PurchaseMediator()
        {
            this.machine = Machine.MyMachine;
            this.dailyReport = new DailyReport();
        }

        public List<Product> ProductList(string type)
        {
            List<Product> list = machine.Products[type.ToLower()];
            return list;
        }

        public List<string> HotDrinkMethods(string type)
        {
            this.supplier = Ingredient.Supplier;
            List<string> list = new List<string>();
            string className = type.Replace(" ", "") + "Maker";
            Type classType = Type.GetType("VendingHouse.Edible.PersonalPreparationDrink." + className);
            IDrinkMaker drinkMaker = (IDrinkMaker)Activator.CreateInstance(classType, this.machine);
            this.hotDrink = new HotDrink(type, drinkMaker);

            if (classType != null)
            {
                MethodInfo[] methods = classType.GetMethods(BindingFlags.Public | BindingFlags.Instance)
                    .Where(m => m.GetCustomAttributes(typeof(OptionalAttribute), false).Length > 0).ToArray();
                foreach (var method in methods)
                {
                    list.Add(method.Name.Replace("Add", "Add "));
                }
            }

            return list;

        }

        public string HotDrinkCreator(List<string> operations)
        {
            List<string> list = new List<string>() { "Reset", "AddHotWater" };
            string drinkMaker = this.hotDrink.DrinkMaker.GetType().Name;
            if (drinkMaker == "CoffeeMaker")
                list.Add("AddCoffee");
            else if (drinkMaker == "TeaMaker")
                list.Add("AddTea");
            list.AddRange(operations);
            RemoveIngredients(list);
            return this.hotDrink.Make(list);
        }
        public void RemoveIngredients(List<string> operations)
        {
            foreach (string item in operations)
            {
                string key = item.Replace("Add", "");
                for (int i = 1; i < key.Length; i++)
                {
                    if (char.IsUpper(key[i]))
                    {
                        key = $"{key.Substring(0, i)} {key.Substring(i)}".ToLower();
                    }
                }
                if (item == "Reset")
                    key = "cups";
                bool isMissing = this.machine.RemoveIngredient(key);
                string messageToSupplier = "";
                if (isMissing)
                    messageToSupplier = this.supplier.Message(key);

            }

        }
        public string ColdDrinkCreator(string name, bool hasIce)
        {
            List<string> list = new List<string>() { name };
            list.Add(hasIce ? bool.TrueString : bool.FalseString);
            this.coldDrink = new ColdDrink(name, hasIce);
            this.coldDrink.BasicPrice += hasIce ? 2 : 0;
            return this.coldDrink.Make(list);
        }
        public List<string> GetCategoriesList(string type)
        {
            List<string> list;
            switch (type)
            {
                case "products":
                    list = new List<string>() { "Cans", "Bottles", "Snacks" };
                    return list;
                case "hotDrinks":
                    list = new List<string>() { "Coffee", "Chocolate Milk", "Tea" };
                    return list;
                case "coldDrinks":
                    list = new List<string>() { "Orange Juice", "Apple Juice", "Water" };
                    return list;

            }
            return null;
        }

        private void ProductOperation(Dictionary<string, string> purchase)
        {
            this.product = ProductList(purchase["subType"]).Find(p => p.Name == purchase["name"]);
            bool withBag = bool.Parse(purchase["withBag"]);
            bool withGiftWrapping = bool.Parse(purchase["withGiftWrapping"]);
            this.product.Price += withBag ? 1 : 0;
            this.product.Price += withGiftWrapping ? 2 : 0;
            this.product = withBag ? new Bag(this.product) : this.product;
            this.product = withGiftWrapping ? new GiftWrapping(this.product) : this.product;
            purchase["price"] = this.product.Price.ToString();
            purchase["getProduct"] = this.product.GetProduct();

        }
        public double Pay(double price, double amount)
        {
            this.payment = new Payment();
            return this.payment.Pay(price, amount);
        }

        private void CreateReport(string name,Actions action,string price)
        {
            this.dailyReport.AddReport(DateTime.Now, name, action, $"price: {price}$" );
        }
        public void Notify(Dictionary<string, string> purchase,string operation)
        {
    

            switch (operation)
            {
                case "product":
                    ProductOperation(purchase);
                    return;
                case "hot drink":
                    purchase["price"] = this.hotDrink.BasicPrice.ToString();
                    return;
                case "cold drink":
                    purchase["price"] = this.coldDrink.BasicPrice.ToString();
                    return;
                case "pay":
                    this.CreateReport(purchase["name"], Actions.SELLING, purchase["price"]);
                    return;
                case "createColdDrink":
                    purchase["getProduct"] = this.ColdDrinkCreator(purchase["name"], bool.Parse(purchase["hasIce"]));
                    return;
                case "createHotDrink":
                   // purchase["getProduct"] = this.ho
                    return;
                case "printReport":
                    this.dailyReport.Print();
                    return;

            }
        }
        public void Notify(object sender)
        {

        }
    }
}
