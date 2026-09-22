using System;
using System.Text.Json.Serialization;

namespace ConsumerDisneyIdApi
{
    // O nome da classe deve ser junto (BigBadWolf)
    public class BigBadWolf
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("imageUrl")]
        public string ImageUrl { get; set; } = string.Empty;
    }
}