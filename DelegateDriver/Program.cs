using System;
using Microsoft.Extensions.DependencyInjection;

namespace DelegateDriver
{
    internal class Program
    {
        private static void Main()
        {
            var serviceProvider = ConfigureServiceProvider();

            var myAdder = serviceProvider.GetService<MyAdder>();

            Console.WriteLine(myAdder.AddViaDelegate(1, 1));
            Console.WriteLine(myAdder.AddViaInterface(1, 1));
        }

        private static ServiceProvider ConfigureServiceProvider()
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<AdderDelegate>((l, r) => l + r)
                .AddSingleton<IAdder, Adder>()
                .AddSingleton<MyAdder>()
                .BuildServiceProvider();
            return serviceProvider;
        }
    }
}
