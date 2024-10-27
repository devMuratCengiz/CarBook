using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    public class LayoutController : Controller
    {
        [Authorize(Roles = "Admin")]
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
