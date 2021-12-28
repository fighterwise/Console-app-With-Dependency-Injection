using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependency_Injection
{
    public class OrderManager
    {
        public void Submit(Product product, string creditCardNumber, string expireDate)
        {
            //Check product

            var productStockRepository = new ProductStockRepository();
            if (!productStockRepository.IsInStock(product)) 
            {
                throw new Exception($"{product.ToString()} current not is stock");

            }

            //Payment
            var paymentProcessor = new PaymentProcessor();
            paymentProcessor.ChargCreditCard(creditCardNumber, expireDate);



            // Ship the Product
            var shippingprocessor = new ShippingProcessor();
            shippingprocessor.MailProduct(product);
        
        }

    }
}
