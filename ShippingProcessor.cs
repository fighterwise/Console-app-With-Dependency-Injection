using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependency_Injection
{
    public class ShippingProcessor
    {
        public void MailProduct(Product product) 
        {
            var productstockrepository = new ProductStockRepository();
            productstockrepository.ReduceStock(product);

            Console.WriteLine("Call to Shipping API");
        }
    }
}
