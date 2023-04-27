using System;
using FluentAssertions;
using NUnit.Framework;
using SzkolenieUT.Services.Sale;

namespace SzkolenieUT.Services.Tests.Sale
{
    public class VatCalculatorTests
    {
        [TestCase(10, 23, 12.3d)]
        [TestCase(20, 23, 24.6d)]
        public void CalculatePriceShouldReturnCorrectBruttoValue(double netto, double vat, double expected)
        {
            //ARRANGE
            VatCalculator calculator = new VatCalculator();

            //ACT
            double actual = calculator.CalculatePrice(netto, vat);

            //ASSERT
            actual.Should().Be(expected).And.BeGreaterThan(0);
        }

        }
}
