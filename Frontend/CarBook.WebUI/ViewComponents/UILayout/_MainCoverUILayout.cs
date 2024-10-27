using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.UILayout
{
    public class _MainCoverUILayout : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
