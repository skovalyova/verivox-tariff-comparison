namespace TariffComparison.Services.Abstractions
{
    public interface IAnnualCostsCalculationStrategy
    {
        decimal GetAnnualCosts(decimal consumption);
    }
}
