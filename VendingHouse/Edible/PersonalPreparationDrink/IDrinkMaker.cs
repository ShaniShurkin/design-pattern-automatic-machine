using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingHouse
{
    internal interface IDrinkMaker
    {
        string Reset();

        string AddHotWater();

        string AddSugar();
        
        string AddMilk();


    }
}
