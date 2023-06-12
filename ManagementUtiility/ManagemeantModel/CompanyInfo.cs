using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagemeantModel
{
    public class CompanyInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type  { get; set; }

        public string City { get; set; }
        public string PinCode { get; set; }
        public string Countary { get; set; }
        public ICollection<Facility> Facilities { get; set; }

        public ICollection<Contact> Contacts { get; set; }


    }
}
