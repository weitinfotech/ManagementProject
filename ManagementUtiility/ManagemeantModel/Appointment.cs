using System.ComponentModel.DataAnnotations.Schema;

namespace ManagemeantModel
{
    public class Appointment
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public DateTime CreatedDate { get; set; }
        public AppUser User { get; set;}
        [NotMapped]
        public AppUser Public { get; set; }
    }
}