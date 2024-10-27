using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.Blog
{
    public class _AddComment:ViewComponent
    {
        public IViewComponentResult Invoke(int id)
        {
            ViewBag.id= id;
            return View();
        }
    }
}
