using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace VendingHouse.Report
{
    internal class DailyReport:IMediator
    {
        protected IMediator Mediator { get; set; }
        public List<Report> Reports { get; set; }
        private readonly Timer timer;
        public DailyReport()
        {
            Reports = new List<Report>();
            timer = new Timer();
            timer.Interval = (60 * 60 * 1000);
            timer.Elapsed += ResetReports;
            timer.Start();
        }

        public void SetMediator(IMediator mediator)
        {
            this.Mediator = mediator;
        }
        public void AddReport(DateTime date, string product, Actions action, string details = "")
        {
            Report report = new Report(date, product, action, details);
            Reports.Add(report);

        }

        public void ResetReports(object sender, ElapsedEventArgs e)
        {
            if (DateTime.Now.Hour == 0 )
            {
                this.Print();
                this.Reports.Clear();
                
            }
        }

        public void Print()
        {
            TxtPrintingManager t = new TxtPrintingManager();
            t.Print(Reports);
        }
        public void Notify(object sender)
        {
            Mediator.Notify(this);
        }
    }
}
