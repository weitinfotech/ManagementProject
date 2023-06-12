using ManagementUtil;
using ManagementViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementServices
{
    public interface IAdminService
    {
        PageResult<TimingViewModel> GetAll(int pageNo, int pagesize);
        IEnumerable<TimingViewModel> GetAll();
        TimingViewModel GetTimingById(int TimeingId);
        void UpdateTiming(TimingViewModel timing);
        void DeleteContact(int TimingId);
        void AddTiming(TimingViewModel timing);
    }
}
