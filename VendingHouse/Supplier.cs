using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingHouse
{
    internal class Supplier
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        
        public Supplier(string name, string phoneNumber)
        {
            Name=name;
            PhoneNumber=phoneNumber;
        }


        /// <summary>
        /// Messages to the provider To provide additional quantity of a product
        /// </summary>
        /// <param name="product"></param>
        /// <returns>
        /// The message
        /// </returns>
        public string Message(string product)
        {
            return $"Please provide us with additional quantity of {product}";
        }
    }
}
