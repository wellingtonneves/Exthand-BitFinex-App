using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Exthand.Bitfinex.DTO
{
    public class ExthandTradeResponse
    {
        [JsonPropertyName("ID")]
        [JsonProperty("ID")]
        public long Id { get; set; }

        [JsonProperty("MTS")]
        [JsonPropertyName("MTS")]
        public long Mts { get; set; }

        [JsonProperty("AMOUNT")]
        [JsonPropertyName("AMOUNT")]
        public decimal Amount { get; set; }

        [JsonProperty("PRICE")]
        [JsonPropertyName("PRICE")]
        public decimal Price { get; set; }

        [JsonProperty("RATE")]
        [JsonPropertyName("RATE")]
        public decimal Rate { get; set; }

        [JsonProperty("PERIOD")]
        [JsonPropertyName("PERIOD")]
        public int Period { get; set; }
    }
}
