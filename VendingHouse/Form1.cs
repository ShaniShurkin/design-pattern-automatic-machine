using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using VendingHouse.Edible.PersonalPreparationDrink;

namespace VendingHouse
{
    public partial class Form1 : Form
    {

        private readonly IMediator mediator;

        private Dictionary<string, string> purchase;
        public Form1(IMediator mediator)
        {
            InitializeComponent();
            this.mediator = mediator;
            this.purchase = new Dictionary<string, string>();
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int locationX = (VendingMachine.Width-600)/2;
            Button b1 = CreateButton("Product", "ProductBtn", locationX, 120);
            b1.Click += ProductBtn_Click;
            Button b2 = CreateButton("Hot Drink", "HotDrinkBtn", locationX +=200, 120);
            b2.Click += HotDrinkBtn_Click;
            Button b3 = CreateButton("Cold Drink", "ColdDrinkBtn", locationX += 200, 120);
            b3.Click += ColdDrinkBtn_Click;
            VendingMachine.TabPages[0].Controls.AddRange(new List<Button>() { b1, b2, b3 }.ToArray());
            Button b4 = CreateButton("Log In", "LogInBtn", x: (VendingMachine.Width-180)/2);
            //Entry for system employees
            TextBox tb = new TextBox()
            {
                Size = b4.Size,
                Location = new Point(b4.Location.X,(b4.Location.Y-40)),
                Text = "Password"
            };
            b4.Click += (s, e2) => {
                ManagerAction(tb.Text);
            }; 
            tb.Click+=(s, e2) => {
                tb.Clear();
            };
            VendingMachine.TabPages[6].Controls.Add(b4);
            VendingMachine.TabPages[6].Controls.Add(tb);

        }

        //settings
        private void ManagerAction(string password)
        {
            int place = 6;
            if(password != "1111") {
                MessageBox.Show("Wrong password!!!");
                return;
            }
            VendingMachine.TabPages[place].Controls.Clear();
            Button b1 = CreateButton("Show the all supplier messages", "supplierMessagesBtn", x: (VendingMachine.Width - 180)/2, y: 100);
            Button b2 = CreateButton("Print the daily report", "printReportBtn",x:(VendingMachine.Width - 180)/2,y:180);
            ComboBox cb = new ComboBox()
            {
                Text = "Printing Format",
                Items = { "Txt" },
                Location = new Point(b2.Location.X, b2.Location.Y+b2.Size.Height+20),
                Size = b2.Size,
            };
            b1.Click+=(s1, e1) =>
            {
                MessageBox.Show(purchase.ContainsKey("messagesToSupplier") ? purchase["messagesToSupplier"] : "There are no messages");
            };
            b2.Click+=(s2, e2) => ((PurchaseMediator)mediator).Notify(purchase, "printReport");
            VendingMachine.TabPages[place].Controls.AddRange(new List<Control>() { b1,b2,cb }.ToArray());

        }


