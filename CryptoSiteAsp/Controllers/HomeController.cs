using CryptoSiteAsp.Comparers;
using CryptoSiteAsp.Data;
using CryptoSiteAsp.Entities;
using CryptoSiteAsp.Models;
using CryptoSiteAsp.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CryptoSiteAsp.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly ICryptoService _cryptoService;
		private readonly ApplicationDbContext _context;
		private readonly UserManager<ApplicationUser> _userManager;
		public HomeController(ILogger<HomeController> logger,
			ICryptoService cryptoService,
			ApplicationDbContext context,
			UserManager<ApplicationUser> userManager)
		{
			_logger = logger;
			_cryptoService = cryptoService;
			_context = context;
			_userManager = userManager;
		}

		public async Task<IActionResult> Index()
		{
			var topCurrenciesList = await _cryptoService.GetTopNCurrency(10);

			HomeIndexViewModel viewModel = new()
			{
				CryptoCurrencyCoins = topCurrenciesList,
				UserCryptoCurrencies = _context.userCryptos.Where(e=>e.UserId==_userManager.GetUserId(User))
			};

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
				var coins = (await	_cryptoService.GetCurrencyByName(viewModel.CoinName)).ToList();
				var coinFoundBySymbol = await _cryptoService.GetCurrencyBySymbol(viewModel.CoinName);
				if (coinFoundBySymbol != null)
				{
					coins.Add(coinFoundBySymbol);
				}
				viewModel.CryptoCurrencyCoins = coins.ToHashSet(new CryptoCurrencyCoinComparer());
				viewModel.UserCryptoCurrencies = _context.userCryptos.Where(e => e.UserId == _userManager.GetUserId(User));
			}
			return View(viewModel);
        }

        [Authorize]
        public async Task<IActionResult> Favourite(FavouriteViewModel favouriteViewModel)
        {
			favouriteViewModel.UserCryptoCurrencies = await _context.userCryptos.Where(e=>e.UserId==_userManager.GetUserId(User)).ToListAsync();
			var coins = new List<CryptoCurrencyCoin>();
			foreach (var item in favouriteViewModel.UserCryptoCurrencies)
			{
				var coin = (await _cryptoService.GetCurrencyByName(item.CryptoCurrencyName)).First(e=>e.Name == item.CryptoCurrencyName);
				coins.Add(coin);
			}
			favouriteViewModel.CryptoCurrencyCoins = coins;
            return View(favouriteViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}