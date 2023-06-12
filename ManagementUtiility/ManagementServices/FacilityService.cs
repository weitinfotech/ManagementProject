using ManagemeantModel;
using ManagementRepo.Interfaces;
using ManagementUtil;
using ManagementViewModel;

namespace ManagementServices
{
    public class FacilityService : IFacility
    {
        private IUnitOfWork _unitOfWork;

        public FacilityService(IUnitOfWork unitOfWork)
        {
            _unitOfWork= unitOfWork;
        }
        public void DeleteFacilityInfo(int FacilityId)
        {
            var model = _unitOfWork.genericRepo<Facility>().GetByID(FacilityId);
            _unitOfWork.genericRepo<Facility>().Delete(model);
            _unitOfWork.save();
        }

        public PageResult<FacilityViewModel> GetAll(int pageNo, int pagesize)
        {
            var vm = new FacilityViewModel();
            int totalcount;
            List<FacilityViewModel> vmList = new List<FacilityViewModel>();
            try
            {
                int ExcludeRecords = (pageNo * pagesize) - pagesize;

                var modelList = _unitOfWork.genericRepo<Facility>().GetAll(includeproperties: "Company").Skip(ExcludeRecords).ToList();

                totalcount = _unitOfWork.genericRepo<Facility>().GetAll().ToList().Count;

                vmList = ConvertModelToViewModelList(modelList);
            }
            catch (Exception ex)
            {
                throw;
            }

            var result = new PageResult<FacilityViewModel>(vmList,
                totalcount,
               pageNo,
                pagesize
                );
            return result;
        }

        private List<FacilityViewModel> ConvertModelToViewModelList(List<Facility> modelList)
        {
            return modelList.Select(x => new FacilityViewModel(x)).ToList();
        }

        public FacilityViewModel GetFacilityById(int FacilityId)
        {
            var model = _unitOfWork.genericRepo<Facility>().GetByID(FacilityId);
            var vm = new FacilityViewModel(model);
            return vm;
        }

        public void InsertFacilityInfo(FacilityViewModel Facility)
        {
            var model = new FacilityViewModel().ConvertViewModel(Facility);
            _unitOfWork.genericRepo<Facility>().Add(model);
            _unitOfWork.save();
        }

        public void UpdateFacilityInfo(FacilityViewModel Facility)
        {
            var model = new FacilityViewModel().ConvertViewModel(Facility);
            var ModelById = _unitOfWork.genericRepo<Facility>().GetByID(model.Id);
            ModelById.FacilityNo = Facility.FacilityNo;
            ModelById.Status = Facility.Status;
            ModelById.Type = Facility.Type;
            ModelById.CompanyId = Facility.CompanyId;

            _unitOfWork.genericRepo<Facility>().Update(ModelById);
            _unitOfWork.save();
        }

        //public List<SelectListItem> FillList()
        //{
        //    var list = new List<SelectListItem>();
        //    list.Add(new SelectListItem());
        //}
    }
}
