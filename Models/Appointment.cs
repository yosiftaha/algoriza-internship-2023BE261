namespace Vezeeta_WebsiteBE.Models
{
    public class Appointment
    {
        public int ID { get; set; }
        public int AppointmentId { get; set; }
        public int DoctorId { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public DateTime Dates { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
