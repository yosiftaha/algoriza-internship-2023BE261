using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using Vezeeta_WebsiteBE.Models;

namespace Vezeeta_WebsiteBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AdminController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [Route("addUpdateDoctor")]
        public Response addUpdateDoctor(Doctors doctors)
        {
            DAL dal = new DAL();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Vezcs").ToString());
            Response response = dal.addUpdateDoctor(doctors, connection);
            return response;
        }


        [HttpPost]
        [Route("patientList")]
        public Response patientList()
        {
            DAL dal = new DAL();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Vezcs").ToString());
            Response response = dal.patientList(connection);
            return response;
        }

    }
}
