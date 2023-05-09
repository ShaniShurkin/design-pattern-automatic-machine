using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingHouse.Report
{
    internal class DailyReport:IMediator
    {
        protected IMediator Mediator { get; set; }
        public List<Report> Reports { get; set; }
        public DailyReport()
        {
            Reports = new List<Report>();   
        }

        public void SetMediator(IMediator mediator)
        {
            this.Mediator = mediator;
        }
        //doubt...
        public void AddReport(DateTime date, string product, Action action, string details = "")
        {
            Report report = new Report(date, product, action, details);
            Reports.Add(report);

        }

        public void Notify(object sender)
        {
            Mediator.Notify(this);
        }
    }
}
