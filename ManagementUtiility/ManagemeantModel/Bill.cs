namespace ManagemeantModel
{
    public class Bill
    {
        public int Id { get; set; }
        public int BillNo { get; set; }
        public AppUser Public { get; set; }
        public int DoctorCharge { get; set; }
        public decimal PartCharge { get; set; }
        public decimal FacilityCharge { get; set; }
        public decimal OperationCharge { get; set; }
        public int NoofDays { get; set; }
        public int NursingCharge { get; set; }
        public int LabCharge { get; set; }
        public decimal Advance { get; set; }
        public decimal TotalBill { get; set;}
         

    }
}