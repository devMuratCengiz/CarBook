using CarBook.DTO.BlogDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.Blog
{
    public class _GetLast3Blogs:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _GetLast3Blogs(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7126/api/Blogs/GetLast3Blogs");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultLast3BlogsDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
