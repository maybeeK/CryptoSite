using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CryptoSiteAsp.Entities
{
    public class CryptoCurrencyCoin
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("rank")]
        public int Rank { get; set; }

        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("supply")]
        public decimal? Supply { get; set; }

        [JsonPropertyName("maxSupply")]
        public decimal? MaxSupply { get; set; }

        [JsonPropertyName("marketCapUsd")]
        [Display(Name = "Market Cap")]
        public decimal? MarketCapUsd { get; set; }

        [JsonPropertyName("volumeUsd24Hr")]
        public decimal? VolumeUsd24Hr { get; set; }

        [JsonPropertyName("priceUsd")]
        [Display(Name = "Price (USD)")]
        public decimal? PriceUsd { get; set; }

        [JsonPropertyName("changePercent24Hr")]
        [Display(Name = "Price change in 24h")]
        public decimal? ChangePercent24Hr { get; set; }

        [JsonPropertyName("vwap24Hr")]
        public decimal? Vwap24Hr { get; set; }

        [JsonPropertyName("explorer")]
        public string? Explorer { get; set; }
    }
}
