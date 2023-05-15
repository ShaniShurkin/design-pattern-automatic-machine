using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingHouse.Report
{
    internal class TextDailyReport :DailyReport
    {
        public override void Print()
        {
            StreamWriter writer = new StreamWriter("..//..//..//report.txt");
            string date = this.Reports.First().DateTime.Date.ToString("yyyy-MM-dd");
            writer.WriteLine(date);
            this.Reports.ForEach(report => writer.WriteLine($"{report.DateTime.Hour}\n{report.Product} was {report.Action.ToString().ToLower()}, {report.Details}"));

            writer.Close();
        }
    }
}
