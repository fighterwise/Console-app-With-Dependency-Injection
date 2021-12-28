using System;
using Dependency_Injection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Dependency_Injection
{
    class Program
    {
        public static readonly IServiceProvider Container = new ContainerBuilder().Build();

        static void Main(string[] args)
        {
            var product = string.Empty;
            var productsStackRepository = new ProductStockRepository();
            var ordermanager = Container.GetService<IOrderManager>();


            while (product != "exit")
            {
                Console.WriteLine(@"Enter a prodduct:  
                    Keyboard = 0, 
                    Mouse = 1, 
                    mic = 2,
                    Speaker = 3");
                product = Console.ReadLine();



                try
                {
                    if (Enum.TryParse(product, out Product productEnum))
                    {
                        Console.WriteLine("Please enter a valid payment method:XXXXXXXXXXXXXXXX;MMYY");
                        var peymentMethod = Console.ReadLine();


                        if (string.IsNullOrEmpty(peymentMethod) || peymentMethod.Split(";").Length != 2)
                            throw new Exception("Invalid Payment Mathod");

                        ordermanager.Submit(productEnum, peymentMethod.Split(";")[0], peymentMethod.Split(";")[1]);
                        Console.WriteLine($"{productEnum.ToString()} has beewn shipped");

                    }

                    else
                    {
                        Console.WriteLine("Invalid Product");
                    }
                        Console.WriteLine(Environment.NewLine);

                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.WriteLine(Environment.NewLine);





            }  
            
        }
    }
}
