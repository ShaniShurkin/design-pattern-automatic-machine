using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace VendingHouse.Report
{
    internal abstract class DailyReport
    {
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

        public abstract void Print();
    }
}
