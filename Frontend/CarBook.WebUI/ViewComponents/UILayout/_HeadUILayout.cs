using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.UILayout
{
    public class _HeadUILayout : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
