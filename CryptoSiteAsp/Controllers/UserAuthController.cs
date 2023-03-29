using Microsoft.AspNetCore.Mvc;

namespace CryptoSiteAsp.Controllers
{
	public class UserAuthController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
