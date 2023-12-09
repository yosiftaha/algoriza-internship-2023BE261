namespace Vezeeta_WebsiteBE.Models
{
    public class AppointmentBooking
    {
        public int ID { get; set; }
        public int PatientId { get; set; }
        public string AppointmentNo { get; set; } = string.Empty;
        public decimal AppointmentTotal { get; set; }
        public string AppointmentStatus { get; set; } = string.Empty;
    }
}
