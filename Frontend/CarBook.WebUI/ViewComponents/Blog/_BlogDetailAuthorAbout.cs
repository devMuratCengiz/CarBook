using CarBook.DTO.AuthorDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.Blog
{
    public class _BlogDetailAuthorAbout:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _BlogDetailAuthorAbout(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            ViewBag.id = id;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7126/api/Blogs/GetBlogByAuthorId?id="+id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<GetAuthorByBlogAuthorIdDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
