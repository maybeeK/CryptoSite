using CryptoSiteAsp.Data;
using CryptoSiteAsp.Entities;
using CryptoSiteAsp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CryptoSiteAsp.Controllers
{
	public class FavouriteController : Controller
	{
		private readonly ApplicationDbContext _context;
		public FavouriteController(ApplicationDbContext context)
		{
			_context = context;
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize]
		public async Task AddToFavourite([Bind("Id, CoinName")] AddToFavouriteModel addToFavouriteModel)
		{
			if (addToFavouriteModel != null)
			{
				UserCryptoCurrency userCrypto = new() {
					CryptoCurrencyName = addToFavouriteModel.CoinName,
					UserId = addToFavouriteModel.Id 
				};
				_context.userCryptos.Add(userCrypto);
				await _context.SaveChangesAsync();
			}
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize]
		public async Task RemoveFromFavourite([Bind("Id, CoinName")] RemoveFromFavouriteModel removeFromFavouriteModel)
		{
			if (removeFromFavouriteModel != null)
			{
				UserCryptoCurrency userCrypto = await _context.userCryptos.
					FirstAsync(e=>e.UserId == removeFromFavouriteModel.Id && e.CryptoCurrencyName == removeFromFavouriteModel.CoinName);

				_context.userCryptos.Remove(userCrypto);
				await _context.SaveChangesAsync();
			}
		}
	}
}
