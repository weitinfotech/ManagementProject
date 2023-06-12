using ManagemeantModel;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Xml.Linq;

namespace ManagementViewModel
{
    public class FacilityViewModel
    {
        public int Id { get; set; }
        public int FacilityNo { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }

        public int CompanyId { get; set; }


        public CompanyInfo CompanyInfo { get; set; }

        public FacilityViewModel()
        {
            
        }

        public FacilityViewModel(Facility model)
        {
            Id = model.Id;
            FacilityNo = model.FacilityNo;
            Status = model.Status;
            Type = model.Type;
            CompanyId = model.CompanyId;
            CompanyInfo = model.Company;
            
        }

        public Facility ConvertViewModel(FacilityViewModel model)
        {
            return new Facility
            {
                Id = model.Id,
                FacilityNo = model.FacilityNo,
                Status = model.Status,
                Type = model.Type,
                CompanyId = model.CompanyId,
                Company = model.CompanyInfo,
              
        };
        }

    }
}
