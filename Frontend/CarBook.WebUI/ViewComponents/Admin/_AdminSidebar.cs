using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.Admin
{
    public class _AdminSidebar:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
