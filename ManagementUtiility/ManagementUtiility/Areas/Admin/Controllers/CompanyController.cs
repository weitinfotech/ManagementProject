using ManagementServices;
using ManagementViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ManagementUtiility.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CompanyController : Controller
    {
        private ICompanyInfo _companyInfo;

        public CompanyController(ICompanyInfo companyInfo)
        {
            _companyInfo = companyInfo;
        }

        public IActionResult Index(int Pageno = 1,int pagesize=10)
        {
            return View(_companyInfo.GetAll(Pageno, pagesize));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var viewModel=_companyInfo.GetCompanyById(id);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(CompanyInfoViewModel vm)
        {
            _companyInfo.UpdateCompanyInfo(vm);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
           
            return View();
        }

        [HttpPost]
        public IActionResult Create(CompanyInfoViewModel vm)
        {
            _companyInfo.InsertCompanyInfo(vm);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _companyInfo.DeleteCompanyInfo(id);
            return RedirectToAction("Index");
        }
    }
}
