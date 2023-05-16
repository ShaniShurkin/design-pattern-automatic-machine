namespace VendingHouse.Edible.PersonalPreparationDrink
{
    internal class ChocolateMilkMaker : DrinkMaker
    {
        static string imgPath = "..//..//Resources//HotDrink//shoko.jpeg";
        public ChocolateMilkMaker() : base(imgPath)
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
