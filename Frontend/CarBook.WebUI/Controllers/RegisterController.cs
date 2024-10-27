using CarBook.DTO.RegisterDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Controllers
{
	public class RegisterController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public RegisterController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public IActionResult CreateUser()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CreateUser(CreateRegisterDto createRegisterDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createRegisterDto);
			StringContent content = new StringContent(jsonData,Encoding.UTF8,"application/json");
			var responseMessage = await client.PostAsync("https://localhost:7126/api/Registers", content);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index","Login");
			}
			return View();
		}
	}
}
