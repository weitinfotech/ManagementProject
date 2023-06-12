using ManagemeantModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementViewModel
{
    public class CompanyInfoViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }

        public string City { get; set; }
        public string PinCode { get; set; }
        public string Countary { get; set; }

        public CompanyInfoViewModel()
        {
            
        }
        public CompanyInfoViewModel(CompanyInfo model)
        {
            Id = model.Id;
            Name = model.Name;
            Description = model.Description;
            Type = model.Type;
            City = model.City;
            PinCode = model.PinCode;
            Countary = model.Countary;
        }

        public CompanyInfo ConvertViewModel(CompanyInfoViewModel model)
        {
            return new CompanyInfo{
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                Type = model.Type,
                City = model.City,
                PinCode = model.PinCode,
                Countary = model.Countary
            };
        }
    }
}
