using CarBook.DTO.CarDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Controllers
{
    public class CarController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

		public CarController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public IActionResult Index()
        {
            ViewBag.v1 = "Araçlar";
            ViewBag.v2 = "Son Model Araçlar";
            return View();
        }
        public async Task<IActionResult> CarDetail(int id)
        {
            ViewBag.v1 = "Araçlar";
            ViewBag.v2 = "Araç Detayları";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7126/api/Cars/"+id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultCarWithBrandDto> (jsonData);
                return View(values);
            }
            return View();
        } 
    }
}
