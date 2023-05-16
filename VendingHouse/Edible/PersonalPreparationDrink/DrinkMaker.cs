using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingHouse.Edible.PersonalPreparationDrink;

namespace VendingHouse
{
    internal abstract class DrinkMaker : IDrinkMaker
    {
        static string imgPath;
        static Image Image { get; set; }

        protected Machine machine;
        public DrinkMaker(Machine machine,string path)
        {
            this.machine = machine;
            imgPath = path;
            if (Path.IsPathRooted(path) && Directory.Exists(Path.GetPathRoot(path)))
            {
               Image = Image.FromFile(path);
            }
            ////else....
            Image = Image.FromFile(path);

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
