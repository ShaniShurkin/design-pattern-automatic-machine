using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingHouse
{
    internal class Payment:IMediator
    {
        protected IMediator mediator;

        public void SetMediator(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public void Notify(object sender)
        {
            mediator.Notify(this);
        }
        

        public double Pay(double price, double amountReceived)
        {
            /////
            return price * amountReceived;
        }
        
    }
}
