using TariffComparison.Enums;

namespace TariffComparison.Models
{
    public class Product
    {
        public string Name { get; set; }

        public decimal AnnualCostsPerYear { get; set; }

        public StrategyTypes AnnualCostsCalculationStrategyType { get; set; }
    }
}
