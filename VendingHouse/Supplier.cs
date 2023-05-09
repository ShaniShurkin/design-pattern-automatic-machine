using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingHouse
{
    internal class Supplier:IMediator
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        protected IMediator Mediator { get; set; }
        
        public Supplier(string name, string phoneNumber)
        {
            Name=name;
            PhoneNumber=phoneNumber;
        }

        public void SetMediator(IMediator mediator)
        { 
            this.Mediator = mediator;
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

        public void Notify(object sender)
        {
            Mediator.Notify(this);
        }
    }
}
