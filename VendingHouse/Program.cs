using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            machine.Products["cans"].Add(new Can("Coca Cola", 40, 6));
            machine.Products["cans"].Add(new Can("Sprite", 40, 6));
            machine.Products["cans"].Add(new Can("Schweeps", 40, 6));
            machine.Products["bottles"].Add(new Can("Soda", 40, 5));
            machine.Products["bottles"].Add(new Can("Water", 45, 5));
            machine.Products["snacks"].Add(new Can("Chips", 45, 4.5));
            machine.Products["snacks"].Add(new Can("Ten Chap", 30, 4.5));
            machine.Products["snacks"].Add(new Can("Pringles", 30, 8));
            //DependencyManager.RegisterDependencies();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(new PurchaseMediator()));  
        }
    }
}
