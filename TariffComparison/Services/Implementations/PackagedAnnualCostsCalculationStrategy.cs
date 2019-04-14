using System;
using TariffComparison.Services.Abstractions;

namespace TariffComparison.Services.Implementations
{
    public class PackagedAnnualCostsCalculationStrategy : IAnnualCostsCalculationStrategy
    {
        public const decimal Threshold = 4000m;
        public const decimal BaseCosts = 800m;
        public const decimal AdditionalCostsPerKwh = 0.30m;

        /// <summary>
        /// Calculation model: 800 € for up to 4000 kWh/year and above 4000 kWh/year additionally 30 cent/kWh.
        /// </summary>
        /// <param name="consumption">kWh/year</param>
        /// <returns></returns>
        public decimal GetAnnualCosts(decimal consumption)
        {
            if (consumption < 0)
            {
                throw new ApplicationException($"{ nameof(consumption) } can not be less than 0.");
            }

            return consumption <= Threshold
                ? BaseCosts
                : BaseCosts + (consumption - Threshold) * AdditionalCostsPerKwh;
        }
    }
}
