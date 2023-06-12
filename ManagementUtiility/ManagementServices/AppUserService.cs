using ManagemeantModel;
using ManagementRepo.Interfaces;
using ManagementUtil;
using ManagementViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementServices
{
    public class AppUserService : IAppUser
    {
        private IUnitOfWork _unitOfWork;

        public AppUserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public PageResult<AppUserViewModel> GetAll(int pageNo, int pagesize)
        {
            var vm = new AppUserViewModel();
            int totalcount;
            List<AppUserViewModel> vmList = new List<AppUserViewModel>();
            try
            {
                int ExcludeRecords = (pageNo * pagesize) - pagesize;

                var modelList = _unitOfWork.genericRepo<AppUser>().GetAll().Skip(ExcludeRecords).ToList();

                totalcount = _unitOfWork.genericRepo<AppUser>().GetAll().ToList().Count;

                vmList = ConvertModelToViewModelList(modelList);
            }
            catch (Exception ex)
            {
                throw;
            }

            var result = new PageResult<AppUserViewModel>(vmList,
                totalcount,
               pageNo,
                pagesize
                );
            return result;
        }

        public PageResult<AppUserViewModel> GetAllPublic(int pageNo, int pagesize)
        {
            throw new NotImplementedException();
        }

        public PageResult<AppUserViewModel> GetAllUser(int pageNo, int pagesize)
        {
            throw new NotImplementedException();
        }

        public PageResult<AppUserViewModel> SearchUser(int pageNo, int pagesize)
        {
            throw new NotImplementedException();
        }

        private List<AppUserViewModel> ConvertModelToViewModelList(List<AppUser> modelList)
        {
            return modelList.Select(x => new AppUserViewModel(x)).ToList();
        }
    }
}
