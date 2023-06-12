using ManagementServices;
using Microsoft.AspNetCore.Mvc;

namespace ManagementUtiility.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        public IAppUser _appUser;

        public UserController(IAppUser appUser)
        {
            _appUser = appUser;   
        }
        public IActionResult Index(int pageno=1,int pagesize=10)
        {
            return View(_appUser.GetAll(pageno,pagesize));
        }
    }
}
