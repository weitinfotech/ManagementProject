using ManagementUtil;
using ManagementViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementServices
{
    public interface IAppUser
    {
        PageResult<AppUserViewModel> GetAll(int pageNo, int pagesize);
        PageResult<AppUserViewModel> GetAllUser(int pageNo, int pagesize);
        PageResult<AppUserViewModel> GetAllPublic(int pageNo, int pagesize);
        PageResult<AppUserViewModel> SearchUser(int pageNo, int pagesize);
    }
}
