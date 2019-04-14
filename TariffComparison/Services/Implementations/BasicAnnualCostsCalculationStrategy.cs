using System;
using TariffComparison.Services.Abstractions;

namespace TariffComparison.Services.Implementations
{
    public class BasicAnnualCostsCalculationStrategy : IAnnualCostsCalculationStrategy
    {
        private const byte MonthsInYear = 12;
        private const decimal BaseCostsPerMonth = 5m;
        private const decimal ConsumptionCostsPerKilowattHour = 0.22m;

        /// <summary>
        /// Calculation model: base costs per month = 5€ + consumption costs = 22 cent/kWh.
        /// </summary>
        /// <param name="consumption">kWh/year</param>
        /// <returns></returns>
        public decimal GetAnnualCosts(decimal consumption)
        {
            if (consumption < 0)
            {
                throw new ApplicationException($"{ nameof(consumption) } can not be less than 0.");
            }

            var baseCostsPerYear = BaseCostsPerMonth * MonthsInYear;
            var consumptionCosts = ConsumptionCostsPerKilowattHour * consumption;

            return baseCostsPerYear + consumptionCosts;
        }
    }
}
