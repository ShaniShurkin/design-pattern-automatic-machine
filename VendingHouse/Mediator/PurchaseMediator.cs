
using System;
using System.Collections.Generic;
using VendingHouse.Report;

namespace VendingHouse
{
    internal class PurchaseMediator : IMediator
    {
        private Machine machine;

        private readonly Product product;

        private readonly HotColdDrink hotColdDrink;

        private readonly Payment payment;

        private readonly Supplier supplier;

        private readonly DailyReport dailyReport;

        private readonly IPrintingManager printingManager;
        
        public PurchaseMediator()
        {
            this.machine = new Machine();
            //this.product.SetMediator(this);
            //this.hotColdDrink.SetMediator(this);
            //this.payment.SetMediator(this);
            //this.supplier.SetMediator(this);
            //this.dailyReport.SetMediator(this);
            ////this.printingManager = new TxtPrintingManager();
            //this.printingManager.SetMediator(this);
            //this.payment = new Payment();
            //this.payment.SetMediator(this);
        }

        public List<Product> ProductOperation(string type)
        {
            return machine.Products[type.ToLower()+"s"];
        }
        public List<Product> Notify(string type) 
        {
          switch (type)
            {
                case "Can":
                case "Snack":
                case "Bottle":
                    return ProductOperation(type);
            }
            return new List<Product>();
        }


            public void Notify(object sender)
        {
            //switch (sender.ToString())
            //{
            //    case "Can":
            //    case "Snack":
            //    case "Bottle":
            //        ProductOperation(sender.ToString());
            //        break;
            //    case "Coffee":
            //    case "Ch":
            //    case "Bottle":
            //        ProductOperation(className);
            //        break;

            //}
        }
    }
}
