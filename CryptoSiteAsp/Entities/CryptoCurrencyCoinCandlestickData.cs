using System.Text.Json.Serialization;

namespace CryptoSiteAsp.Entities
{
	public class CryptoCurrencyCoinCandlestickData
	{
		[JsonPropertyName("open_time")]
		public long KlineOpenTime { get; set; }

		[JsonPropertyName("open")]
		public decimal OpenPrice { get; set; }

		[JsonPropertyName("high")]
		public decimal HighPrice { get; set; }

		[JsonPropertyName("low")]
		public decimal LowPrice { get; set; }

		[JsonPropertyName("close")]
		public decimal ClosePrice { get; set; }

		[JsonPropertyName("volume")]
		public decimal Volume { get; set; }

		[JsonPropertyName("close_time")]
		public long KlineCloseTime { get; set; }

		[JsonPropertyName("qav")]
		public decimal QuoteAssetVolume { get; set; }

		[JsonPropertyName("num_trades")]
		public int NumberOfTrades { get; set; }

		[JsonPropertyName("taker_base_vol")]
		public decimal TakerBuyBaseAssetVolume { get; set; }

		[JsonPropertyName("taker_quote_vol")]
		public decimal TakerBuyQuoteAssetVolume { get; set; }

		[JsonPropertyName("ignore")]
		public string Ignore { get; set; }
	}
}
