using System.Text.Json.Serialization;

namespace CongestionTaxCalculator.API.Models
{

    public class TollRule
    {
        [JsonPropertyName("timeFrom")]
        public string TimeFrom { get; set; }
        [JsonPropertyName("timeTo")]
        public string TimeTo { get; set; }
        [JsonPropertyName("cost")]
        public int Cost { get; set; }
    }
}
