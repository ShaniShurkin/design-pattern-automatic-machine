using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingHouse.Report
{
    internal class DailyReport
    {
        public List<Report> Reports/*to change*/ { get; set; }
        public DailyReport()
        {
            Reports = new List<Report>();   
        }
        //doubt...
        public void AddReport(DateTime date, string product, Action action, string details = "")
        {
            Report report = new Report(date, product, action, details);
            Reports.Add(report);

        }



    }
}
