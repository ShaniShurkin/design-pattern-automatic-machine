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
            this.applyBtn = CreateButton("Apply", "applyBtn", VendingMachine.Height-100);
           

            //mediator = DependencyManager.Resolve<IMediator>();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            int locationY = 50;
            Button b1 = CreateButton("Product", "ProductBtn", locationY += 80);
            b1.Click += ProductBtn_Click;
            Button b2 = CreateButton("Hot Drink", "HotDrinkBtn", locationY += 80);
            b2.Click += HotDrinkBtn_Click;
            Button b3 = CreateButton("Cold Drink", "ColdDrinkBtn", locationY += 80);
            b3.Click += ColdDrinkBtn_Click;
            VendingMachine.TabPages[0].Controls.AddRange(new List<Button>() { b1, b2, b3 }.ToArray());

        }
        private void ProductBtn_Click(object sender, EventArgs e)
        {
            purchase["type"] = "product";
            List<string> products = ((PurchaseMediator)mediator).GetCategoriesList("products");
            CreateBtns(products, CreateProdutList);
        }

        private void HotDrinkBtn_Click(object sender, EventArgs e)
        {
            purchase["type"] = "hot drink";
            List<string> hotDrinks = ((PurchaseMediator)mediator).GetCategoriesList("hotDrinks");
            CreateBtns(hotDrinks, CreateHotDrinkOperationList);
        }

        private void ColdDrinkBtn_Click(object sender, EventArgs e)
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
                //check name
                btn = CreateButton(name, "btn" + name, locationY);
                btn.Click += createList;
                VendingMachine.TabPages[place].Controls.Add(btn);
                locationY += 80;

            }
        }

        private void CreateProdutList(object sender, EventArgs e)
        {
            VendingMachine.SelectedIndex = 2;
            int place = VendingMachine.SelectedIndex;
            VendingMachine.TabPages[place].Controls.Clear();
            int locationY = 40;
            string name = (sender as Button).Text;
            purchase["subType"] = name;
            List<Product> list = ((PurchaseMediator)mediator).ProductList(name);
            foreach (Product product in list)
            {
                Button btn = CreateButton("", product.Name + "Btn", locationY);
                btn.Size = new Size(130, 130);
                locationY += 50;
                Image img = product.Image;
                img = resizeImage(img, new Size(150, 130));
                btn.Image = img;
            
                btn.Click +=(s, e2) =>
                {
                    purchase["name"] = product.Name;
                    GetMoreOptions();
                };
                VendingMachine.TabPages[place].Controls.Add(btn);
                locationY += 80;
            }

        }
        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }

        
        private void GetMoreOptions()
        {
            VendingMachine.SelectedIndex = 3;
            int place = VendingMachine.SelectedIndex;
            VendingMachine.TabPages[place].Controls.Clear();
            int locationY = 100;
            CheckBox c1 = CreateCheckBox("Add bag", "AddBagBtn", locationY+=80);

            CheckBox c2 = CreateCheckBox("Add gift wrapping", "AddGiftWrappingBtn", locationY+=80);

            //Image imgBag = c1.Image;
            //imgBag = resizeImage(imgBag, new Size(150, 130));
            //c1.Image = imgBag;
            //Image img = c2.Image;
            //img = resizeImage(img, new Size(150, 130));
            //c2.Image = img;


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
                CheckBox cb = CreateCheckBox(method, method.Replace(" ", ""), locationY);
                VendingMachine.TabPages[place].Controls.Add(cb);
                locationY += 60;

            }

            this.applyBtn.Click += (s, e2) =>
            {
                CreateHotDrink();
                Apply(3);

            };
            VendingMachine.TabPages[place].Controls.Add(this.applyBtn);

        }

        private void CreateHotDrink()
        {
            List<string> methods = new List<string>();

            foreach (CheckBox checkBox in VendingMachine.TabPages[2].Controls.OfType<CheckBox>())
            {
                if (checkBox.Checked)
                {
                    methods.Add(checkBox.Name);
                }
            }
            purchase["methods"] = string.Join(",", methods);
            ((PurchaseMediator)this.mediator).Notify(purchase, "createHotDrink");
        }
        private void CreateColdDrinkCheckbox(object sender, EventArgs e)
        {
            string name = (sender as Button).Text;
            purchase["name"] = name;

            CheckBox cb = CreateCheckBox("Ice cubes", "WithIceCubes");
           
            VendingMachine.TabPages[1].Controls.Add(cb);


            this.applyBtn.Click += (s, e2) =>
            {
                purchase["hasIce"] = cb.Checked.ToString();
                Apply(2);
            };
            VendingMachine.TabPages[1].Controls.Add(this.applyBtn);

        }

        public void Apply(int selectedIdx)
        {
            VendingMachine.TabPages[selectedIdx].Controls.Clear();
            ((PurchaseMediator)this.mediator).Notify(purchase, purchase["type"]);
            VendingMachine.SelectedIndex = 5;
            VendingMachine.SelectedIndex = selectedIdx;

            Label label = new Label()
            {
                Text = $"{purchase["name"]} price: {purchase["price"]}$",
                Location = new Point(300, 300),
                Size = new Size(150, 120)
            };
            Button btn = CreateButton("Pay", "PayBtn", 250);

            TextBox tb = new TextBox()
            {
                Location = new Point(450, 350),
                Size = new Size(120, 40),
                Text = "insert money"
            };
            tb.Click += (s, e2) =>
            {
                tb.Clear();
            };
            btn.Click += (s, e2) =>
            {
                double outAmount = 0, price;
                price = double.Parse(purchase["price"]);
                bool isDouble = double.TryParse(tb.Text, out outAmount);
                if (isDouble && outAmount >= price&& outAmount<=100)
                {
                    purchase["excess"] = outAmount.ToString();
                    ((PurchaseMediator)this.mediator).Notify(purchase, "pay");
                    double excess = double.Parse(purchase["excess"]);
                    this.backBtn.Visible = false;
                    VendingMachine.SelectedIndex = selectedIdx + 1;
                    VendingMachine.TabPages[selectedIdx+1].Controls.Add(label);
                    label.Text = "The purchase was completed successfully. \n";
                    label.Text +=excess>0 ? $"Excess: {excess}$" : "";
                    MessageBox.Show(purchase["getProduct"]);
                }

                else MessageBox.Show("Please enter a correct amount");
                

                //((PurchaseMediator)this.mediator).Notify(purchase, "printReport");
            };
            VendingMachine.TabPages[selectedIdx].Controls.AddRange(new List<Control>() { label, btn, tb }.ToArray());
        }

        private void backBtn_Click(object sender, EventArgs e)
        {

            int index = VendingMachine.SelectedIndex;
            VendingMachine.SelectedIndex = index > 0 ? index - 1 : index;
        }
        private Button CreateButton(string text, string name, int y = 100)
        {
            int width = VendingMachine.Size.Width;

            Button btn = new Button()
            {
                Text = text,
                Name = name,
                Size = new Size(180, 60)
               
            };
            btn.Location = new Point((width - btn.Size.Width)/2, y);
            return btn;
        }
        private CheckBox CreateCheckBox(string text, string name, int y = 300)
        {
            int width = VendingMachine.Size.Width;
            CheckBox cb = new CheckBox()
            {
                Text = text,
                Name = name,
                Size = new Size(180, 60)
            };
            cb.Location = new Point((width - cb.Size.Width)/2, y);
            //cb.Appearance = Appearance.Button;
            return cb;

        }
    }
}
