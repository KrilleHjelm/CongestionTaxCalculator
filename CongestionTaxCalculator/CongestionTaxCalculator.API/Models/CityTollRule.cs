using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CongestionTaxCalculator.API.Models
{
    public class CityTollRule
    {
        [JsonPropertyName("tollRules")]
        public List<TollRule> TollRules { get; set; }
        [JsonPropertyName("tollFreeVehicles")]
        public List<string> TollFreeVehicles { get; set; }
    }

}
