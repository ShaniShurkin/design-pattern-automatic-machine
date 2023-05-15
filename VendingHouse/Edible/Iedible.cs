using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingHouse
{
    internal interface Iedible
    {
        string Name { get; set; }
        int Amount { get; set; }       
    }
}
