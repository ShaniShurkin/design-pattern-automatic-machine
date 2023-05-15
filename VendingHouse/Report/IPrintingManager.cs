using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingHouse.Report
{
    internal interface IPrintingManager:IMediator
    {
        IMediator Mediator { get; set; }
        void SetMediator(IMediator mediator);
        //maybe boolean
         void Print(List<Report> reports);
        void Notify(object sender);



    }
}
