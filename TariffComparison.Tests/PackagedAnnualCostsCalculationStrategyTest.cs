using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TariffComparison.Services.Abstractions;
using TariffComparison.Services.Implementations;

namespace TariffComparison.Tests
{
    [TestClass]
    public class PackagedAnnualCostsCalculationStrategyTest
    {
        private IAnnualCostsCalculationStrategy _service;

        [TestInitialize]
        public void Setup()
        {
            _service = new PackagedAnnualCostsCalculationStrategy();
        }

        [TestMethod]
        public void GetAnnualCostsFor3500_Expected800()
        {
            // Act.
            var annualCosts = _service.GetAnnualCosts(3500);

            // Assert.
            annualCosts.Should().Be(800);
        }

        [TestMethod]
        public void GetAnnualCostsFor4000_Expected800()
        {
            // Act.
            var annualCosts = _service.GetAnnualCosts(4000);

            // Assert.
            annualCosts.Should().Be(800);
        }

        [TestMethod]
        public void GetAnnualCostsFor4500_Expected950()
        {
            // Act.
            var annualCosts = _service.GetAnnualCosts(4500);

            // Assert.
            annualCosts.Should().Be(950);
        }

        [TestMethod]
        public void GetAnnualCostsFor6000_Expected1400()
        {
            // Act.
            var annualCosts = _service.GetAnnualCosts(6000);

            // Assert.
            annualCosts.Should().Be(1400);
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
