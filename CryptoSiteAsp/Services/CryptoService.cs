using CryptoSiteAsp.Entities;
using CryptoSiteAsp.Services.Interfaces;
using System.Collections.Generic;

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
	}
}
