using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagemeantModel
{
    public class Lab
    {
        public int Id { get; set; }
        public string LabNo { get; set; }
        public AppUser Public { get; set; }
        public string TestType { get; set; }
        public string TestCode { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
        public int BloodPress { get; set; }
        public int Temp { get; set; }
        public string TestResult { get; set; }

    }
}
