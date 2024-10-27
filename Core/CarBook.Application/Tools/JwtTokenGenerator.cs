using CarBook.Application.DTOs;
using CarBook.Application.Features.Mediator.Results.AppUserResults;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Tools
{
	public class JwtTokenGenerator
	{
		public static TokenResponseDto GenerateToken (CheckAppUserQueryResult result)
		{
			var claims = new List<Claim>();
			if (!string.IsNullOrEmpty(result.Role)) ;
			claims.Add(new Claim(ClaimTypes.Role, result.Role));
			claims.Add(new Claim(ClaimTypes.NameIdentifier, result.Id.ToString()));
			if (!string.IsNullOrWhiteSpace(result.Username))
				claims.Add(new Claim("Username", result.Username));
			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDeafults.Key));
			var signinCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
			var expireDate = DateTime.UtcNow.AddDays(JwtTokenDeafults.Expire);
			JwtSecurityToken token = new JwtSecurityToken(issuer:JwtTokenDeafults.ValidIssuer,audience:JwtTokenDeafults.ValidAudience,claims:claims,notBefore:DateTime.UtcNow,expires:expireDate,signingCredentials:signinCredentials);
			JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
			return new TokenResponseDto(handler.WriteToken(token), expireDate);
		}
	}
}
