using CryptoSiteAsp.Data;
using CryptoSiteAsp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CryptoSiteAsp.Controllers
{
	public class UserAuthController : Controller
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;
		private readonly ApplicationDbContext _context;
		public UserAuthController(UserManager<ApplicationUser> userManager,
									SignInManager<ApplicationUser> signInManager,
									ApplicationDbContext context)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_context = context;
		}

		[AllowAnonymous]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Login(LoginModel loginModel)
		{
			loginModel.LoginInValid = "true";

			if (ModelState.IsValid)
			{
				var result = await _signInManager.PasswordSignInAsync(loginModel.Email,
																		loginModel.Password,
																		loginModel.RememberMe,
																		lockoutOnFailure: false);
				if (result.Succeeded)
				{
					loginModel.LoginInValid = string.Empty;
				}
				else
				{
					ModelState.AddModelError(string.Empty, "Invalid login attempt");
				}
			}
			return PartialView("_UserLoginPartial", loginModel);
		}

		[AllowAnonymous]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Logout(string returnUrl = null)
		{
			await _signInManager.SignOutAsync();
			if (returnUrl != null)
			{
				return LocalRedirect(returnUrl);
			}
			else
			{
				return RedirectToAction("Index", "Home");
			}
		}

		[AllowAnonymous]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> RegisterUser(RegistrationModel registrationModel)
		{
			registrationModel.RegistrationInValid = "true";

			if (ModelState.IsValid)
			{
				ApplicationUser user = new ApplicationUser
				{
					Email = registrationModel.Email,
					UserName = registrationModel.Email,
					FirstName = registrationModel.FirstName,
					LastName = registrationModel.LastName
				};

				var result = await _userManager.CreateAsync(user, registrationModel.Password);

				if (result.Succeeded)
				{
					registrationModel.RegistrationInValid = string.Empty;

					await _signInManager.SignInAsync(user, isPersistent: false);

					return PartialView("_UserRegistrationPartial", registrationModel);

				}

				AddErrorsToModelState(result);

			}

			return PartialView("_UserRegistrationPartial", registrationModel);

		}

		[AllowAnonymous]
		public async Task<bool> UserNameExists(string userName)
		{
			return await _context.Users.AnyAsync(u => u.UserName.ToLower() == userName.ToLower());
		}

		private void AddErrorsToModelState(IdentityResult identityResult)
		{
			foreach (var error in identityResult.Errors)
			{
				ModelState.AddModelError(string.Empty, error.Description);
			}
		}
	}
}
