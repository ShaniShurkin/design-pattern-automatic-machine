using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingHouse
{
    internal class HotDrink : HotColdDrink, IDrinkMaker
    {
        IDrinkMaker DrinkMaker;
        public HotDrink(string name, double basicPrice) : 
            base(name, basicPrice)
        {
        }

        public override string Make()
        {
            return "";
        }
    }
}
