using System;

namespace SzkolenieUT.Services.Sale
{
    public class VatCalculator
    {
        public double CalculatePrice(double netto, double vat)
        {
            ValidateVat(vat);
            return netto + netto * vat / 100;
        }

        private void ValidateVat(double vat)
        {
            if (vat < 0d)
                throw new ArgumentOutOfRangeException("vat nie może być mniejszy od 0");
            if (vat > 100d)
                throw new ArgumentOutOfRangeException("vat nie może być większy od 100");
        }
    }
}
