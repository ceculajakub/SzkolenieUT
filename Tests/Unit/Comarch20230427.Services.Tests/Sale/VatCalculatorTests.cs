using Comarch20230427.Services.Sale;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comarch20230427.Services.Tests.Sale
{
    public class VatCalculatorTests
    {
        [Test]
        public void CalculatePriceShouldReturnCorrectBruttoValue()
        {
            //Arrange
            decimal netto = 10, vat = 23;
            decimal expected = 12.3m;
            VatCalculator calculator = new VatCalculator();

            //Act
            decimal actual = calculator.CalculatePrice(netto, vat);

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
