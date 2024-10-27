using CarBook.DTO.CarDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.Default
{
    public class _Last5CarsWithBrands:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _Last5CarsWithBrands(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7126/api/Cars/GetLast5CarWithBrand");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultLast5CarsWithBrandsDto>>(jsonData);
                return View (values);
            }
            return View ();

        }
    }
}
