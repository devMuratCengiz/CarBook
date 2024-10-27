using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.Admin
{
    public class _AdminHeader:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
