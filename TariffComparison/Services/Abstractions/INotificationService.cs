using System;
using TariffComparison.Models;

namespace TariffComparison.Services.Abstractions
{
    internal interface INotificationService
    {
        void PrintException(string message, Exception exception);

        void PrintMessage(string message);

        void PrintProduct(Product product);
    }
}
