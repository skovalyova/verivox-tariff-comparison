using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TariffComparison.Services.Abstractions;
using TariffComparison.Services.Implementations;

namespace TariffComparison.Tests
{
    [TestClass]
    public class BasicAnnualCostsCalculationStrategyTest
    {
        private IAnnualCostsCalculationStrategy _service;

        [TestInitialize]
        public void Setup()
        {
            _service = new BasicAnnualCostsCalculationStrategy();
        }

        [TestMethod]
        public void GetAnnualCostsFor3500_Expected830()
        {
            // Act.
            var annualCosts = _service.GetAnnualCosts(3500);

            // Assert.
            annualCosts.Should().Be(830);
        }

        [TestMethod]
        public void GetAnnualCostsFor4500_Expected1050()
        {
            // Act.
            var annualCosts = _service.GetAnnualCosts(4500);

            // Assert.
            annualCosts.Should().Be(1050);
        }

        [TestMethod]
        public void GetAnnualCostsFor6000_Expected1380()
        {
            // Act.
            var annualCosts = _service.GetAnnualCosts(6000);

            // Assert.
            annualCosts.Should().Be(1380);
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void GetAnnualCostsForNegative_ExpectedException()
        {
            // Act.
            _service.GetAnnualCosts(-10);
        }
    }
}
