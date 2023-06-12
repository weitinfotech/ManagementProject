using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagemeantModel
{
    public class PublicReport
    {
        public int Id { get; set; }
        public string Diagnose { get; set; }
        public AppUser User { get; set; }
        [NotMapped]
        public AppUser Public { get; set; }
        public ICollection<PrescribedPart> PrescribedPart { get; set; }
    }
}
