using System;
using Microsoft.Extensions.DependencyInjection;

namespace DiamondKata
{
    public static class Program
    {
        private static ServiceProvider _serviceProvider;

        public static void Main(string[] args)
        {
            var serviceCollection = Startup.ConfigureServices();
            _serviceProvider = serviceCollection.BuildServiceProvider();

            Console.WriteLine("Please enter a letter between A and Z ");

            char userLetter = Console.ReadKey().KeyChar;

            Console.WriteLine(string.Empty);

            _serviceProvider.GetRequiredService<IConsoleApplication>().Run(userLetter);

            Console.Read();
        }
    }
}
