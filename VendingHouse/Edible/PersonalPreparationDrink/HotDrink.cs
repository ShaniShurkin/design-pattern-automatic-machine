using System.Collections.Generic;
using System.Reflection;

namespace VendingHouse
{
    internal class HotDrink : HotColdDrink
    {
        public IDrinkMaker DrinkMaker { get; set; }
        public HotDrink(string name, double basicPrice, IDrinkMaker drinkMaker) :
            base(name, basicPrice)
        {
            this.DrinkMaker = drinkMaker;

        }
        
        public override string Make(List<string> list)
        {
            string operations = "";
            int countTeaSpoonsOfSugar = 0;

            foreach (var operation in list)
            {
                MethodInfo method = DrinkMaker.GetType().GetMethod(operation);
                if (operation == "AddSugar")
                {
                    countTeaSpoonsOfSugar++;
                      
                }
                    
                else if (method != null)
                {
                    operations+= $"{ method.Invoke(DrinkMaker, null)}\n";
                }
             
            }
            if (countTeaSpoonsOfSugar > 0)
            {
                operations += DrinkMaker.AddSugar(countTeaSpoonsOfSugar);
                
            }

            return operations;
        }
    }
}
