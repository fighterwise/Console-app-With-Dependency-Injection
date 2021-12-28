using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Dependency_Injection
{
    class ContainerBuilder
    {
        public IServiceProvider Build() 
        {
            var container = new ServiceCollection();
            container.AddSingleton<IOrderManager, OrderManager>();
            container.AddSingleton<IPaymentProcessor,PaymentProcessor >();
            container.AddSingleton<IShippingProcessor, ShippingProcessor>();
            container.AddSingleton<IProductStockRepository, ProductStockRepository>();

            return container.BuildServiceProvider();


        }



    }
}
