namespace Comarch20230427.Services.Sale;

public class VatCalculator
{
    public decimal CalculatePrice(decimal netto, decimal vat)
    {
        return netto + (netto * (vat / 100));
    }
}
