using HealthCareAppWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCareAppWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminUserController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AdminUserController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"select  [UserID]
      ,[FirstName]
      ,[LastName]
      ,[Email]
      ,[Pasword]
      ,[IsAdmin]
      ,[DateOfBirth]
      ,[Phone]
      ,[Address] from dbo.Users";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("MedicineAppCon");

            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult(table);
        }
        [HttpPost]

        public JsonResult Post(AppUser user)
        {
            string query = @"insert into dbo.Users values
( " + user.UserID  + "," +"'" + user.FirstName + "'"+","+"'" + user.LastName + "'" +"," + "'" + user.Email + "'" + "," + "'" + user.Pasword + "'" + "," + "'" + user.IsAdmin + "'" + "," +  user.DateOfBirth  + "," + "'" + user.Phone + "'" + "," + "'" + user.Address + "'" + @")";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("MedicineAppCon");

            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Added successfully");
        }

        [HttpPut]

        public JsonResult Put(AppUser user)
        {
            string query = @"update dbo.User set
           FirstName = '" + user.FirstName + @"',
           LastName = '" + user.LastName + @"',
           Email = '" + user.Email + @"',
           Pasword='" + user.Pasword + @"',
           IsAdmin='" + user.IsAdmin + @"',
           DateOfBirth='" + user.DateOfBirth + @"',
           Phone='" + user.Phone + @"',
           Address ='" + user.Address + @"',
           
            where UserID =" + user.UserID + @"";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("MedicineAppCon");

            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Updated successfully");
        }

        



    }
}
