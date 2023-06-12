using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagemeantModel
{
    public class Insurance
    {
        public int Id { get; set; }
        public string PolicyNo { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ICollection<Bill> Bill { get; set; }


    }
}
