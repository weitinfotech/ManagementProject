using ManagementUtil;
using ManagementViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementServices
{
    public interface IFacility
    {
        PageResult<FacilityViewModel> GetAll(int pageNo, int pagesize);
        FacilityViewModel GetFacilityById(int FacilityId);
        void UpdateFacilityInfo(FacilityViewModel Facility);
        void DeleteFacilityInfo(int FacilityId);
        void InsertFacilityInfo(FacilityViewModel Facility);
    }
}
