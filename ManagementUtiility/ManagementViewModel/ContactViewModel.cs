using ManagemeantModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementViewModel
{
    public class ContactViewModel
    {
        public int Id { get; set; }
        public int CompanyID { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public CompanyInfo companyInfo { get; set; }

        public ContactViewModel()
        {
            
        }

        public ContactViewModel(Contact model)
        {
            Id = model.Id;
            Phone = model.Phone;
            CompanyID = model.CompanyID;
            Email = model.Email;
            companyInfo = model.Company;

        }

        public Contact ConvertViewModel(ContactViewModel model)
        {
            return new Contact
            {
                Id = model.Id,
                Phone = model.Phone,
                Email = model.Email,
                CompanyID = model.CompanyID,
                Company=model.companyInfo
               
            };
        }
    }
}
