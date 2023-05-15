

namespace VendingHouse
{
    internal class Snack : Product
    {
        public Snack(string name, int amount, double price) : 
            base(name, amount, price)
        {
            this.MinAmount =15; 
            this.Supplier = new Supplier("Dan", "0519993231");
            MinAmount = 15;
        }
        //not sure yet.......
        public Snack(Product product):base(product)
        {
        }

        public override string GetProduct()
        {
            return $"I'm a {Name} snack ";
        }
    }
}
