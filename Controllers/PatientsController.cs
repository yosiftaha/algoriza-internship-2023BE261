using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vezeeta_WebsiteBE.Models;
using System.Data.SqlClient;

namespace Vezeeta_WebsiteBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public PatientsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [Route("registration")]
        public Response register(Patients patients)
        {
            Response response = new Response();
            DAL dal= new DAL();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Vezcs").ToString());
            response=dal.register(patients, connection);
            return response;
        }

        [HttpPost]
        [Route("login")]
        public Response login(Patients patients)
        {
            DAL dal= new DAL();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Vezcs").ToString());
            Response response = dal.login(patients, connection);
            return response;
        }

        [HttpPost]
        [Route("viewPatient")]
        public Response viewPatient(Patients patients)
        {
            DAL dal= new DAL();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Vezcs").ToString());
            Response response = dal.viewPatient(patients, connection);
            return response;
        }

        [HttpPost]
        [Route("updateProfile")]
        public Response updateProfile(Patients patients)
        {
            DAL dal = new DAL();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Vezcs").ToString());
            Response response = dal.updateProfile(patients, connection);
            return response;

        }
    }
}
