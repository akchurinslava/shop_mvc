using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authentication;

namespace Shop.Models.Accounts
{
	public class LoginViewModel
	{
		[Required]
		[EmailAddress]
		public string Email { get; set; }

		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Display(Name = "Remember me")]
		public bool RememberMe { get; set; }

		public string? ReturnUrl { get; set; }

		public IList<AuthenticationScheme> ExternalLogins { get; set; }
	}
}

