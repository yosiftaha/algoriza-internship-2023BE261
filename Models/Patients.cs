namespace Vezeeta_WebsiteBE.Models
{
    public class Patients
    {
        public int ID { get; set; }
        public string FirstName { get; set; }=string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public decimal Age { get; set; }
        public string Type { get; set; } = string.Empty;
        public int Status { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
