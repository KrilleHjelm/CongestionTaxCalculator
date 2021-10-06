using System;

namespace CongestionTaxCalculator.API
{
    public interface ICongestionTaxCalculatorService
    {
        int CalculateCongestionTax(DateTime date, string vehicle, string city, string serialNumber);
    }
}
