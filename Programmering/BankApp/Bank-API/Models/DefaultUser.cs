using Microsoft.AspNetCore.Identity;

namespace Bank_API.Models
{
	public class User
	{
		public string UserName { get; set; } = string.Empty;
		public byte[] PasswordHash { get; set; }
		public byte[] PasswordSalt { get; set; }

		//public decimal Saldo { get; set; }
	}
}
