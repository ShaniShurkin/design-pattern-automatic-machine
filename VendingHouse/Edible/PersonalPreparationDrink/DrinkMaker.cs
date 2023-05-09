using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingHouse
{
    internal abstract class DrinkMaker : IDrinkMaker
    {
        Machine machine;
        
        public string Reset()
        {
            return "";
        }
        public string AddHotWater()
        {
            return "";
        }
        public string AddSugar()
        {
            return "";
        }
        public string AddMilk()
        {
            return "";
        }
        
    }
}
