namespace VendingHouse.Edible.PersonalPreparationDrink
{
    internal class ChocolateMilkMaker : DrinkMaker
    {
        public ChocolateMilkMaker(Machine machine) : base(machine)
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
