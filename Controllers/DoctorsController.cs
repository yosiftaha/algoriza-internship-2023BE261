using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using Vezeeta_WebsiteBE.Models;
namespace Vezeeta_WebsiteBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public DoctorsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpPost]
        [Route("addToPatientHistory")]
        public Response addToPatientHistory(PatientHistory patientHistory)
        {
            DAL dal = new DAL();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Vezcs").ToString());
            Response response = dal.addToPatientHistory(patientHistory,connection);
            return response;
        }

        [HttpPost]
        [Route("takeAppointment")]
        public Response takeAppointment(Patients patiens)
        {
            DAL dal = new DAL();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Vezcs").ToString());
            Response response = dal.takeAppointment(patiens, connection);
            return response;
        }

        [HttpPost]
        [Route("appointmentList")]
        public Response appointmentList(Patients patiens)
        {
            DAL dal = new DAL();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Vezcs").ToString());
            Response response = dal.appointmentList(patiens, connection);
            return response;
        }
    }
}
