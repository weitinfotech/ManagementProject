namespace ManagemeantModel
{
    public class Payroll
    {
        public int Id { get; set; }
        public AppUser EmpId { get; set; }
        public decimal Salary { get; set; }
        public decimal NetSalary { get; set; }

        public decimal HourlySalary { get; set; }
        public decimal BonusSalary { get; set; }
        public decimal Copensation { get; set; }

        public string AccountNumber { get; set; }

    }
}