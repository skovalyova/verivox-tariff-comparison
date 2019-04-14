using TariffComparison.Services.Abstractions;

namespace TariffComparison.Models
{
    public class Product
    {
        public string Name { get; set; }

        public decimal AnnualCostsPerYear { get; set; }

        // TODO: get it from some key string.
        public IAnnualCostsCalculationStrategy AnnualCostsCalculationStrategy { get; set; }
    }
}
