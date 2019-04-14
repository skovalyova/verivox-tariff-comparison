using System;
using Microsoft.Extensions.DependencyInjection;
using TariffComparison.Services.Abstractions;
using TariffComparison.Services.Implementations;

namespace TariffComparison
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IComparisonService, ComparisonService>()
                .BuildServiceProvider();

            var comparisonService = serviceProvider.GetService<IComparisonService>();
            var products = comparisonService.GetProducts(4000);

            Console.ReadLine();
        }
    }
}
