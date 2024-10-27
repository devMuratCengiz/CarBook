using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.Admin
{
    public class _AdminScripts:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
