using Microsoft.AspNetCore.Mvc;
using Microsoft.Data;
using Microsoft.Data.SqlClient;
using JudoClubDB.Models;

namespace JudoClubDB.Controllers
{
    public class JudoController : Controller
    {
        String ConnStr = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\jlwan\\source\\repos\\C#\\ASP.NET\\MSSQLCSharp\\MSSQLCSharp\\Clubmembers.mdf;Integrated Security=True;Connect Timeout=30";
        public IActionResult Index()
        {
            return View(GetinfofromDB());
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            
            String SqlStr = "Select * from Judo where MemberID =" + id;
            JudoInfo JudoObj = new JudoInfo();
            // Create the connection object
            using (SqlConnection sqlConn = new SqlConnection(ConnStr)) // Connecting to the database indicated in the connection string.

            {
                using (SqlCommand sqlcmd = new SqlCommand(SqlStr))// Command object
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())// Data adapter to help me to get data from DB
                    {
                        
                        sqlcmd.Connection = sqlConn;
                        sqlConn.Open();
                        sda.SelectCommand =sqlcmd;
                        SqlDataReader sdr = sqlcmd.ExecuteReader();// Datareader is very much my dataset
                        while (sdr.Read())
                        {
                            
                            JudoObj.MemberID = (int)sdr["MemberID"];
                            JudoObj.FirstName =(string)sdr["FirstName"];
                            JudoObj.LastName = (string)sdr["LastName"];
                            JudoObj.DOB = (string)sdr["DOB"];
                            JudoObj.BeltRank = (string)sdr["BeltRank"];
                            
                        }
                        
                    }
                }
            }
            return View(JudoObj);
        }

        [HttpPost]
        public ActionResult Edit(int ID, JudoInfo JudoObj)
        {
            
            String SqlStr = $"Update Judo Set MemberID = {JudoObj.MemberID}, FirstName = '{JudoObj.FirstName }', LastName = '{JudoObj .LastName}' , DOB = '{JudoObj .DOB }', BeltRank='{JudoObj .BeltRank}' where MemberID = {ID}" ;
            using (SqlConnection sqlConn = new SqlConnection(ConnStr)) // Connecting to the database indicated in the connection string.
            {
                using (SqlCommand sqlcmd = new SqlCommand(SqlStr))// Command object
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())// Data adapter to help me to get data from DB
                    {

                        sqlcmd.Connection = sqlConn;
                        sqlConn.Open();
                        sda.SelectCommand =sqlcmd;
                        SqlDataReader sdr = sqlcmd.ExecuteReader();// Datareader is very much my dataset
                       
                    }
                }
            }

            return RedirectToAction ("index");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            
            String SqlStr = "Select * from Judo where MemberID =" + id;
            JudoInfo JudoObj = new JudoInfo();
            // Create the connection object
            using (SqlConnection sqlConn = new SqlConnection(ConnStr)) // Connecting to the database indicated in the connection string.
            {
                using (SqlCommand sqlcmd = new SqlCommand(SqlStr))// Command object
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())// Data adapter to help me to get data from DB
                    {

                        sqlcmd.Connection = sqlConn;
                        sqlConn.Open();
                        sda.SelectCommand =sqlcmd;
                        SqlDataReader sdr = sqlcmd.ExecuteReader();// Datareader is very much my dataset
                        while (sdr.Read())
                        {

                            JudoObj.MemberID = (int)sdr["MemberID"];
                            JudoObj.FirstName =(string)sdr["FirstName"];
                            JudoObj.LastName = (string)sdr["LastName"];
                            JudoObj.DOB = (string)sdr["DOB"];
                            JudoObj.BeltRank = (string)sdr["BeltRank"];

                        }

                    }
                }
            }
            return View(JudoObj);
        }

        [HttpGet]

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(JudoInfo JudoObj)
        {
            
            String SqlStr = $"Insert into Judo(MemberID, FirstName, LastName, DOB, BeltRank) Values({JudoObj.MemberID}, '{JudoObj.FirstName}', '{JudoObj .LastName}','{JudoObj .DOB }','{JudoObj .BeltRank }')";
            using (SqlConnection sqlConn = new SqlConnection(ConnStr)) // Connecting to the database indicated in the connection string.
            {
                using (SqlCommand sqlcmd = new SqlCommand(SqlStr))// Command object
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())// Data adapter to help me to get data from DB
                    {

                        sqlcmd.Connection = sqlConn;
                        sqlConn.Open();
                        sda.SelectCommand =sqlcmd;
                        SqlDataReader sdr = sqlcmd.ExecuteReader();// Datareader is very much my dataset

                    }
                }
            }

            return RedirectToAction("Index");
        }


        // The purpose of this function is to read data from database and pass it to the view.

        [HttpGet]
        public ActionResult Delete(int id)
        {
            
            String SqlStr = "Select * from Judo where MemberID =" + id;
            JudoInfo JudoObj = new JudoInfo();
            // Create the connection object
            using (SqlConnection sqlConn = new SqlConnection(ConnStr)) // Connecting to the database indicated in the connection string.
            {
                using (SqlCommand sqlcmd = new SqlCommand(SqlStr))// Command object
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())// Data adapter to help me to get data from DB
                    {

                        sqlcmd.Connection = sqlConn;
                        sqlConn.Open();
                        sda.SelectCommand =sqlcmd;
                        SqlDataReader sdr = sqlcmd.ExecuteReader();// Datareader is very much my dataset
                        while (sdr.Read())
                        {

                            JudoObj.MemberID = (int)sdr["MemberID"];
                            JudoObj.FirstName =(string)sdr["FirstName"];
                            JudoObj.LastName = (string)sdr["LastName"];
                            JudoObj.DOB = (string)sdr["DOB"];
                            JudoObj.BeltRank = (string)sdr["BeltRank"];

                        }

                    }
                }
            }
            return View(JudoObj);
        }

        [HttpPost]
        public ActionResult Delete(int ID, JudoInfo JudoObj)
        {
            
            String SqlStr = "Delete from Judo where MemberID =" + ID ;
            using (SqlConnection sqlConn = new SqlConnection(ConnStr)) // Connecting to the database indicated in the connection string.
            {
                using (SqlCommand sqlcmd = new SqlCommand(SqlStr))// Command object
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())// Data adapter to help me to get data from DB
                    {

                        sqlcmd.Connection = sqlConn;
                        sqlConn.Open();
                        sda.SelectCommand =sqlcmd;
                        SqlDataReader sdr = sqlcmd.ExecuteReader();// Datareader is very much my dataset

                    }
                }
            }

            return RedirectToAction("index");
        }

        public  List<JudoInfo> GetinfofromDB()
        {
            List<JudoInfo> listObj = new List<JudoInfo>();
            // I have to do all Database actions here
            // I need a connection object
            // I have to identify which database to connect
            
            // Create the connection object
            using (SqlConnection sqlConn = new SqlConnection(ConnStr)) // Connecting to the database indicated in the connection string.
            {
                using (SqlCommand sqlcmd = new SqlCommand("Select * from Judo"))// Command object
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())// Data adapter to help me to get data from DB
                    {
                        sqlcmd.Connection = sqlConn;
                        sqlConn.Open();
                        sda.SelectCommand =sqlcmd;
                        SqlDataReader sdr = sqlcmd.ExecuteReader();// Datareader is very much my dataset
                        while (sdr.Read())
                        {
                            JudoInfo JudoObj = new JudoInfo();
                            JudoObj.MemberID = (int)sdr["MemberID"];
                            JudoObj.FirstName =(string)sdr["FirstName"];
                            JudoObj.LastName = (string)sdr["LastName"];
                            JudoObj.DOB = (string)sdr["DOB"];
                            JudoObj.BeltRank = (string)sdr["BeltRank"];
                            listObj.Add(JudoObj);
                        }
                        return listObj;
                    }
                } 
            }
        }
    }
}
