using Newtonsoft.Json;
using System;
using System.Text.Json.Serialization;

namespace Best.Buy.DTO
{
    public class ProductResponse
    {   
        public ProductResponse() 
        { 
        }  

        [JsonPropertyName("id")]
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("sku")]
        [JsonPropertyName("sku")]
        public string SKU { get; set; }

        [JsonProperty("name")]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonProperty("price")]
        [JsonPropertyName("price")]
        public decimal Price { get; set; }

        [JsonProperty("imgUrl")]
        [JsonPropertyName("imgUrl")]
        public string ImageUrl { get; set; }

        [JsonProperty("category")]
        [JsonPropertyName("category")]
        public string Category { get; set; }
    }
}