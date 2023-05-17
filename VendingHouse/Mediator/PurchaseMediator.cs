
using System;
using System.Collections.Generic;
using System.Drawing;
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

        private DailyReport dailyReport;

        public PurchaseMediator()
        {
            this.machine = Machine.MyMachine;
            this.dailyReport = new TextDailyReport();
        }

        //products operations
        public List<string> GetCategoriesList()
        {
            return this.machine.Products.Keys.ToList();
        }
        public List<Product> ProductList(string type)
        {
            List<Product> list = machine.Products[type.ToLower()];
            return list; 
        }
        private void ProductDecorations(Dictionary<string, string> purchase)
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

        //hot drinks operations
        
        public List<HotDrink> GetHotDrinksList()
        {
            return this.machine.HotDrinks.Values.ToList();
        }

        public List<string> HotDrinkOptionalMethods(string type)
        {
            List<string> list = new List<string>();
            IDrinkMaker drinkMaker = this.machine.HotDrinks[type].DrinkMaker;
            Type makerType = drinkMaker.GetType();

            this.hotDrink = this.machine.HotDrinks[type];
            
            if (makerType != null)
            {
                MethodInfo[] methods = makerType.GetMethods(BindingFlags.Public | BindingFlags.Instance)
                    .Where(m => m.GetCustomAttributes(typeof(OptionalAttribute), false).Length > 0).ToArray();
                foreach (var method in methods)
                {
                    list.Add(method.Name.Replace("Add", "Add "));
                }
            }
            return list;

        }
        private List<string> HotDrinkGetAllMethods(List<string> actions)
        {
            this.hotDrink.BasicPrice += actions.Count - 1;
            List<string> list = new List<string>() { "Reset", "AddHotWater" };
            string drinkMaker = this.hotDrink.DrinkMaker.GetType().Name;
            if (drinkMaker == "CoffeeMaker")
                list.Add("AddCoffee");
            else if (drinkMaker == "TeaMaker")
                list.Add("AddTea");
            else
            {
                list.Add("AddCocoa");
            }
            list.AddRange(actions);
            return list;

        }

        //cold drinks actions
        private string ColdDrinkCreator(string name, bool hasIce)
        {
            List<string> list = new List<string>() { name };
            list.Add(hasIce ? bool.TrueString : bool.FalseString);
            this.coldDrink = this.machine.ColdDrinks[name];
            this.coldDrink.HasIce = hasIce;
            this.coldDrink.BasicPrice += hasIce ? 2 : 0;
            return this.coldDrink.Make(list);
        }
        public List<ColdDrink> GetColdDrinksList()
        {
            return this.machine.ColdDrinks.Values.ToList();
        }

        #region purchase operations

        //machine operations
        private List<string> RemoveIngredients(List<string> operations)
        {
            List<string> keys = new List<string>();
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
                if (isMissing)
                    keys.Add(key);
            }
            return keys;
        }
        private bool RemoveProduct(string subType)
        {
            return this.machine.RemoveProduct(this.product.Name,subType);
           
        }

        //report operations
        private void CreateReport(string name, Actions action, string price)
        {
            this.dailyReport.AddReport(DateTime.Now, name, action, $"price: {price}$");
        }

        //supplier operations
        public string MessageToSupplier(List<string> keysToMessage, Supplier supplier)
        {
            string messages = "";
            if (keysToMessage.Count == 0)
                return "";
            foreach (string key in keysToMessage)
            {
                messages+=$"{supplier.Message(key)}\n";
            }
            return messages;
        }
        public string MessageToSupplier()
        {
            return  $"{(this.product.Supplier).Message(this.product.Name)}\n";
        }
        
        //payment operations
        private double Pay(double price, double amount)
        {
            this.payment = new Payment();
            return this.payment.Pay(price, amount);
        }

        #endregion

        //mediator - external 
        public void Notify(Dictionary<string, string> purchase, string operation)
        {

            switch (operation)
            {
                case "product":
                    ProductDecorations(purchase);
                    if (this.RemoveProduct(purchase["subType"]))
                        purchase["messagesToSupplier"] = purchase.ContainsKey("messagesToSupplier")? 
                            purchase["messagesToSupplier"] + this.MessageToSupplier(): 
                            this.MessageToSupplier();
                    return;
                case "hot drink":
                    List<string> methods = this.HotDrinkGetAllMethods(purchase["methods"].Split(',').ToList());
                    List<string> keysToMessage = RemoveIngredients(methods);
                    purchase["messagesToSupplier"] = purchase.ContainsKey("messagesToSupplier") ? 
                        purchase["messagesToSupplier"] + this.MessageToSupplier(keysToMessage, Ingredient.Supplier) : 
                        this.MessageToSupplier(keysToMessage, Ingredient.Supplier);
                    purchase["getProduct"] = this.hotDrink.Make(methods);
                    purchase["price"] = this.hotDrink.BasicPrice.ToString();
                    return;
                case "cold drink":
                    purchase["getProduct"] = this.ColdDrinkCreator(purchase["name"], bool.Parse(purchase["hasIce"]));
                    purchase["price"] = this.coldDrink.BasicPrice.ToString();
                    return;
                case "pay":
                    this.CreateReport(purchase["name"], Actions.SELLING, purchase["price"]);
                    purchase["excess"] = this.Pay(double.Parse(purchase["price"]), double.Parse(purchase["excess"])).ToString();
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
