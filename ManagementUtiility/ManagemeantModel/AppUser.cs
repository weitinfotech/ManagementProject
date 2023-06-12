

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagemeantModel
{
    public class AppUser: IdentityUser
    {
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public string Nationality { get; set; }
        public string Address{ get; set; }
        public DateTime DOB { get; set; }

        public string Specialist { get; set; }

        public bool IsUser { get; set; }
        public string PictureUri { get; set; }

        public Department Department { get; set; }
        [NotMapped]
        public ICollection<Appointment> Appointments { get; set; }
        [NotMapped]
        public ICollection<Payroll> Payrolls { get; set; }
    }
}

namespace ManagemeantModel
{
    public enum Gender
    {
        Male,Female,Other
    }
}
