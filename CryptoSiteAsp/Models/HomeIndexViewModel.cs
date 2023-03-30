using CryptoSiteAsp.Entities;

namespace CryptoSiteAsp.Models
{
    public class HomeIndexViewModel
    {
        public IEnumerable<CryptoCurrencyCoin> CryptoCurrencyCoins { get; set; }
    }
}
