using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace VendingHouse
{
    public partial class Form1 : Form
    {

        private readonly IMediator mediator;
        Product product;
        HotColdDrink hotColdDrink;
        List<Iedible> iedibles;



        public Form1(IMediator mediator)
        {
            InitializeComponent();
            this.mediator = mediator;
            //mediator = DependencyManager.Resolve<IMediator>();
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

            List<string> products = ((PurchaseMediator)mediator).GetCategoriesList("products");
            CreateBtns(products, CreateProdutList);

        }

        private void radioHotDrink_CheckedChanged(object sender, EventArgs e)
        {
            List<string> hotDrinks = ((PurchaseMediator)mediator).GetCategoriesList("hotDrinks");
            CreateBtns(hotDrinks, CreateHotDrinkOperationList);
        }

        private void radioColdDrink_CheckedChanged(object sender, EventArgs e)
        {
            List<string> coldDrinks = ((PurchaseMediator)mediator).GetCategoriesList("coldDrinks");
            CreateBtns(coldDrinks, CreateColdDrinkCheckbox);
        }
        private void CreateBtns(List<string> names, EventHandler createList)
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
                btn.Click += createList;
                VendingMachine.TabPages[place].Controls.Add(btn);
                locationY += 60;

            }
        }

        private void CreateProdutList(object sender, EventArgs e)
        {
            VendingMachine.SelectedIndex = 2;
            int place = VendingMachine.SelectedIndex;
            VendingMachine.TabPages[place].Controls.Clear();
            int locationY = 100;
            string name = (sender as Button).Text;
            List<Product> list = ((PurchaseMediator)mediator).ProductList(name);
            foreach (Product product in list)
            {
                Button btn = new Button()
                {
                    Text = product.Name,
                    Location = new Point(300, locationY),
                    Size = new Size(120, 40),
                };
                btn.Click += GetMoreOptions;
                VendingMachine.TabPages[place].Controls.Add(btn);
                locationY += 60;
            }

        }

        private void GetMoreOptions(object sender, EventArgs e)
        {
            VendingMachine.SelectedIndex = 3;
            int place = VendingMachine.SelectedIndex;
            VendingMachine.TabPages[place].Controls.Clear();
            CheckBox c1 = new CheckBox()
            {
                Text = "Add bag",
                Location = new Point(400, 150),
                Size = new Size(100, 40),
            };

            CheckBox c2 = new CheckBox()
            {
                Text = "Add gift wrapping",
                Location = new Point(500, 150),
                Size = new Size(180, 40),
            };
            Button btn = new Button()
            {
                Text = "Payment",
                Location = new Point(450, 300),
                Size = new Size(120, 40),
            };
            btn.Click += Pay;

            VendingMachine.TabPages[place].Controls.AddRange(new List<Control>() { c1, c2, btn }.ToArray());
        }

        private void Pay(object sender, EventArgs e)
        {

        }

        private void CreateHotDrinkOperationList(object sender, EventArgs e)
        {
            VendingMachine.SelectedIndex = 2;
            int place = VendingMachine.SelectedIndex;
            VendingMachine.TabPages[place].Controls.Clear();
            int locationY = 100;
            string name = (sender as Button).Text;
            List<string> list = ((PurchaseMediator)mediator).HotDrinkMethods(name);
            foreach (string method in list)
            {
                CheckBox cb = new CheckBox()
                {
                    Text = method,
                    Name = method.Replace(" ", ""),
                    Location = new Point(300, locationY),
                    Size = new Size(120, 40),
                };

                VendingMachine.TabPages[place].Controls.Add(cb);
                locationY += 60;

            }
            Button btn = new Button()
            {
                Text = "To create...",
                Location = new Point(300, locationY),
                Size = new Size(200, 40),
            };

            btn.Click += CreateHotDrink;
            VendingMachine.TabPages[place].Controls.Add(btn);
        }

        private void CreateHotDrink(object sender, EventArgs e)
        {
            List<string> methods = new List<string>();

            foreach (CheckBox checkBox in VendingMachine.TabPages[2].Controls.OfType<CheckBox>())
            {
                if (checkBox.Checked)
                {
                    methods.Add(checkBox.Name);
                }
            }
            MessageBox.Show(((PurchaseMediator)this.mediator).HotDrinkCreator(methods));
        }
        private void CreateColdDrinkCheckbox(object sender, EventArgs e)
        {
            CheckBox cb = new CheckBox()
            {
                Text = "Ice cubes",
                Name = "WithIceCubes",
                Location = new Point(350, 300),
                Size = new Size(120, 40),
            };

            VendingMachine.TabPages[1].Controls.Add(cb);
        }


        private void backBtn_Click(object sender, EventArgs e)
        {

            int index = VendingMachine.SelectedIndex;
            VendingMachine.SelectedIndex = index > 0 ? index - 1 : index;
        }
    }
}
