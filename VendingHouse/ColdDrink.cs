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
        
        public ColdDrink(string name, double basicPrice, bool hasIce = true) :
            base(name, basicPrice)
        {
            HasIce=hasIce;
        }
        public override string Make()
        {
            string result =  $"pouring {Name} ";
            return HasIce ? $"{result} with ice cubes..." : $"{result}...";
        }
    }
}
