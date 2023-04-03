using CryptoSiteAsp.Entities;
using System.Diagnostics.CodeAnalysis;

namespace CryptoSiteAsp.Comparers
{
	public class CryptoCurrencyCoinComparer : IEqualityComparer<CryptoCurrencyCoin>
	{
		public bool Equals(CryptoCurrencyCoin? x, CryptoCurrencyCoin? y)
		{
			if (x == null || y == null)
			{
				return false;
			}
			return x?.Symbol == y?.Symbol;
		}

		public int GetHashCode([DisallowNull] CryptoCurrencyCoin obj)
		{
			var toHash = $"{obj.Id}{obj.Name}{obj.Symbol}";
			return toHash.GetHashCode();
		}
	}
}
