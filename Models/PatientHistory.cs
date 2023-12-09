namespace Vezeeta_WebsiteBE.Models
{
    public class PatientHistory
    {
        public int ID { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
