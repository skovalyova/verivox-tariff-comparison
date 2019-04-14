using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TariffComparison.Services.Implementations;

namespace TariffComparison.Tests
{
    [TestClass]
    public class PackagedAnnualCostsCalculationStrategyTest
    {
        [TestMethod]
        public void GetAnnualCostsFor3500_Expected800()
        {
            // Arrange.
            var service = new PackagedAnnualCostsCalculationStrategy();

            // Act.
            var annualCosts = service.GetAnnualCosts(3500);

            // Assert.
            annualCosts.Should().Be(800);
        }

        [TestMethod]
        public void GetAnnualCostsFor4000_Expected800()
        {
            // Arrange.
            var service = new PackagedAnnualCostsCalculationStrategy();

            // Act.
            var annualCosts = service.GetAnnualCosts(4000);

            // Assert.
            annualCosts.Should().Be(800);
        }

        [TestMethod]
        public void GetAnnualCostsFor6000_Expected1400()
        {
            // Arrange.
            var service = new PackagedAnnualCostsCalculationStrategy();

            // Act.
            var annualCosts = service.GetAnnualCosts(6000);

            // Assert.
            annualCosts.Should().Be(1400);
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void GetAnnualCostsForNegative_ExpectedException()
        {
            // Arrange.
            var service = new PackagedAnnualCostsCalculationStrategy();

            // Act.
            service.GetAnnualCosts(-10);
        }
    }
}
