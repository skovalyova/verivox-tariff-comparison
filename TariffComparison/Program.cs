using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using TariffComparison.Models;
using TariffComparison.Services.Abstractions;
using TariffComparison.Services.Implementations;

namespace TariffComparison
{
    class Program
    {
        private static IComparisonService _comparisonService;
        private static INotificationService _notificationService;

        static void Main(string[] args)
        {
            InitServices();

            try
            {
                var consumption = GetConsumptionFromUserInput();
                var products = _comparisonService.GetProducts(consumption);

                PrintProducts(products);
            }
            catch (Exception exception)
            {
                _notificationService.PrintException("Unable to calculate annual costs.", exception);
            }

            _notificationService.PrintMessage("\nPress any key to exit.");
            Console.ReadKey();
        }

        private static void InitServices()
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IComparisonService, ComparisonService>()
                .AddSingleton<INotificationService, NotificationService>()
                .BuildServiceProvider();

            _comparisonService = serviceProvider.GetService<IComparisonService>();
            _notificationService = serviceProvider.GetService<INotificationService>();
        }

        private static decimal GetConsumptionFromUserInput()
        {
            while (true)
            {
                _notificationService.PrintMessage("Please input consumption, kWh/year: ");

                try
                {
                    var consumption = Convert.ToDecimal(Console.ReadLine());
                    return consumption;
                }
                catch (Exception exception)
                {
                    _notificationService.PrintException("Value is invalid, please input not negative number.", exception);
                }
            }
        }

        private static void PrintProducts(List<Product> products) =>
            products.ForEach(_notificationService.PrintProduct);
    }
}
