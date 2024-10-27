using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.Contact
{
    public class _Contact : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
