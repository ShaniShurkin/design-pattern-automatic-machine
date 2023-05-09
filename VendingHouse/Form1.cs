using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace VendingHouse
{
    public partial class Form1 : Form
    {
        IMediator mediator;
        Product product;
        HotColdDrink hotColdDrink; 
        List<Iedible> iedibles;

        public Form1(IMediator mediator)
        {
            InitializeComponent();
            this.mediator = mediator;
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    VendingMachine.TabPages[1].Controls.Add(new Button());
        //}

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void radioProduct_CheckedChanged(object sender, EventArgs e)
        {
            
            List<string> products = new List<string>() { "Can", "Bottle", "Snack" };
            CreateBtns(products);
        }

        private void radioHotDrink_CheckedChanged(object sender, EventArgs e)
        {
            
            List<string> hotDrinks = new List<string>() { "Coffee", "Chocolate Milk", "Tea" };
            CreateBtns(hotDrinks);
        }

        private void radioColdDrink_CheckedChanged(object sender, EventArgs e)
        {
            List<string> coldDrinks = new List<string>() { "Orange Juice", "Apple Juice", "Water" };
            CreateBtns(coldDrinks);
        }
        private void CreateBtns(List<string> names)
        {
            Button btn;
            VendingMachine.SelectedIndex = 1;
            int place = VendingMachine.SelectedIndex;
            VendingMachine.TabPages[place].Controls.Clear();
            int locationY = 100;
            foreach (string name in names)
            {
                btn = new Button()
                {
                    Text = name,
                    Name = "btn" + name,
                    Location = new Point(300, locationY),
                    Size = new Size(120, 40),
                };
                btn.Click += CreateList;
                VendingMachine.TabPages[place].Controls.Add(btn);
                locationY += 60;
                

             }
        }
        private void CreateList(object sender, EventArgs e)
        {
            VendingMachine.SelectedIndex = 2;
            string name = (sender as Button).Text;
            List<Product> list = ((PurchaseMediator) mediator).Notify(name);
            foreach (Product product in list)
            {
                Button btn = new Button()
                {
                    Text = product.Name,
                    Location = new Point(300, 100),
                    Size = new Size(120, 40),
                };
            }  

            //string name = (sender as Button).Text;
            //var classAddress = $"VendingHouse.{name}";
            //Type type = Type.GetType(classAddress);
            //object instance = Activator.CreateInstance(type);
            //MessageBox.Show(instance.ToString());

        }

        private void backBtn_Click(object sender, EventArgs e)
        {

            int index = VendingMachine.SelectedIndex;
            VendingMachine.SelectedIndex = index > 0 ? index - 1 : index;
        }
    }
}
