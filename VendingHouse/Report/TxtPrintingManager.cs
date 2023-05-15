using System;
using System.Collections.Generic;
using System.IO;
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
            StreamWriter writer = new StreamWriter("..//..//..//report.txt");
            string date = reports.First().DateTime.Date.ToString("yyyy-MM-dd");
            writer.WriteLine(date);
            reports.ForEach(report => writer.WriteLine($"{report.DateTime.Hour}\n{report.Product} was {report.Action.ToString().ToLower()}, {report.Details}"));
           
            writer.Close();
        }
    }
}
