
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using VendingHouse.Edible.PersonalPreparationDrink;
using VendingHouse.Report;

namespace VendingHouse
{
    internal class PurchaseMediator : IMediator
    {
        private Machine machine;

        private readonly Product product;

        private HotColdDrink hotColdDrink;

        private readonly Payment payment;

        private Supplier supplier;

        private readonly DailyReport dailyReport;

        private readonly IPrintingManager printingManager;
        
        public PurchaseMediator()
        {
            this.machine = Machine.MyMachine;
            //this.product.SetMediator(this);
            //this.hotColdDrink.SetMediator(this);
            //this.payment.SetMediator(this);
            //this.supplier.SetMediator(this);
            //this.dailyReport.SetMediator(this);
            ////this.printingManager = new TxtPrintingManager();
            //this.printingManager.SetMediator(this);
            //this.payment = new Payment();
            //this.payment.SetMediator(this);
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
            IDrinkMaker drinkMaker = (IDrinkMaker)Activator.CreateInstance(classType,this.machine);
            this.hotColdDrink = new HotDrink(type, 12, drinkMaker);
                
            if (classType != null)
            {
                MethodInfo[] methods = classType.GetMethods(BindingFlags.Public | BindingFlags.Instance )
                    .Where(m => m.GetCustomAttributes(typeof(OptionalAttribute), false).Length > 0).ToArray();
                foreach (var method in methods)
                {
                    list.Add(method.Name.Replace("Add","Add "));
                }
            }
           
            return list;
            
        }
        public string HotDrinkCreator(List<string> operations)
        {
            List<string> list = new List<string>() { "Reset", "AddHotWater" };
            string drinkMaker = ((HotDrink)this.hotColdDrink).DrinkMaker.GetType().Name;
            if(drinkMaker == "CoffeeMaker")
                list.Add("AddCoffee");
            else if(drinkMaker == "TeaMaker")
                list.Add("AddTea");
            list.AddRange(operations);
            RemoveIngredients(list);
            return this.hotColdDrink.Make(list);
        }
        public void RemoveIngredients(List<string> operations)
        {
            foreach (string item in operations)
            {
                string key = item.Replace("Add", "");
                for(int i = 1; i < key.Length; i++)   
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
                   messageToSupplier =  this.supplier.Message(key);
                 
            }

        }
        public string ColdDrinkCreator(string name, bool hasIce)
        {
            List<string> list = new List<string>() { "name" };
            list.Add(hasIce ? "true" : "false");
            this.hotColdDrink = new ColdDrink(name, hasIce ? 11 : 9, hasIce);
            return this.hotColdDrink.Make(list);
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

        public List<T> Notify<T>(string type) 
        {
          //switch (type)
          //  {
          //      case "Can":
          //      case "Snack":
          //      case "Bottle":
          //          return ProductList(type);
          //  }
            return new List<T>();
        }


            public void Notify(object sender)
        {
            //switch (sender.ToString())
            //{
            //    case "Can":
            //    case "Snack":
            //    case "Bottle":
            //        ProductOperation(sender.ToString());
            //        break;
            //    case "Coffee":
            //    case "Ch":
            //    case "Bottle":
            //        ProductOperation(className);
            //        break;
            //}
        }
    }
}
