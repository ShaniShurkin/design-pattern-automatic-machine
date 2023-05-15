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
        private Button applyBtn;
        private Dictionary<string, string> purchase;


        public Form1(IMediator mediator)
        {
            InitializeComponent();
            this.mediator = mediator;
            this.purchase = new Dictionary<string, string>();
            this.applyBtn = new Button()
            {
                Text = "Apply",
                Name = "btn" + "Apply",
                Location = new Point(400, 400),
                Size = new Size(120, 40),      
            };

            //mediator = DependencyManager.Resolve<IMediator>();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void radioProduct_CheckedChanged(object sender, EventArgs e)
        {
            purchase["type"] = "product";
            List<string> products = ((PurchaseMediator)mediator).GetCategoriesList("products");
            CreateBtns(products, CreateProdutList);

        }

        private void radioHotDrink_CheckedChanged(object sender, EventArgs e)
        {
            purchase["type"] = "hot drink";
            List<string> hotDrinks = ((PurchaseMediator)mediator).GetCategoriesList("hotDrinks");
            CreateBtns(hotDrinks, CreateHotDrinkOperationList);
        }

        private void radioColdDrink_CheckedChanged(object sender, EventArgs e)
        {
            purchase["type"] = "cold drink";
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
            purchase["subType"] = name;
            List<Product> list = ((PurchaseMediator)mediator).ProductList(name);
            foreach (Product product in list)
            {
                Button btn = new Button()
                {
                    Text = product.Name,
                    Location = new Point(300, locationY),
                    Size = new Size(120, 40),
                };
                btn.Click +=(s,e2)=> {
                    purchase["name"] = product.Name;
                    GetMoreOptions();
                };
                VendingMachine.TabPages[place].Controls.Add(btn);
                locationY += 60;
            }

        }

        private void GetMoreOptions()
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
            this.applyBtn.Click += (s, e2) =>
            {
                purchase["withBag"] = c1.Checked.ToString();
                purchase["withGiftWrapping"] = c2.Checked.ToString();
                Apply(4);

            };

            VendingMachine.TabPages[place].Controls.AddRange(new List<Control>() { c1, c2, this.applyBtn }.ToArray());
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
            purchase["name"] = name;
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

            this.applyBtn.Click += (s, e2) =>
            {
                purchase["getProduct"] = CreateHotDrink();
                Apply(3);

            };
            VendingMachine.TabPages[place].Controls.Add(this.applyBtn);
            
        }

        private string CreateHotDrink()
        {
            List<string> methods = new List<string>();

            foreach (CheckBox checkBox in VendingMachine.TabPages[2].Controls.OfType<CheckBox>())
            {
                if (checkBox.Checked)
                {
                    methods.Add(checkBox.Name);
                }
            }
            return ((PurchaseMediator)this.mediator).HotDrinkCreator(methods);
        }
        private void CreateColdDrinkCheckbox(object sender, EventArgs e)
        {
            string name = (sender as Button).Text;
            purchase["name"] = name;

            CheckBox cb = new CheckBox()
            {
                Text = "Ice cubes",
                Name = "WithIceCubes",
                Location = new Point(350, 300),
                Size = new Size(120, 40),
            };
            VendingMachine.TabPages[1].Controls.Add(cb);


            this.applyBtn.Click += (s, e2) =>
            {
                purchase["hasIce"] = cb.Checked.ToString();
                Apply(2);
            };
            VendingMachine.TabPages[1].Controls.Add(this.applyBtn);
           
        }

        public void Apply( int selectedIdx)
        {
            VendingMachine.TabPages[selectedIdx].Controls.Clear();
           ((PurchaseMediator)this.mediator).Notify(purchase, purchase["type"]);
            VendingMachine.SelectedIndex = 5;
            VendingMachine.SelectedIndex = selectedIdx;

            Label label = new Label()
            {
                Text = $"{purchase["name"]} price: {purchase["price"]}$",
                Location = new Point(300, 300),
                Size = new Size(150,120)
            };
            Button btn = new Button()
            {
                Text = "Pay",
                Location = new Point(450,300),
                Size = new Size(120, 40),
            };
            TextBox tb = new TextBox()
            {
                Location = new Point(450, 350),
                Size = new Size(120, 40),
                Text = "insert money"
            };
            tb.Click += (s, e2) => {
                tb.Clear();
            };
            btn.Click += (s, e2) => {
                double outAmount = 0,price;
                price = double.Parse(purchase["price"]);
               bool isDouble = double.TryParse(tb.Text,out outAmount);
                if (isDouble && outAmount >= price&& outAmount<=100)
                {
                    double excess = ((PurchaseMediator)this.mediator).Pay(price, outAmount);
                    this.backBtn.Visible = false;
                    VendingMachine.SelectedIndex = selectedIdx + 1;
                    VendingMachine.TabPages[selectedIdx+1].Controls.Add(label);
                    label.Text = "The purchase was completed successfully. \n";
                    label.Text +=excess>0? $"Excess: { excess}$":"";
                    MessageBox.Show(purchase["getProduct"]);
                }
              
                else MessageBox.Show("Please enter a correct amount");
                /////////////////////////////////////////////////////////////////
                ((PurchaseMediator)this.mediator).Notify(purchase, "pay");
                ((PurchaseMediator)this.mediator).Notify(purchase, "printReport");
            }; 
            VendingMachine.TabPages[selectedIdx].Controls.AddRange(new List<Control>() { label, btn, tb }.ToArray());
        }

        private void backBtn_Click(object sender, EventArgs e)
        {

            int index = VendingMachine.SelectedIndex;
            VendingMachine.SelectedIndex = index > 0 ? index - 1 : index;
        }
          
    }
}
