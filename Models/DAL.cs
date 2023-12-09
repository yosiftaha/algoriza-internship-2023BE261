using System.Data.SqlClient;
using System.Data;
namespace Vezeeta_WebsiteBE.Models
{
    public class DAL
    {
        public Response register(Patients patients, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("sp_register", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FirstName", patients.FirstName);
            cmd.Parameters.AddWithValue("@LastName", patients.LastName);
            cmd.Parameters.AddWithValue("@Password", patients.Password);
            cmd.Parameters.AddWithValue("@Email", patients.Email);
            cmd.Parameters.AddWithValue("@Age", patients.Age);
            cmd.Parameters.AddWithValue("@Type", "Users");
            cmd.Parameters.AddWithValue("@Status", "Pending");
            //cmd.Parameters.AddWithValue("@CreatedOn", patients.CreatedOn);

            connection.Open();
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Patient Registered Successfully";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Patient Registration Failed";
            }
            return response;
        }

        public Response login(Patients patients, SqlConnection connection)
        {
            SqlDataAdapter da = new SqlDataAdapter("sp_login", connection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@Email", patients.Email);
            da.SelectCommand.Parameters.AddWithValue("@Password", patients.Password);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Response response = new Response();
            Patients patient = new Patients();
            if (dt.Rows.Count > 0)
            {
                patient.ID = Convert.ToInt32(dt.Rows[0]["ID"]);
                patient.FirstName = Convert.ToString(dt.Rows[0]["FirstName"]);
                patient.LastName = Convert.ToString(dt.Rows[0]["LastName"]);
                patient.Email = Convert.ToString(dt.Rows[0]["Email"]);
                patient.Type = Convert.ToString(dt.Rows[0]["Type"]);
                response.StatusCode = 200;
                response.StatusMessage = "Patient Is Valid";
                response.patient = patient;
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Patient Is InValid";
                response.patient = null;
            }
            return response;
        }

        public Response viewPatient(Patients patients, SqlConnection connection)
        {
            SqlDataAdapter da = new SqlDataAdapter("p_viewPatient", connection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@ID", patients.ID);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Response response = new Response();
            Patients patient = new Patients();
            if (dt.Rows.Count > 0)
            {
                patient.ID = Convert.ToInt32(dt.Rows[0]["ID"]);
                patient.FirstName = Convert.ToString(dt.Rows[0]["FirstName"]);
                patient.LastName = Convert.ToString(dt.Rows[0]["LastName"]);
                patient.Email = Convert.ToString(dt.Rows[0]["Email"]);
                patient.Type = Convert.ToString(dt.Rows[0]["Type"]);
                patient.Age = Convert.ToDecimal(dt.Rows[0]["Age"]);
                patient.CreatedOn = Convert.ToDateTime(dt.Rows[0]["CreatedOn"]);
                patient.Password = Convert.ToString(dt.Rows[0]["Password"]);
                response.StatusCode = 200;
                response.StatusMessage = "Patient Exists.";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Patient Does Not Exists.";
                response.patient = patient;
            }
            return response;
        }

        public Response updateProfile(Patients patients, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("sp_updateProfile", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FirstName", patients.FirstName);
            cmd.Parameters.AddWithValue("@LastName", patients.LastName);
            cmd.Parameters.AddWithValue("@Password", patients.Password);
            cmd.Parameters.AddWithValue("@Email", patients.Email);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Record Updated Successfully";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Some Error Eccured.Try After Sometime";
            }
            return response;
        }

        public Response addToPatientHistory(PatientHistory patientHistory, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("sp_AddToPatientHistory", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PatientId", patientHistory.PatientId);
            cmd.Parameters.AddWithValue("@DoctorId", patientHistory.DoctorId);
            cmd.Parameters.AddWithValue("@UnitPrice", patientHistory.UnitPrice);
            cmd.Parameters.AddWithValue("@Discount", patientHistory.Discount);
            cmd.Parameters.AddWithValue("@TotalPrice", patientHistory.TotalPrice);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Patient History Record Added Successfully";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Patient History Could Not Be Added";
            }
            return response;
        }
        public Response takeAppointment(Patients patients, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("sp_TakeAppointment", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", patients.ID);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Appointment Has Been Placed Successfully";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Appointment Could Not Be Placed";
            }
            return response;
        }

        public Response appointmentList(Patients patients, SqlConnection connection)
        {
            Response response = new Response();
            List<AppointmentBooking> listAppointmentBooking = new List<AppointmentBooking>();
            SqlDataAdapter da = new SqlDataAdapter("sp_AppointmentList", connection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@Type", patients.Type);
            da.SelectCommand.Parameters.AddWithValue("@ID", patients.ID);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
               for(int i=0;i<dt.Rows.Count;i++)
               {
                    AppointmentBooking appointmentBooking = new AppointmentBooking();
                    appointmentBooking.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    appointmentBooking.AppointmentNo = Convert.ToString(dt.Rows[i]["AppointmentNo"]);
                    appointmentBooking.AppointmentTotal = Convert.ToDecimal(dt.Rows[i]["AppointmentTotal"]);
                    appointmentBooking.AppointmentStatus = Convert.ToString(dt.Rows[i]["AppointmentStatus"]);
                    listAppointmentBooking.Add(appointmentBooking);
               }
                if(listAppointmentBooking.Count>0)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = "Appointment Details Fetched";
                    response.ListAppointmentBooking = listAppointmentBooking;
                }
                else
                {
                    response.StatusCode = 100;
                    response.StatusMessage = "Appointment Details Are Not Available";
                    response.ListAppointmentBooking = null;
                }
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Appointment Details Are Not Available";
                response.ListAppointmentBooking = null;
            }
            return response;
        }

        public Response addUpdateDoctor(Doctors doctors, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("sp_AddUpdateDoctor", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Name", doctors.Name);
            cmd.Parameters.AddWithValue("@Specialization", doctors.Specialization);
            cmd.Parameters.AddWithValue("@UnitPrice", doctors.UnitPrice);
            cmd.Parameters.AddWithValue("@Discount", doctors.Discount);
            cmd.Parameters.AddWithValue("@Experience", doctors.Experience);
            cmd.Parameters.AddWithValue("@ImageUrl", doctors.ImageUrl);
            cmd.Parameters.AddWithValue("@Status", doctors.Status);
            cmd.Parameters.AddWithValue("@Type", doctors.Type);      //for insert or ubdate
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Doctor Inserted Successfully";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Doctor Did Not Save.Try Again.";
            }
            return response;
        }

        public Response patientList(SqlConnection connection)
        {
            Response response = new Response();
            List<Patients> listPatients = new List<Patients>();
            SqlDataAdapter da = new SqlDataAdapter("sp_PatientList", connection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Patients patient = new Patients();
                    patient.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    patient.FirstName = Convert.ToString(dt.Rows[i]["FirstName"]);
                    patient.LastName = Convert.ToString(dt.Rows[i]["LastName"]);
                    patient.Password = Convert.ToString(dt.Rows[i]["Password"]);
                    patient.Email = Convert.ToString(dt.Rows[i]["Email"]);
                    patient.Age = Convert.ToDecimal(dt.Rows[i]["Age"]);
                    patient.Type = Convert.ToString(dt.Rows[i]["Type"]);
                    patient.Status = Convert.ToInt32(dt.Rows[i]["Status"]);
                    patient.CreatedOn = Convert.ToDateTime(dt.Rows[i]["CreatedOn"]);
                    listPatients.Add(patient);
                }
                if (listPatients.Count > 0)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = "Patient Details Fetched";
                    response.ListPatients = listPatients;
                }
                else
                {
                    response.StatusCode = 100;
                    response.StatusMessage = "Patient Details Are Not Available";
                    response.ListPatients = null;
                }
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Patient Details Are Not Available";
                response.ListPatients = null;
            }
            return response;
        }
    }
}
