using CryptoSiteAsp.Entities;

namespace CryptoSiteAsp.Models
{
	public class FavouriteViewModel
	{
        public IEnumerable<CryptoCurrencyCoin>? CryptoCurrencyCoins { get; set; }
        public IEnumerable<UserCryptoCurrency>? UserCryptoCurrencies { get; set; }
    }
}
