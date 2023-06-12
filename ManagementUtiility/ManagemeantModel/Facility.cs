using System.Web.Mvc;

namespace ManagemeantModel
{
    public class Facility
    {
        public int Id { get; set; }
        public int FacilityNo { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public int CompanyId { get; set; }
        public CompanyInfo Company {get; set; }


    }
}