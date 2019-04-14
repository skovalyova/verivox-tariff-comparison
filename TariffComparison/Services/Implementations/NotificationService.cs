using System;
using TariffComparison.Models;
using TariffComparison.Services.Abstractions;

namespace TariffComparison.Services.Implementations
{
    internal class NotificationService : INotificationService
    {
        public void PrintException(string message, Exception exception)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);

            #if DEBUG

            if (exception != null)
            {
                Console.WriteLine($"Exception details: { exception }\n");
            }

            #endif
        }

        public void PrintMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(message);
        }

        public void PrintProduct(Product product)
        {
            const int padding = 15;

            PrintMessage(string.Empty);
            PrintMessage($"{ "Product name:".PadRight(padding) } { product.Name }");
            PrintMessage($"{ "Annual costs:".PadRight(padding) } {product.AnnualCostsPerYear:N2} EUR/year");
            PrintMessage(new string('-', 40));
        }
    }
}
