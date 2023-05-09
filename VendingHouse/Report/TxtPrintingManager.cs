using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingHouse.Report
{
    internal class TxtPrintingManager : IPrintingManager
    {
        public IMediator Mediator { get; set; }

        public void SetMediator(IMediator mediator)
        {
            this.Mediator = mediator;
        }
        public void Notify(object sender)
        {
            Mediator.Notify(this);
        }

        public void Print(List<Report> reports)
        {
           //////////printing to text...............................................
        }
    }
}
