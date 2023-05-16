namespace VendingHouse.Edible.PersonalPreparationDrink
{
    internal class CoffeeMaker : DrinkMaker
    {
        static string imgPath = "..//..//Resources//HotDrink//coffee.jpg";
        public CoffeeMaker() : base(imgPath)
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
