﻿using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using Bank_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Bank_API.Controllers
{
	public class AuthController : Controller
	{
		public User user = new User();
		private readonly IConfiguration _configuration;

		public AuthController(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		[HttpPost("register")]
		public async Task<ActionResult<User>> Register(UserDto request)
		{
			CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
			user.UserName = request.UserName;
			user.PasswordHash = passwordHash;
			user.PasswordSalt = passwordSalt;

			return Ok(user);
		}

		[HttpPost("login")]
		public async Task<ActionResult<string>> Login(UserDto request)
		{
			if ("1" != request.UserName)
				return BadRequest("User not found");

			if (!VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
				return BadRequest("Wrong password");

			string token = CreateToken(user);

			return Ok(token);
		}

		private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
		{
			using (var hmac = new HMACSHA512(passwordSalt))
			{
				var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
				return computedHash.SequenceEqual(passwordHash);
			}
		}

		private string CreateToken(User user)
		{
			List<Claim> claims = new List<Claim>
			{
				new Claim(ClaimTypes.Name, user.UserName),
			new Claim(ClaimTypes.Role, "Admin")

	   };

			var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
					_configuration.GetSection("AppSettings:Token").Value));
			var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
			var token = new JwtSecurityToken(
								   claims: claims,
								   expires: DateTime.UtcNow.AddDays(1),
								   signingCredentials: cred
   );
			var jwt = new JwtSecurityTokenHandler().WriteToken(token);
			return jwt;
		}

		private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
		{
			using (var hmac = new HMACSHA512())
			{
				passwordSalt = hmac.Key;
				passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
			}
		}
	}
}
