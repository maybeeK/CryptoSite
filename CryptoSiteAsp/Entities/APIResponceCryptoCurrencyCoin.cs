using System.Text.Json.Serialization;

namespace CryptoSiteAsp.Entities
{
    public class APIResponceCryptoCurrencyCoin<T>
    {
        [JsonPropertyName("data")]
        public T Data { get; set; }

        [JsonPropertyName("timestamp")]
        public long Timestamp { get; set; }
    }
}
