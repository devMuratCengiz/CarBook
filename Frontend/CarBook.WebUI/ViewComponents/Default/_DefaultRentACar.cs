using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.Default
{
    public class _DefaultRentACar:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string v)
        {
            TempData["value"] = v;
            return View();
        }
    }
}
