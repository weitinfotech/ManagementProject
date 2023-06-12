using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagemeantModel
{
    public class Timing
    {
        public int Id { get; set; }
        public AppUser admin { get; set; }
        public DateTime Date { get; set; }
        public int  MorningshiftStartTime { get; set; }
        public int MorningshiftEndTime { get; set;}
        
        public int AfterNoonShfitStartTime { get; set; }
        public int AfterNoonShfitEndTime { get;set; }
        public int Duration { get; set; }
        public Status Status { get; set; }
    }

    public enum Status
    {
        Available,Pending,Confirm
    }
}
