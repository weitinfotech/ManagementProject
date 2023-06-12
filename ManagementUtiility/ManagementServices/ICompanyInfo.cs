using ManagementUtil;
using ManagementViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementServices
{
    public interface ICompanyInfo
    {
        PageResult<CompanyInfoViewModel> GetAll(int pageNo, int pagesize);
        CompanyInfoViewModel GetCompanyById(int CompanyId);
        void UpdateCompanyInfo(CompanyInfoViewModel companyInfo);
        void DeleteCompanyInfo(int CompanyId);
        void InsertCompanyInfo(CompanyInfoViewModel companyInfo);
    }
}
