using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFirstWebSite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            string connetionString;
            SqlConnection cnn;
            SqlCommand command;
            SqlDataReader dataReader;
            String Output = " ";
            string sqlquery = "SELECT Id, Username, Password, Name, Surname, RecordTime FROM Users";

            connetionString = @"" + ConfigurationManager.AppSettings["connectionString"];

            cnn = new SqlConnection(connetionString);
            command = new SqlCommand(sqlquery, cnn);

            cnn.Open();

            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                Output = Output + dataReader.GetValue(0) + "-" + dataReader.GetValue(1) + "</br>";
            }

            Response.Write(Output);
            dataReader.Close();
            command.Dispose();
            cnn.Close();

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}