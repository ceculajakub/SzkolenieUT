using System;
using NUnit.Framework;
using SzkolenieUT.Services.Sale;

namespace SzkolenieUT.Services.Tests.Sale
{
    public class VatCalculatorTests
    {
        [TestCase(10, 23, 12.3d)]
        [TestCase(20, 23, 24.6d)]
        public void CalculatePriceShouldReturnCorrectBruttoValue(decimal netto, decimal vat, double expected)
        {
            //ARRANGE
            VatCalculator calculator = new VatCalculator();

            //ACT
            decimal actual = calculator.CalculatePrice(netto, vat);

            //ASSERT
            Assert.AreEqual(expected, actual);
        }

        [TestCase(-1)]
        [TestCase(101)]
        public void CalculatePriceShouldThrowOutOfRangeException(decimal vat)
        {
            //ARRANGE
            decimal netto = 10;
            VatCalculator calculator = new VatCalculator();

            //ACT & ASSERT
            Assert.Throws<ArgumentOutOfRangeException>(() => calculator.CalculatePrice(netto, vat));
        }
    }
}
