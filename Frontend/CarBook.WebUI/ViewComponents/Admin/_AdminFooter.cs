using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.Admin
{
    public class _AdminFooter:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
