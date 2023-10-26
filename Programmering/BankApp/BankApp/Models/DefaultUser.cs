using Microsoft.AspNetCore.Identity;

namespace BankApp.Models
{
	public class DefaultUser : IdentityUser
	{
        public decimal Saldo { get; set; }
    }
}
