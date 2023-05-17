namespace VendingHouse.Edible.PersonalPreparationDrink
{
    internal class CoffeeMaker : DrinkMaker
    {
        public CoffeeMaker() : base()
        {
            
        }



        [Optional]
        public string AddChocolate()
        {

            return "Melting chocolate... \n Adding chocolate...";
        }
        public string AddCoffee()
        {
          
            return "Adding coffee...";
        }


        [Optional]
        public string AddWhippedCream()
        {

            return "Adding whipped cream...";
        }
    }
}
