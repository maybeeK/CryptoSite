using CryptoSiteAsp.Entities;

namespace CryptoSiteAsp.Services.Interfaces
{
    public interface ICryptoService
    {
        public Task<IEnumerable<CryptoCurrencyCoin>> GetTopNCurrency(int amount);
        public Task<IEnumerable<CryptoCurrencyCoin>> GetCurrencyByName(string name);
        public Task<CryptoCurrencyCoin> GetCurrencyBySymbol(string symbol);
        public Task<CryptoCurrencyCoin> GetCurrencyById(string id);
        public Task<IEnumerable<CryptoCurrencyCoinCandlestickData>> GetCurrencyCandleStickData(string symbol);

	}
}