        //products actions
        private void ProductBtn_Click(object sender, EventArgs e)
        {
            purchase["type"] = "product";
            List<string> products = ((PurchaseMediator)mediator).GetCategoriesList();
            CreateBtns(products, CreateProdutList);
            
        }
        private void CreateProdutList(object sender, EventArgs e)
        {
            VendingMachine.SelectedIndex = 2;
            int place = VendingMachine.SelectedIndex;
            VendingMachine.TabPages[place].Controls.Clear();
            
            string name = (sender as Button).Text;
            purchase["subType"] = name;
            List<Product> list = ((PurchaseMediator)mediator).ProductList(name);
            int locationX = (VendingMachine.Width-600)/2;
            int locationY = (VendingMachine.Height-450)/2 + 100;
            foreach (Product product in list)
            {
                Button btn = CreateButton("", product.Name + "Btn", locationX, locationY, 130, 130);
                locationX += 150;
                if(VendingMachine.Width -(locationX + btn.Size.Width) < 160)
                {
                    locationX = (VendingMachine.Width-600)/2;
                    locationY += 150;
                }
                Image img = product.Image;
                
                img = resizeImage(img, new Size(150, 130));
                btn.Image = img;
                Label lbl = CreateLabel($"Price: {product.Price}$", x: btn.Location.X, y: btn.Location.Y + btn.Height + 1, width: btn.Size.Width, height: 40);

                btn.Click += (s, e2) =>
                {
                    purchase["name"] = product.Name;
                    GetMoreOptions();
                };
                VendingMachine.TabPages[place].Controls.Add(lbl);
                VendingMachine.TabPages[place].Controls.Add(btn);
             }

        }
        private void GetMoreOptions()
        {
            VendingMachine.SelectedIndex = 3;
            int place = VendingMachine.SelectedIndex;
            VendingMachine.TabPages[place].Controls.Clear();
            int locationY = 100;
            CheckBox c1 = CreateCheckBox("Add bag", "AddBagBtn", locationY += 80);

            CheckBox c2 = CreateCheckBox("Add gift wrapping", "AddGiftWrappingBtn", locationY += 80);

            //Image imgBag = c1.Image;
            //imgBag = resizeImage(imgBag, new Size(150, 130));
            //c1.Image = imgBag;
            //Image img = c2.Image;
            //img = resizeImage(img, new Size(150, 130));
            //c2.Image = img;

            Button applyBtn = CreateButton("Apply", "applyBtn",x: (VendingMachine.Width - 180)/2, y: VendingMachine.Height - 100);
            applyBtn.Click += (s, e2) =>
            {
                purchase["withBag"] = c1.Checked.ToString();
                purchase["withGiftWrapping"] = c2.Checked.ToString();
                Apply(4);

            };

            VendingMachine.TabPages[place].Controls.AddRange(new List<Control>() { c1, c2, applyBtn }.ToArray());
        }

