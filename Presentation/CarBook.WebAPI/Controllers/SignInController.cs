using CarBook.Application.Features.Mediator.Queries.AppUserQueries;
using CarBook.Application.Tools;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CarBook.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SignInController : ControllerBase
	{
		private readonly IMediator _meditaor;

		public SignInController(IMediator meditaor)
		{
			_meditaor = meditaor;
		}
		[HttpPost]
		public async Task<IActionResult> Login(CheckAppUserQuery query)
		{
			var values = await _meditaor.Send(query);
			if (values.IsExist)
			{
				return Created("", JwtTokenGenerator.GenerateToken(values));
			}
			else
			{
				return BadRequest("Kullanıcı Adı veya Şifre Hatalı");
			}
		}
	}
}
