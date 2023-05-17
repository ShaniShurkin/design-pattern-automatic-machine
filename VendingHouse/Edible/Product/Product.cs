using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingHouse
{
    internal abstract class Product : Iedible
    {
        public string Name { get; set; }
        public int Amount { get; set; }
        public static int MinAmount { get; set; }
        public Supplier Supplier { get; set; }
        public double Price { get; set; }
        public Image Image { get; set; }
        public string ImagePath { get; set; }
        protected Product _Product { get; set; }
 

        public Product(string name, int amount, double price, string path)
        {
            this.Name = name;
            this.Amount = amount;
            this.Price = price;
            this.ImagePath = path;
            if (Path.IsPathRooted(path) && Directory.Exists(Path.GetPathRoot(path))){
                this.Image = Image.FromFile(path);
            }
            ////else....
            this.Image = Image.FromFile(path);
            this.Supplier = this.Supplier == null? new Supplier("product supplier", "0504153321"):this.Supplier;    
        }

        public Product(Product product):this(product.Name, product.Amount, product.Price, product.ImagePath)
        {
            _Product = product;
        }

        public abstract string GetProduct();

    }
}
