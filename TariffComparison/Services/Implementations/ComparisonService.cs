using System.Collections.Generic;
using System.Linq;
using TariffComparison.Models;
using TariffComparison.Services.Abstractions;

namespace TariffComparison.Services.Implementations
{
    public class ComparisonService : IComparisonService
    {
        public List<Product> GetProducts(decimal consumption)
        {
            var products = new List<Product>
            {
                new Product
                {
                    Name = "Basic electricity tariff",
                    AnnualCostsCalculationStrategy = new BasicAnnualCostsCalculationStrategy()
                },
                new Product
                {
                    Name = "Packaged tariff",
                    AnnualCostsCalculationStrategy = new PackagedAnnualCostsCalculationStrategy()
                }
            };

            products
                .ForEach(p => p.AnnualCostsPerYear = p.AnnualCostsCalculationStrategy.GetAnnualCosts(consumption));

            return products.OrderBy(p => p.AnnualCostsPerYear).ToList();
        }
    }
}
