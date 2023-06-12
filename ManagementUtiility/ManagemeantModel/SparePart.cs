using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagemeantModel
{
    public class SparePart
    {
        public int Id { get; set; }
        public string Name { get; set; }
            
        public string Type { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }
        public ICollection<SparePartReport> SparePartReport { get; set; }
        public ICollection<PrescribedPart> PrescribedPart { get; set; }

    }
}
