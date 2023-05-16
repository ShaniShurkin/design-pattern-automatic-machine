namespace VendingHouse.Edible.PersonalPreparationDrink
{
    internal class ChocolateMilkMaker : DrinkMaker
    {
        static string imgPath = "..//..//Resources//HotDrink//shoko.jpeg";
        public ChocolateMilkMaker(Machine machine) : base(machine,imgPath)
        {
        }


        [Optional]
        public string AddChocolate()
        {

            return "Melting chocolate... \n Adding chocolate...";
        }

        [Optional]
        public string AddCocoa()
        {

            return "Adding cocoa...";
        }

        [Optional]
        public string AddWhippedCream()
        {

            return "Adding whipped cream...";
        }

    }
}
