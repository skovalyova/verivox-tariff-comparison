using System.Collections.Generic;
using TariffComparison.Models;

namespace TariffComparison.Services.Abstractions
{
    public interface IComparisonService
    {
        List<Product> GetProducts(decimal consumption);
    }
}
