namespace VendingHouse.Edible.PersonalPreparationDrink
{
    internal class TeaMaker : DrinkMaker
    {
        public string AddTea()
        {

            return "Adding tea...";
        }

        [Optional]
        public string AddTeaLeaves()
        {

            return "Adding tea leaves....";
        }
    }
}
