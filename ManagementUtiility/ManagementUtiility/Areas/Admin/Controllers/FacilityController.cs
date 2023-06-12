using ManagemeantModel;
using ManagementServices;
using ManagementViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;

namespace ManagementUtiility.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FacilityController : Controller
    {
        
        private ICompanyInfo _companyinfo;
        private IFacility _facility;

        public FacilityController(IFacility facility, ICompanyInfo companyInfo)
        {
            _facility = facility;
            _companyinfo = companyInfo;
        }
        public IActionResult Index(int Pageno = 1, int pagesize = 10)
        {
            return View(_facility.GetAll(Pageno,pagesize));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var viewModel = _facility.GetFacilityById(id);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(FacilityViewModel vm)
        {
            _facility.UpdateFacilityInfo(vm);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {


            return View();
        }

        [HttpPost]
        public IActionResult Create(FacilityViewModel vm)
        {
            _facility.InsertFacilityInfo(vm);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _facility.DeleteFacilityInfo(id);
            return RedirectToAction("Index");
        }
    }
}
