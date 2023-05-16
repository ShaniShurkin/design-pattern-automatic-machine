using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using VendingHouse.Properties;
using VendingHouse.Report;

namespace VendingHouse
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Machine machine = Machine.MyMachine;
            machine.Products["cans"].Add(new Can("Coca Cola", 30, 6, "..//..//Resources//Cans//קולה.png" ));
            machine.Products["cans"].Add(new Can("Sprite", 30,  6, "..//..//Resources//Cans//ספרייט2.png"));
            machine.Products["cans"].Add(new Can("XL", 30,  6, "..//..//Resources//Cans//XL.jpeg"));
            machine.Products["cans"].Add(new Can("Fanta", 30, 6, "..//..//Resources//Cans//פנטה.jpg"));

            machine.Products["bottles"].Add(new Bottle("Soda", 30,  5, "..//..//Resources//Bottles//סודה.jpg")); 
            machine.Products["bottles"].Add(new Bottle("Water", 30,  5, "..//..//Resources//Bottles//מים.jpg"));
            machine.Products["bottles"].Add(new Bottle("Flavored Water", 30, 5, "..//..//Resources//Bottles//מים בטעם.jpg"));

            machine.Products["snacks"].Add(new Snack("Bisli", 30, 4.5, "..//..//Resources//Snacks//ביסלי.jpg"));
            machine.Products["snacks"].Add(new Snack("Ten Chap", 30, 4.5, "..//..//Resources//Snacks//תן צאפ.jpg"));
            machine.Products["snacks"].Add(new Snack("chips", 30,  8, "..//..//Resources//Snacks//צ'יפס.jpg"));
            //machine.Products["snacks"].Add(new Snack("onion chips", 30, 8, "..//..//Resources//Snacks//ציפס טבעי (1).webp"));

            //DependencyManager.RegisterDependencies();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(new PurchaseMediator()));  
        }
    }
}
