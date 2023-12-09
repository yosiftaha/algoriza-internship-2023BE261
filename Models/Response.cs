namespace Vezeeta_WebsiteBE.Models
{
    public class Response
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }=string.Empty;

        public List<Patients> ListPatients { get; set; }
        public Patients patient { get; set; }
        public List<Doctors> ListDoctors { get; set; }
        public Doctors doctor { get; set; }
        public List<PatientHistory> ListPatientHistory { get; set; }

        public List<AppointmentBooking> ListAppointmentBooking { get; set; }
        public AppointmentBooking appointmentBooking { get; set; }

        public List<Appointment> ListAppointment { get; set; }
        public Appointment appointment { get; set; }
    }
}
