using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.UILayout
{
    public class _NavbarUILayout : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
