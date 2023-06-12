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
    public class AdminService : IAdminService
    {
        private IUnitOfWork _unitOfWork;

        public AdminService(IUnitOfWork unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }
        public void AddTiming(TimingViewModel timing)
        {
            var model = new TimingViewModel().ConvertViewModel(timing);
            _unitOfWork.genericRepo<Timing>().Add(model);
            _unitOfWork.save();
        }

        public void DeleteContact(int TimingId)
        {
            var model = _unitOfWork.genericRepo<Timing>().GetByID(TimingId);
            _unitOfWork.genericRepo<Timing>().Delete(model);
            _unitOfWork.save();
        }

        public PageResult<TimingViewModel> GetAll(int pageNo, int pagesize)
        {
            var vm = new TimingViewModel();
            int totalcount;
            List<TimingViewModel> vmList = new List<TimingViewModel>();
            try
            {
                int ExcludeRecords = (pageNo * pagesize) - pagesize;

                var modelList = _unitOfWork.genericRepo<Timing>().GetAll().Skip(ExcludeRecords).Take(pagesize).ToList();

                totalcount = _unitOfWork.genericRepo<Timing>().GetAll().ToList().Count;

                vmList = ConvertModelToViewModelList(modelList);
            }
            catch (Exception ex)
            {
                throw;
            }

            var result = new PageResult<TimingViewModel>(vmList,
                totalcount,
               pageNo,
                pagesize
                );
            return result;
        }

        private List<TimingViewModel> ConvertModelToViewModelList(List<Timing> modelList)
        {
            return modelList.Select(x => new TimingViewModel(x)).ToList();
        }

        public IEnumerable<TimingViewModel> GetAll()
        {
            var TimingList=_unitOfWork.genericRepo<Timing>().GetAll().ToList();
            var vmList = ConvertModelToViewModelList(TimingList);
            return vmList;
        }

        public TimingViewModel GetTimingById(int TimeingId)
        {
            var model = _unitOfWork.genericRepo<Timing>().GetByID(TimeingId);
            var vm = new TimingViewModel(model);
            return vm;
        }

        public void UpdateTiming(TimingViewModel timing)
        {
            var model = new TimingViewModel().ConvertViewModel(timing);
            var ModelById = _unitOfWork.genericRepo<Timing>().GetByID(model.Id);
            ModelById.Id = timing.Id;
            ModelById.admin = timing.Adminid;
            ModelById.Status = timing.Status;
            ModelById.Duration = timing.Duration;
            ModelById.MorningshiftStartTime = timing.MorningshiftStartTime;
            ModelById.MorningshiftEndTime = timing.MorningshiftEndTime;
            ModelById.AfterNoonShfitStartTime= timing.AfterNoonShfitStartTime;
            ModelById.AfterNoonShfitEndTime= timing.AfterNoonShfitEndTime;

            _unitOfWork.genericRepo<Timing>().Update(ModelById);
            _unitOfWork.save();
        }
    }
}
