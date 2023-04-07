using CryptoSiteAsp.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Text.Json;

namespace CryptoSiteAsp.Extentions
{
	public static class Extentions
	{
		public static IEnumerable<CryptoCurrencyCoinCandlestickData> ConvertToCryptoCurrencyCoinCandlestickDataList(this IEnumerable<List<decimal>> objects) {
			try
			{
				List<CryptoCurrencyCoinCandlestickData> datas = new();
				foreach (var obj in objects)
				{
					
					datas.Add(new CryptoCurrencyCoinCandlestickData
					{
						KlineOpenTime = Convert.ToInt64(obj[0].ToString()),
						OpenPrice = Convert.ToDecimal(obj[1].ToString()),
						HighPrice = Convert.ToDecimal(obj[2].ToString()),
						LowPrice = Convert.ToDecimal(obj[3].ToString()),
						ClosePrice = Convert.ToDecimal(obj[4].ToString()),
						Volume = Convert.ToDecimal(obj[5].ToString()),
						KlineCloseTime = Convert.ToInt64(obj[6].ToString()),
						QuoteAssetVolume = Convert.ToDecimal(obj[7].ToString()),
						NumberOfTrades = Convert.ToInt32(obj[8].ToString()),
						TakerBuyBaseAssetVolume = Convert.ToDecimal(obj[9].ToString()),
						TakerBuyQuoteAssetVolume = Convert.ToDecimal(obj[10].ToString()),
						Ignore = obj[11].ToString()
					});
				}
				return datas;

			}
			catch (Exception)
			{

				throw;
			}
		}
	}
}
