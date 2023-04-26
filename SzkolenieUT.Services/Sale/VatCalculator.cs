using System;

namespace SzkolenieUT.Services.Sale
{
    public class VatCalculator
    {

        public decimal CalculatePrice(decimal netto, decimal vat)
        {
            ValidateVat(vat);
            return netto + netto * vat / 100;
        }

        private void ValidateVat(decimal vat)
        {
            if (vat < 0m)
                throw new ArgumentOutOfRangeException("vat nie może być mniejszy od 0");
            if (vat > 100m)
                throw new ArgumentOutOfRangeException("vat nie może być większy od 100");
        }
    }
}
