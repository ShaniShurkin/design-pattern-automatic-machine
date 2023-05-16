using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingHouse
{
    internal class ColdDrink : HotColdDrink
    {
        public bool HasIce { get; set; }
        public ColdDrink(string name, double price, bool hasIce = true) :
            base(name, price)
        {
            this.HasIce=hasIce;
        }

        public override string Make(List<string> list)
        {
            string result = $"Pouring {list[0]} ";
            this.HasIce = bool.Parse(list[1]);
            return HasIce ? $"{result} with ice cubes..." : $"{result}...";
        }
    }
}
