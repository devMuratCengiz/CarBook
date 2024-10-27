using CarBook.DTO.BlogDtos;
using CarBook.WebUI.Areas.Admin.DTOs.CommentDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Controllers
{
    public class BlogController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BlogController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult>Index()
        {
            ViewBag.v1 = "Bloglar";
            ViewBag.v2 = "Yazarlarımızın Blogları";
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7126/api/Blogs/GetAllBlogsWithAuthor");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBlogsWithAuthorDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        public async Task<IActionResult>BlogDetail(int id)
        {
            ViewBag.v1 = "Bloglar";
            ViewBag.v2 = "Blog Detayları ve Yorumlar";
            ViewBag.id = id;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>AddComment(CreateCommentDto createCommentDto)
        {
            var client = _httpClientFactory.CreateClient();
            createCommentDto.CreatedDate = DateTime.Now;
            //createCommentDto.
            var jsonData = JsonConvert.SerializeObject(createCommentDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8,"application/json");
            var responseMessage = await client.PostAsync("https://localhost:7126/api/Comments", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("BlogDetail", "Blog", new { id = createCommentDto.BlogId });
            }
            return View();
        }
    }
}
