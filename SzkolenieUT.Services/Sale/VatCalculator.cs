using System;

namespace SzkolenieUT.Services.Sale
{
    public class VatCalculator
    {

        public decimal CalculatePrice(decimal netto, decimal vat)
        {
            if (netto < 0m || vat < 0m)
                throw new ArgumentOutOfRangeException();
            return netto + netto * vat / 100;
        }  
    }
}
