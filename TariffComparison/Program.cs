using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using TariffComparison.Models;
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

            try
            {
                var consumption = GetConsumption();
                var comparisonService = serviceProvider.GetService<IComparisonService>();
                var products = comparisonService.GetProducts(consumption);
                PrintProducts(products);
            }
            catch (Exception)
            {
                Console.WriteLine("Unable to calculate annual costs.");
            }

            Console.ReadLine();
        }

        private static decimal GetConsumption()
        {
            while (true)
            {
                Console.WriteLine("Please input consumption (decimal): ");

                try
                {
                    var consumption = Convert.ToDecimal(Console.ReadLine());
                    Console.WriteLine();
                    return consumption;
                }
                catch (Exception)
                {
                    Console.WriteLine("Value is invalid, please input number only.");
                }
            }
        }

        private static void PrintProducts(List<Product> products)
        {
            products
                .Select(product => new
                {
                    product.Name,
                    product.AnnualCostsPerYear
                })
                .ToList()
                .ForEach(product =>
                {
                    Console.WriteLine($"Product name: { product.Name }");
                    Console.WriteLine($"Annual costs per year: {product.AnnualCostsPerYear:N2} EUR");
                    Console.WriteLine(new string('-', 40));
                });
        }
    }
}
