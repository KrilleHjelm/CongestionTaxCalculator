using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CongestionTaxCalculator.API.Models
{
    public class TolledVehicles
    {
        [JsonPropertyName("tolledVehicles")]
        public List<Vehicle> Vehicles { get; set; }
    }
}
