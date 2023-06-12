using ManagemeantModel;
using ManagementRepo.Interfaces;
using ManagementUtil;
using ManagementViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementServices
{
    public class CompanyInfoService : ICompanyInfo
    {
        private IUnitOfWork _unitOfWork;

        public CompanyInfoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void DeleteCompanyInfo(int CompanyId)
        {
            var model = _unitOfWork.genericRepo<CompanyInfo>().GetByID(CompanyId);
            _unitOfWork.genericRepo<CompanyInfo>().Delete(model);
            _unitOfWork.save();
        }

        public PageResult<CompanyInfoViewModel> GetAll(int pageNumber, int pagesize)
        {
            var vm=new CompanyInfoViewModel();
            int totalcount;
            List<CompanyInfoViewModel> vmList= new List<CompanyInfoViewModel>();
            try
            {
                int ExcludeRecords = (pageNumber * pagesize) - pagesize;

                var modelList= _unitOfWork.genericRepo<CompanyInfo>().GetAll().Skip(ExcludeRecords).ToList();

                totalcount = _unitOfWork.genericRepo<CompanyInfo>().GetAll().ToList().Count;

                vmList = ConvertModelToViewModelList(modelList);
            }
            catch (Exception ex)
            {
                throw;
            }
           
            var result= new PageResult <CompanyInfoViewModel>(vmList,
                totalcount,
               pageNumber,
                pagesize              
                );
            return result;
        }

        private List<CompanyInfoViewModel> ConvertModelToViewModelList(List<CompanyInfo> modelList)
        {
            return modelList.Select(x => new CompanyInfoViewModel(x)).ToList();
        }

        public CompanyInfoViewModel GetCompanyById(int CompanyId)
        {
            var model = _unitOfWork.genericRepo<CompanyInfo>().GetByID(CompanyId);
            var vm=new CompanyInfoViewModel(model);
            return vm;
        }

        public void InsertCompanyInfo(CompanyInfoViewModel companyInfo)
        {
            var model = new CompanyInfoViewModel().ConvertViewModel(companyInfo);
            _unitOfWork.genericRepo<CompanyInfo>().Add(model);
            _unitOfWork.save();
        }

        public void UpdateCompanyInfo(CompanyInfoViewModel companyInfo)
        {
            var model = new CompanyInfoViewModel().ConvertViewModel(companyInfo);
            var ModelById = _unitOfWork.genericRepo<CompanyInfo>().GetByID(model.Id);
            ModelById.Name = companyInfo.Name;
            ModelById.City = companyInfo.City;
            ModelById.PinCode= companyInfo.PinCode;
            ModelById.Countary= companyInfo.Countary;
            _unitOfWork.genericRepo<CompanyInfo>().Update(ModelById);
            _unitOfWork.save();
        }
    }
}
