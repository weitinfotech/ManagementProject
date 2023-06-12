namespace ManagemeantModel
{
    public class Contact
    {
        public int Id { get; set; }
        public int CompanyID { get; set; }
        public CompanyInfo Company { get; set; }
        public string Phone { get; set; }          
        public string Email { get; set; }

    }
}