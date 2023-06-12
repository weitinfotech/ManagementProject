using ManagemeantModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementViewModel
{
    public class AppUserViewModel
    {
        public List<AppUser> User { get; set; } = new List<AppUser>();
        public string Name { get; set; }
        public string Email { get; set; }

        public Gender Gender { get; set; }
        public string City { get; set; }
        public string Specialist { get; set; }
        public bool IsUser { get; set; }

        public AppUserViewModel()
        {

        }

        public AppUserViewModel(AppUser user)
        {
            Name = user.Name;
            Gender = user.Gender;
            City = user.Nationality;
            Specialist = user.Specialist;
            IsUser = user.IsUser;
            Email = user.Email;
        }

        public AppUser ConvertViewModelToModel(AppUserViewModel model)
        {
            return new AppUser { Name = model.Name, Gender = model.Gender, Nationality = model.City, Specialist = model.Specialist, Email = model.Email };
        }
    }
}
