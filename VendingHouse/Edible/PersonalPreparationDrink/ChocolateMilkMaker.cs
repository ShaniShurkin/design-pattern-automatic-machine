namespace VendingHouse.Edible.PersonalPreparationDrink
{
    internal class ChocolateMilkMaker : DrinkMaker
    {
        [Optional]
        public string AddChocolate()
        {

            return "Melting chocolate... \n Adding chocolate...";
        }

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
