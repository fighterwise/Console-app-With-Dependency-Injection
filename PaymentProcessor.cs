using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependency_Injection
{
    public class PaymentProcessor
    {
        public void ChargCreditCard(string creditcardNumber, string experyDate)
        {
            if (string.IsNullOrEmpty(creditcardNumber))
            {
                throw new ArgumentException("Invalid Credit Card") ;
            }
            if (string.IsNullOrEmpty(experyDate))
            {
                throw new ArgumentException("Invalid Expiry Date");
            }
            Console.WriteLine("Call to Credit Ccar API");
        
        }

    }
}
