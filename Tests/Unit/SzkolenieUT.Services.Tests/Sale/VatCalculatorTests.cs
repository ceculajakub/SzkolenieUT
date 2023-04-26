using System;
using NUnit.Framework;
using SzkolenieUT.Services.Sale;

namespace SzkolenieUT.Services.Tests.Sale
{
    public class VatCalculatorTests
    {

        [Test]
        public void CalculatePriceShouldReturnCorrectBruttoValue()
        {
            //ARRANGE
            decimal netto = 10, vat = 23;
            decimal expected = 12.3m;
            VatCalculator calculator = new VatCalculator();

            //ACT
            decimal actual = calculator.CalculatePrice(netto, vat);

            //ASSERT
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CalculatePriceShouldReturnExceptionWhenNettoIsNegative()
        {
            //ARRANGE
            decimal netto = -10, vat = 23;
            decimal expected = 12.3m;
            VatCalculator calculator = new VatCalculator();

            //ACT & ASSERT
            Assert.Throws<ArgumentOutOfRangeException>(() => calculator.CalculatePrice(netto, vat));
        }
    }
}
