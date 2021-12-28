using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependency_Injection
{
    public interface IShippingProcessor
    {
        public void MailProduct(Product product);

    }
    public class ShippingProcessor : IShippingProcessor
    {
        private readonly IProductStockRepository _productStockRepository;
        public ShippingProcessor(IProductStockRepository productStockRepository)
        {
            _productStockRepository = productStockRepository;
        }

        public void MailProduct(Product product) 
        {

            _productStockRepository.ReduceStock(product);

            Console.WriteLine("Call to Shipping API");
        }
    }
}