        //hot drink actions
        private void HotDrinkBtn_Click(object sender, EventArgs e)
        {
            purchase["type"] = "hot drink";
            List<HotDrink> hotDrinks = ((PurchaseMediator)mediator).GetHotDrinksList();
            CreateBtns(hotDrinks.Select(_ => _.Name).ToList(), CreateHotDrinkActionsList, hotDrinks.Select(_ => _.BasicPrice).ToList());
        }
        private void CreateHotDrinkActionsList(object sender, EventArgs e)
        {
            VendingMachine.SelectedIndex = 2;
            int place = VendingMachine.SelectedIndex;
            VendingMachine.TabPages[place].Controls.Clear();
            int locationY = 100;
            string name = (sender as Button).Text;
            purchase["name"] = name;
            Label label = CreateLabel("Select the desired add-ons\r\nOne extra is free and the rest is 1$", y: 10, width: 300, x: (VendingMachine.Width-300)/2);
            VendingMachine.TabPages[place].Controls.Add(label);
            List<string> list = ((PurchaseMediator)mediator).HotDrinkOptionalMethods(name);
            foreach (string method in list)
            {
                CheckBox cb = CreateCheckBox(method, method.Replace(" ", ""), locationY);
                VendingMachine.TabPages[place].Controls.Add(cb);
                locationY += 60;

            }
            Button applyBtn = CreateButton("Apply", "applyBtn", x: (VendingMachine.Width - 180)/2, y: VendingMachine.Height - 100);
            applyBtn.Click += (s, e2) =>
            {
                CreateHotDrink();
                Apply(3);

            };
                
            VendingMachine.TabPages[place].Controls.Add(applyBtn);

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

        //cold drink actions
        private void ColdDrinkBtn_Click(object sender, EventArgs e)
        {
            purchase["type"] = "cold drink";
            List<ColdDrink> coldDrinks = ((PurchaseMediator)mediator).GetColdDrinksList();
            CreateBtns(coldDrinks.Select(_ => _.Name).ToList(), CreateColdDrinkCheckbox, coldDrinks.Select(_ => _.BasicPrice).ToList());

        }
        private void CreateColdDrinkCheckbox(object sender, EventArgs e)
        {
            string name = (sender as Button).Text;
            purchase["name"] = name;

            CheckBox cb = CreateCheckBox("Ice cubes", "WithIceCubes");

            VendingMachine.TabPages[1].Controls.Add(cb);

            Button applyBtn = CreateButton("Apply", "applyBtn", x: (VendingMachine.Width - 180)/2, y:VendingMachine.Height - 100);
            applyBtn.Click += (s, e2) =>
            {
                purchase["hasIce"] = cb.Checked.ToString();
                Apply(2);
            };
            VendingMachine.TabPages[1].Controls.Add(applyBtn);

        }



        //controls creating
        private Button CreateButton(string text, string name, int x = 100, int y = 100, int width = 180, int height = 60)
        {
            //int width = VendingMachine.Size.Width;

            Button btn = new Button()
            {
                Text = text,
                Name = name,
                Size = new Size(width, height),
                Location = new Point(x, y)
            };
            //btn.Location = new Point((width - btn.Size.Width) / 2, y);
            return btn;
        }
        private CheckBox CreateCheckBox(string text, string name, int y = 300)
        {
            int width = VendingMachine.Size.Width;
            CheckBox cb = new CheckBox()
            {
                Text = text,
                Name = name,
                Size = new Size(180, 50)
            };
            cb.Location = new Point((width - cb.Size.Width) / 2, y);
            //cb.Appearance = Appearance.Button;
            return cb;

        }
        private Label CreateLabel(string text, int x = 100, int y = 100, int width = 100, int height = 100)
        {

            Label lbl = new Label()
            {
                Text = text,
                AutoSize = false,
                Size = new Size(width, height),
                Location = new Point(x, y),
                TextAlign = ContentAlignment.MiddleCenter,
            };
            lbl.Font = new Font(lbl.Font.FontFamily, 12f, lbl.Font.Style);
            return lbl;
        }


        
        private void CreateBtns(List<string> names, EventHandler createList, List<double> prices = null, List<Image> imgs = null)
        {
            Button btn;
            VendingMachine.SelectedIndex = 1;
            int place = VendingMachine.SelectedIndex;
            VendingMachine.TabPages[place].Controls.Clear();
            int locationX = (VendingMachine.Width-(names.Count)*200)/2;
            for (int i = 0; i < names.Count; i++)
            {
                //check name
                btn = CreateButton(names[i], "btn" + names[i], locationX, 120);
                btn.Click += createList;
                VendingMachine.TabPages[place].Controls.Add(btn);

                if (prices != null)
                {
                    Label lbl = CreateLabel($"Price: {prices[i]}$", x: btn.Location.X + 10, y: btn.Location.Y + btn.Height + 1, width: btn.Size.Width, height: 40);
                    VendingMachine.TabPages[place].Controls.Add(lbl);
                }
                locationX += btn.Size.Width + 20;
            }
        }
        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }
        public void Apply(int selectedIdx)
        {
            VendingMachine.TabPages[selectedIdx].Controls.Clear();
            ((PurchaseMediator)this.mediator).Notify(purchase, purchase["type"]);
            VendingMachine.SelectedIndex = 5;
            VendingMachine.SelectedIndex = selectedIdx;
            string text = $"{purchase["name"]} price: {purchase["price"]}$";
            Label label = CreateLabel(text, (VendingMachine.Size.Width-200)/2, 120, 200, 100);
            
            Button btn = CreateButton("Pay", "PayBtn", y:350, x:(VendingMachine.Width - 180)/2);

            TextBox tb = new TextBox()
            {
                Location = new Point(btn.Location.X,btn.Location.Y-80),
                Size = btn.Size,
                Text = "Enter an amount of money",
                
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
                if (isDouble && outAmount >= price && outAmount <= 100)
                {
                    purchase["excess"] = outAmount.ToString();
                    ((PurchaseMediator)this.mediator).Notify(purchase, "pay");
                    double excess = double.Parse(purchase["excess"]);
                    this.backBtn.Visible = false;
                    VendingMachine.SelectedIndex = selectedIdx + 1;
                    VendingMachine.TabPages[selectedIdx + 1].Controls.Add(label);
                    label.Text = "The purchase was completed successfully. \n";
                    label.Text += excess > 0 ? $"Excess: {excess}$" : "";
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
            if(index ==  0)
            {
               
            }
        }
        
        
    }
}
