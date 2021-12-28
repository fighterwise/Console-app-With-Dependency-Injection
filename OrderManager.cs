using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependency_Injection


{

    public interface IOrderManager
    {
        public void Submit(Product product, string creditCardNumber, string expireDate);


    }
    public class OrderManager :IOrderManager
    {
        private readonly IProductStockRepository productStockRepository;
        private readonly IPaymentProcessor paymentProcessor;
        private readonly IShippingProcessor shippingProcessor;

        public OrderManager(IProductStockRepository productStockRepository,
            IPaymentProcessor paymentProcessor,
            IShippingProcessor shippingProcessor)
        {
            this.productStockRepository = productStockRepository;
            this.paymentProcessor = paymentProcessor;
            this.shippingProcessor = shippingProcessor;
        }



        public void Submit(Product product, string creditCardNumber, string expireDate)
        {


            
            
            
            //Check product

            if (!productStockRepository.IsInStock(product)) 
            {
                throw new Exception($"{product.ToString()} current not is stock");

            }

            //Payment
            
            paymentProcessor.ChargCreditCard(creditCardNumber, expireDate);



            // Ship the Product
            
            shippingProcessor.MailProduct(product);
        
        }

    }
}
