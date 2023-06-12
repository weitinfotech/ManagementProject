using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagemeantModel
{
    public class PrescribedPart
    {
        public int Id { get; set; }
        public SparePart SparePart { get; set; }
        public PublicReport PublicReport { get; set; }
    }
}
