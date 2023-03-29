using CryptoSiteAsp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CryptoSiteAsp.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public async Task<IActionResult> Index()
		{
			return View();
		}

        public async Task<IActionResult> SearchCrypto()
        {
            return View();
        }

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