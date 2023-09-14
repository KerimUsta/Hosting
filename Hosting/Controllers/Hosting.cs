using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Hosting.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HostingController : ControllerBase
    {
        //string _connectionString = "Data Source=YAZILIM10-NB;Initial Catalog=WebApi;User ID=kerimustalocal;Password=Kerim+123456;TrustServerCertificate=True;";
        //[HttpPost]
        //[Route("Login")]
        //public Response Login(User user)
        //{

        //    Response response = new Response();
        //    using (SqlConnection con = new SqlConnection(_connectionString))
        //    {
        //        //baglanti.Open();
        //        con.Open();
        //        SqlCommand cmd = new SqlCommand("procLogin", con);
        //        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@username", user.Username);
        //        cmd.Parameters.AddWithValue("@password", user.Password);
        //        cmd.ExecuteNonQuery();
        //        SqlDataReader dr = cmd.ExecuteReader();
        //        while (dr.Read())
        //        {
        //            response.ResponsCode = Convert.ToInt32(dr["ResponseCode"]);
        //        }
        //        dr.Close();
        //    }
        //    return response;
        //}
        private readonly DatabaseContext _db;

        public HostingController(DatabaseContext db)
        {
            _db = db;
        }

        [HttpPost]
        [Route("Login")]
        public Response Login(User user)
        {
            Response response = new Response();

            using (var con = _db.GetConnection())
            {
                var loginService = new LoginService(con);
                response.ResponsCode = loginService.ExecuteLoginProcedure(user.Username, user.Password);
            }

            return response;
        }


    }
}


