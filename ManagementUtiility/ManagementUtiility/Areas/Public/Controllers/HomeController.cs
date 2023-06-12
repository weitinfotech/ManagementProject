using Microsoft.AspNetCore.Mvc;

namespace ManagementUtiility.Areas.Public.Controllers
{
    public class HomeController : Controller
    {
        [Area("Public")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
