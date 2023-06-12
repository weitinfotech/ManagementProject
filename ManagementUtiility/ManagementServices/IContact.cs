using ManagementUtil;
using ManagementViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementServices
{
    public interface IContact
    {
        PageResult<ContactViewModel> GetAll(int pageNo, int pagesize);
        ContactViewModel GetContactById(int ContactId);
        void UpdateContact(ContactViewModel Contact);
        void DeleteContact(int ContactId);
        void InsertContact(ContactViewModel Contact);
    }
}
