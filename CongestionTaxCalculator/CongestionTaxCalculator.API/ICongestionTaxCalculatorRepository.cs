using CongestionTaxCalculator.API.Models;

namespace CongestionTaxCalculator.API
{
    public interface ICongestionTaxCalculatorRepository
    {
        CityTollRule GetTollRules(string city);
        void SaveTolledVehicle(Vehicle vehicle);
        TolledVehicles GetTolledVehicles();
    }
}
