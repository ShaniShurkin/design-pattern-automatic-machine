using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingHouse
{
    public interface IMediator
    {
        void Notify(object sender);
    }
}
