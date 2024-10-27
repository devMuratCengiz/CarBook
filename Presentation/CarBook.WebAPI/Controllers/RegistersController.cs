﻿using CarBook.Application.Features.Mediator.Commands.RegisterCommands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RegistersController : ControllerBase
	{
		private readonly IMediator _mediator;

		public RegistersController(IMediator mediator)
		{
			_mediator = mediator;
		}
		[HttpPost]
		public async Task<IActionResult>CreateUser(CreateAppUserCommand command)
		{
			await _mediator.Send(command);
			return Ok("Added");
		}
	}
}