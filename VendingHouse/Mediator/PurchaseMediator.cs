
using System;
using VendingHouse.Report;

namespace VendingHouse
{
    internal class PurchaseMediator : IMediator
    {
        private readonly Machine machine;

        private readonly Product product;

        private readonly HotColdDrink hotColdDrink;

        private readonly Payment payment;

        private readonly Supplier supplier;

        private readonly DailyReport dailyReport;

        private readonly IPrintingManager printingManager;
        public PurchaseMediator()
        {
            this.machine = new Machine();
            this.product.SetMediator(this);
            this.hotColdDrink.SetMediator(this);
            this.payment.SetMediator(this);
            this.supplier.SetMediator(this);
            this.dailyReport.SetMediator(this);
            //this.printingManager = new TxtPrintingManager();
            this.printingManager.SetMediator(this);
            this.payment = new Payment();
            this.payment.SetMediator(this);
        }

        public void ProductOperation()
        {
           
        }
        

        public void Notify(object sender)
        {
            Type type = sender.GetType();
            //switch (type.Name)
            //{
            //    case "Product":

            //    case "Bag":

               
                    

            //    default:
            //        this.payment.Pay(0, 0);
                        
            //}
        }
    }
}
