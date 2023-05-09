using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingHouse
{
    internal abstract class HotColdDrink
    {
        public string Name { get; set; }
        public double BasicPrice { get; set; }

        public HotColdDrink(string name, double basicPrice)
        {
            Name=name;
            BasicPrice=basicPrice;
        }
        public abstract string Make();
        

    }
}
