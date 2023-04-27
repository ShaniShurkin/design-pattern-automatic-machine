using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingHouse.Report
{
    internal class Report
    {
        public DateTime DateTime { get; set; }
        public string Product { get; set; }
        public Action Action { get; set; }
        public string Details { get; set; }
        public Report(DateTime dateTime, string product, Action action, string details = "")
        {
            DateTime=dateTime;
            Product=product;
            Action=action;
            Details=details;    
        }
    }
}
