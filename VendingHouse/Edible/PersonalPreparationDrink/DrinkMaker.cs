using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingHouse.Edible.PersonalPreparationDrink;

namespace VendingHouse
{
    internal abstract class DrinkMaker : IDrinkMaker
    {
        protected Machine machine;
        public DrinkMaker(Machine machine)
        {
            this.machine = machine;
        }

        public string Reset()
        {

            return "Bringing a cardboard cup...";
        }
        public string AddHotWater()
        {

            return "Adding hot water...";
        }


        [Optional]
        public string AddSugar(int num)
        {

            return $"Adding {num} teaspoons of sugar..."; ;
        }


        [Optional]
        public string AddMilk()
        {

            return "Pouring milk...";
        }
        
    }
}
