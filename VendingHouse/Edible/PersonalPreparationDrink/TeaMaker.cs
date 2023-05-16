namespace VendingHouse.Edible.PersonalPreparationDrink
{
    internal class TeaMaker : DrinkMaker
    {
        static string imgPath = "..//..//Resources//HotDrink//tea.jpg";
        public TeaMaker(Machine machine) : base(machine,imgPath)
        {
        }

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
