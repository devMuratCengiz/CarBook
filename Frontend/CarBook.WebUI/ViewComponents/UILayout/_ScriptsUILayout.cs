using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.UILayout
{
    public class _ScriptsUILayout:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
