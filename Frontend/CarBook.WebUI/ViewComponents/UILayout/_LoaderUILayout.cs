using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.UILayout
{
    public class _LoaderUILayout:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
