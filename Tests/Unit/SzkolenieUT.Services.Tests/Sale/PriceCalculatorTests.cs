using System;
using System.Collections.Generic;
using NUnit.Framework;
using SzkolenieUT.Services.Sale;

namespace SzkolenieUT.Services.Tests.Sale
{
    public class PriceCalculatorTests
    {


        [TestCase("Jeep")]
        [TestCase("rower")]
        [TestCase("Ciężarówka")]
        public void PriceCalculatorShouldThrowArgumentOutOfRangeException(string carType)
        {
            //ARRANGE
            PriceCalculator calculator = new PriceCalculator();

            //ACT & ASSERT
            Assert.Throws<ArgumentOutOfRangeException>(() => calculator.CalculateCarPrice(carType));
        }

        [TestCase("Osobowy", 10000d)]
        [TestCase("ciężarowy", 50000d)]
        [TestCase("autobus", 150000d)]
        public void PriceCalculatorShouldReturnCorrectPriceForCorrectCarType(string carType, double expectedPrice)
        {
            //ARRANGE
            PriceCalculator calculator = new PriceCalculator();

            //ACT
            var actual = calculator.CalculateCarPrice(carType);

            //ASSERT
            Assert.AreEqual(expectedPrice, actual);
        }

    }
}
