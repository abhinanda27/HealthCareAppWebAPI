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
    public class MedicineController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public MedicineController(IConfiguration configuration)
        {
             _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"select MedicineID, MedicineName,MedicinePrice from dbo.Medicines";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("MedicineAppCon");

            SqlDataReader myReader;
            using(SqlConnection myCon = new SqlConnection(sqlDataSource))
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

        public JsonResult Post(Medicine medicine)
        {
            string query = @"insert into dbo.Medicines values
( '"+ medicine.MedicineName.ToString() + "'" + "," + medicine.MedicinePrice+ @")";
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

        public JsonResult Put(Medicine medicine)
        {
            string query = @"update dbo.Medicines set MedicineName = '"+medicine.MedicineName+@"'
            where MedicineID ="+medicine.MedicineID + @"";
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

        [HttpDelete("{id}")]

        public JsonResult Delete(int id)
        {
            string query = @"delete from dbo.Medicines where MedicineID = " +id +@"";
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
            return new JsonResult("Deleted successfully");
        }



    }
}
