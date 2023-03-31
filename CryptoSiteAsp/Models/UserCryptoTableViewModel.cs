using CryptoSiteAsp.Entities;

namespace CryptoSiteAsp.Models
{
	public class UserCryptoTableViewModel
	{
		public IEnumerable<CryptoCurrencyCoin> CryptoCurrencyCoins { get; set; }
		public IEnumerable<UserCryptoCurrency> UserCryptoCurrencies { get; set; }
	}
}
