using System;
using Microsoft.AspNetCore.Identity;

namespace Shop.Core.Domain
{
	public class ApplicationUser : IdentityUser
	{

		public string City { get; set; }
	}
}

