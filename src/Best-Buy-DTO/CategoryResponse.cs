using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Best.Buy.DTO
{
    public class CategoryResponse
    {
        [JsonPropertyName("id")]
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("category")]
        [JsonPropertyName("category")]
        public string CategoryName { get; set; }
    }
}