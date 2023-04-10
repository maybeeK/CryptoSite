using CryptoSiteAsp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CryptoSiteAsp.Controllers
{
	public class CryptoCurrencyCoinController : Controller
	{
		private readonly ICryptoService _cryptoService;
		public CryptoCurrencyCoinController(ICryptoService cryptoService)
		{
			_cryptoService = cryptoService;
		}

		public async Task<IActionResult> Index(string coinSymbol)
		{
			var coin = await _cryptoService.GetCurrencyById(coinSymbol);
			if (coin == null)
			{
				return BadRequest();
			}
			else
			{
				return View(coin);
			}
		}
		public async Task<IActionResult> GetCandles(string coinSymbol)
		{
			var candles = await _cryptoService.GetCurrencyCandleStickData(coinSymbol);
			if (candles == null)
			{
				return BadRequest();
			}
			else
			{
				return PartialView("_CandlesPartial",candles);
			}
		}
	}
}
