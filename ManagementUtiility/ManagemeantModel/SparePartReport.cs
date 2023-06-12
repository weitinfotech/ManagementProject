using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagemeantModel
{
    public class SparePartReport
    {
        public int Id { get; set; }
        public decimal Cost { get; set; }
        public SparePart SparePart { get; set; }
        public string Company { get; set; }
        public int Quantity { get; set; }
        public DateTime ProductionDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public string Country { get; set;}
    }
}
