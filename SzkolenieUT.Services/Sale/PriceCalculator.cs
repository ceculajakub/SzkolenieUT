using System;

namespace SzkolenieUT.Services.Sale
{
    public class PriceCalculator
    {
        public double CalculateCarPrice(string carType)
        {
            switch (carType.ToUpper())
            {
                case "OSOBOWY":
                    return 10000d;
                case "CIĘŻAROWY":
                    return 50000d;
                case "AUTOBUS":
                    return 150000d;
                default:
                    throw new ArgumentOutOfRangeException("Podany typ pojazdu nie istnieje.");
            }
        }

    }
}
