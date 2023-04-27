using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingHouse.Report
{
    internal interface IPrintingManager
    {
        //maybe boolean
        void Print(List<Report> reports);
            
            
    }
}
