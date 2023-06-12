using ManagemeantModel;
using ManagementServices;
using ManagementViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;

namespace ManagementUtiility.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactController : Controller
    {
        private IContact _contact;
        private ICompanyInfo _companyinfo;

        public ContactController(IContact contact, ICompanyInfo companyInfo)
        {
            _contact = contact;
            _companyinfo = companyInfo;
           
        }
        public IActionResult Index(int Pageno = 1, int pagesize = 10)
        {
            return View(_contact.GetAll(Pageno,pagesize));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var viewModel = _contact.GetContactById(id);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(ContactViewModel vm)
        {
            _contact.UpdateContact(vm);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {


            return View();
        }

        [HttpPost]
        public IActionResult Create(ContactViewModel vm)
        {
            _contact.InsertContact(vm);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _contact.DeleteContact(id);
            return RedirectToAction("Index");
        }
    }
}
