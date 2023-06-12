using ManagemeantModel;
using ManagementRepo.Interfaces;
using ManagementUtil;
using ManagementViewModel;

namespace ManagementServices
{
    public class ContactService : IContact
    {
        private IUnitOfWork _unitOfWork;

        public ContactService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void DeleteContact(int ContactId)
        {
            var model = _unitOfWork.genericRepo<Contact>().GetByID(ContactId);
            _unitOfWork.genericRepo<Contact>().Delete(model);
            _unitOfWork.save();
        }

        public PageResult<ContactViewModel> GetAll(int pageNo, int pagesize)
        {
            var vm = new ContactViewModel();
            int totalcount;
            List<ContactViewModel> vmList = new List<ContactViewModel>();
            try
            {
                int ExcludeRecords = (pageNo * pagesize) - pagesize;

                var modelList = _unitOfWork.genericRepo<Contact>().GetAll(includeproperties: "Company").Skip(ExcludeRecords).ToList();

                totalcount = _unitOfWork.genericRepo<Contact>().GetAll().ToList().Count;

                vmList = ConvertModelToViewModelList(modelList);
            }
            catch (Exception ex)
            {
                throw;
            }

            var result = new PageResult<ContactViewModel>(vmList,
                totalcount,
               pageNo,
                pagesize
                );
            return result;
        }

        private List<ContactViewModel> ConvertModelToViewModelList(List<Contact> modelList)
        {
            return modelList.Select(x => new ContactViewModel(x)).ToList();
        }

        public ContactViewModel GetContactById(int ContactId)
        {
            var model = _unitOfWork.genericRepo<Contact>().GetByID(ContactId);
            var vm = new ContactViewModel(model);
            return vm;
        }

        public void InsertContact(ContactViewModel Contact)
        {
            var model = new ContactViewModel().ConvertViewModel(Contact);
            _unitOfWork.genericRepo<Contact>().Add(model);
            _unitOfWork.save();
        }

        public void UpdateContact(ContactViewModel Contact)
        {
            var model = new ContactViewModel().ConvertViewModel(Contact);
            var ModelById = _unitOfWork.genericRepo<Contact>().GetByID(model.Id);
            ModelById.Phone = Contact.Phone;
            ModelById.Email = Contact.Email;
            ModelById.CompanyID = Contact.CompanyID;

            _unitOfWork.genericRepo<Contact>().Update(ModelById);
            _unitOfWork.save();
        }
    }
}
