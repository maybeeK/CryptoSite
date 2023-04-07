using Azure;
using CryptoSiteAsp.Entities;
using CryptoSiteAsp.Services.Interfaces;
using System.Collections.Generic;
using CryptoSiteAsp.Extentions;

namespace CryptoSiteAsp.Services
{
    public class CryptoService : ICryptoService
    {
        private readonly HttpClient _httpClient;
        public CryptoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<CryptoCurrencyCoin>> GetCurrencyByName(string name)
        {
            try
            {
                var responce = await _httpClient.GetAsync("https://api.coincap.io/v2/assets");
                if (responce.IsSuccessStatusCode)
                {
                    if (responce.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(IEnumerable<CryptoCurrencyCoin>);
                    }
                    var result = await responce.Content.ReadFromJsonAsync<APIResponceCryptoCurrencyCoin<List<CryptoCurrencyCoin>>> ();
                    return result.Data.Where(e=>e.Name.ToLower().Contains(name.ToLower(), StringComparison.OrdinalIgnoreCase));
                }
                else
                {
                    var msg = await responce.Content.ReadAsStringAsync();
                    throw new Exception(msg);
                }
            }
            catch (Exception)
            {
                //Log
                throw;
            }
        }

        public async Task<IEnumerable<CryptoCurrencyCoin>> GetTopNCurrency(int amount)
        {
            try
            {
                var responce = await _httpClient.GetAsync("https://api.coincap.io/v2/assets");
                if (responce.IsSuccessStatusCode)
                {
                    if (responce.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<CryptoCurrencyCoin>();
                    }
                    var result = await responce.Content.ReadFromJsonAsync<APIResponceCryptoCurrencyCoin<List<CryptoCurrencyCoin>>>();
                    return result.Data.Take(amount);
                }
                else
                {
                    var msg = await responce.Content.ReadAsStringAsync();
                    throw new Exception(msg);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

		public async Task<CryptoCurrencyCoin> GetCurrencyBySymbol(string symbol)
		{
            try
            {
				var responce = await _httpClient.GetAsync("https://api.coincap.io/v2/assets");
				if (responce.IsSuccessStatusCode)
				{
					if (responce.StatusCode == System.Net.HttpStatusCode.NoContent)
					{
						return default;
					}
					var result = await responce.Content.ReadFromJsonAsync<APIResponceCryptoCurrencyCoin<List<CryptoCurrencyCoin>>>();
					return result.Data.FirstOrDefault(e=>e.Symbol.ToLower()==symbol.ToLower());
				}
				else
				{
					var msg = await responce.Content.ReadAsStringAsync();
					throw new Exception(msg);
				}
			}
            catch (Exception)
            {

                throw;
            }
		}

		public async Task<IEnumerable<CryptoCurrencyCoinCandlestickData>> GetCurrencyCandleStickData(string symbol)
		{
            try
            {
                string pair = symbol.ToUpper()=="USDT" ? $"BUSDUSDT" : $"{symbol.ToUpper()}USDT";
                var url = $"https://api.binance.com/api/v3/klines?symbol={pair}&interval=1h&limit=10";

                var responce = await _httpClient.GetAsync(url);
				if (responce.IsSuccessStatusCode)
				{
					if (responce.StatusCode == System.Net.HttpStatusCode.NoContent)
					{
						return default;
					}
					var result = await responce.Content.ReadFromJsonAsync<IEnumerable<List<decimal>>>();
                    var qqq = result.ConvertToCryptoCurrencyCoinCandlestickDataList();
					return result.ConvertToCryptoCurrencyCoinCandlestickDataList();
				}
				else
				{
					var msg = await responce.Content.ReadAsStringAsync();
					throw new Exception(msg);
				}
			}
            catch (Exception)
            {
                throw;
			}
		}
	}
}
