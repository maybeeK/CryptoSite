using CryptoSiteAsp.Entities;
using CryptoSiteAsp.Models;
using CryptoSiteAsp.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CryptoSiteAsp.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly ICryptoService _cryptoService;

		public HomeController(ILogger<HomeController> logger, ICryptoService cryptoService)
		{
			_logger = logger;
			_cryptoService = cryptoService;
		}

		public async Task<IActionResult> Index()
		{
			var topCurrenciesList = await _cryptoService.GetTopNCurrency(5);
			HomeIndexViewModel viewModel = new() {CryptoCurrencyCoins = topCurrenciesList };

			return View(viewModel);
		}

        public async Task<IActionResult> SearchCrypto( )
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SearchCrypto(SearchCryptoViewModel viewModel)
        {
			if (ModelState.IsValid)
			{
				var coins = await	_cryptoService.GetCurrencyByName(viewModel.CoinName);
				viewModel.CryptoCurrencyCoins = coins;
			}
			return View(viewModel);
        }

        [Authorize]
        public async Task<IActionResult> Favourite()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}