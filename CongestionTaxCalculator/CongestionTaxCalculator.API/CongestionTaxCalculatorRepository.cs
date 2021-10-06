using CongestionTaxCalculator.API.Models;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace CongestionTaxCalculator.API
{
    public class CongestionTaxCalculatorRepository : ICongestionTaxCalculatorRepository
    {
        public CityTollRule GetTollRules(string city)
        {
            //var result = await _dbcontext.TollRules.Where(x => x.city == city).Select(x => new Tollrule
            //{ 
            //    TimeFrom = x.TimeFrom,
            //    TimeTo = x.TimeTo,
            //    Cost = x.Cost
            //}).ToListAsync

            var fileName = "TollCost.json";
            var jsonData = File.ReadAllText(fileName);
            return JsonSerializer.Deserialize<CityTollRule>(jsonData);
        }

        public void SaveTolledVehicle(Vehicle vehicle)
        {
            //I would rather have this checked towards a database but this will have to do for now
            var tolledVehicles = GetTolledVehicles();
            if(VehicleAlreadyInList(tolledVehicles, vehicle))
            {
                tolledVehicles.Vehicles = tolledVehicles.Vehicles.Where(x => x.SerialNumber != vehicle.SerialNumber).ToList();
            }
            tolledVehicles.Vehicles.Add(vehicle);
            var fileName = "TolledVehicles.json";
            var jsonData = JsonSerializer.Serialize(tolledVehicles);
            File.WriteAllText(fileName, jsonData);
        }

        public TolledVehicles GetTolledVehicles()
        {
            var fileName = "TolledVehicles.json";
            var jsonData = File.ReadAllText(fileName);
            return JsonSerializer.Deserialize<TolledVehicles>(jsonData);
        }
        
        private bool VehicleAlreadyInList(TolledVehicles tolledVehicles, Vehicle vehicle)
        {
            if(tolledVehicles.Vehicles.Any(x => x.SerialNumber == vehicle.SerialNumber))
            {
                return true;
            }
            return false;
        }
    }
}
