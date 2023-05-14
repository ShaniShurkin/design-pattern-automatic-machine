using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingHouse
{
    internal abstract class HotColdDrink:IMediator
    {
        public string Name { get; set; }
        public double BasicPrice { get; set; }
        protected IMediator Mediator { get; set; }

        public HotColdDrink(string name, double basicPrice)
        {
            Name=name;
            BasicPrice=basicPrice;
        }
        public void SetMediator(IMediator mediator)
        {
            this.Mediator = mediator;
        }
        public abstract string Make(List<string> list);

        public void Notify(object sender)
        {
            Mediator.Notify(this);
        }
    }
}
