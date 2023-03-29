using CryptoSiteAsp.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CryptoSiteAsp.Data
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		public DbSet<UserCryptoCurrency> userCryptos { get; set; }
	}

	public class ApplicationUser : IdentityUser
	{
		[StringLength(250)]
		public string? FirstName { get; set; }

		[StringLength(250)]
		public string? LastName { get; set; }
	}
}