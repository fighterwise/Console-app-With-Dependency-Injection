using System;

namespace Dependency_Injection
{
    class Program
    {
        static void Main(string[] args)
        {
            var product = string.Empty;
            var ordermanager = new OrderManager();

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
