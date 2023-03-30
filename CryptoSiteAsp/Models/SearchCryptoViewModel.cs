using CryptoSiteAsp.Entities;

namespace CryptoSiteAsp.Models
{
    public class SearchCryptoViewModel
    {
        public string? CoinName { get; set; }
        public IEnumerable<CryptoCurrencyCoin>? CryptoCurrencyCoins { get; set; }
    }
}
