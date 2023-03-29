using System.ComponentModel.DataAnnotations;

namespace CryptoSiteAsp.Models
{
	public class RegistrationModel
	{
		[Required]
		[EmailAddress]
		[Display(Name = "User Email")]
		public string Email { get; set; }

		[Required]
		[StringLength(100, MinimumLength = 2)]
		[Display(Name = "First Name")]
		public string FirstName { get; set; }

		[Required]
		[StringLength(100, MinimumLength = 2)]
		[Display(Name = "Last Name")]
		public string LastName { get; set; }

		[Required]
		[DataType(DataType.Password)]
		#region RegexAttribute
		[RegularExpression("(?=^.{6,255}$)((?=.*\\d)(?=.*[A-Z])(?=.*[a-z])|(?=.*\\d)(?=.*[^A-Za-z0-9])(?=.*[a-z])|(?=.*[^A-Za-z0-9])(?=.*[A-Z])(?=.*[a-z])|(?=.*\\d)(?=.*[A-Z])(?=.*[^A-Za-z0-9]))^.*",
			ErrorMessage = "Password shoud contain at least 1 upper case character, at least 1 lower case character, at least 1 numerical character and at least 1 special symbol")]

		#endregion
		public string Password { get; set; }

		[Required]
		[Compare("Password")]
		[DataType(DataType.Password)]
		[Display(Name = "Confirm Password")]
		public string ConfirmPassword { get; set; }

		public string? RegistrationInValid { get; set; }
	}
}
