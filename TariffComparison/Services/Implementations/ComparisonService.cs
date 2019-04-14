using System;
using System.Collections.Generic;
using System.Linq;
using TariffComparison.Enums;
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
                    AnnualCostsCalculationStrategyType = StrategyTypes.Basic
                },
                new Product
                {
                    Name = "Packaged tariff",
                    AnnualCostsCalculationStrategyType = StrategyTypes.Packaged
                }
            };

            products
                .ForEach(product =>
                {
                    var strategy = GetStrategyByType(product.AnnualCostsCalculationStrategyType);
                    product.AnnualCostsPerYear = strategy.GetAnnualCosts(consumption);
                });

            return products.OrderBy(p => p.AnnualCostsPerYear).ToList();
        }

        private static IAnnualCostsCalculationStrategy GetStrategyByType(StrategyTypes type)
        {
            switch (type)
            {
                case StrategyTypes.Basic:
                    return new BasicAnnualCostsCalculationStrategy();

                case StrategyTypes.Packaged:
                    return new PackagedAnnualCostsCalculationStrategy();

                default:
                    throw new NotImplementedException();
            }
        }
    }
}
