using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MySql.Data.MySqlClient;
using n01626469_Assignment3.Models;

namespace n01626469_Assignment3.Controllers
{
    
    public class ClassDataController : ApiController
    {
        private SchoolDBContext SchoolDB = new SchoolDBContext();

        [HttpGet]
        public IEnumerable<Class> ListClasses()
        {
            //Create an instance of a connection
            MySqlConnection Conn = SchoolDB.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL Query
            cmd.CommandText = "Select * from classes";

            //Gather result set of query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            //Create an empty list of Class Names
            List<Class> Classes = new List<Class> { };

            //Loop through each row
            while (ResultSet.Read())
            {
                //Access Column information by the DB column name as an index
                int ClassId = Convert.ToInt32(ResultSet["classid"]);
                string ClassCode = (string)ResultSet["classcode"];
                DateTime StartDate = (DateTime)ResultSet["startdate"];
                DateTime FinishDate = (DateTime)ResultSet["finishdate"];
                string ClassName = (string)ResultSet["classname"];


                Class NewClass = new Class();

                NewClass.ClassId = ClassId;
                NewClass.ClassCode = ClassCode;
                NewClass.StartDate = StartDate;
                NewClass.FinishDate = FinishDate;
                NewClass.ClassName = ClassName;

                //Add the Class Name to the List
                Classes.Add(NewClass);
            }

            //Close the connection between MySQL Database and the WebServer
            Conn.Close();

            //Return the final list of teacher names
            return Classes;
        }
        ///<example> GET api/TeacherData/FindTeacher/</example>
        [HttpGet]
        public Class FindClass (int id)
        {
            Class NewClass = new Class();

            //Create an instance of a connection
            MySqlConnection Conn = SchoolDB.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL Query
            cmd.CommandText = "Select * from classes where classid= " + id;

            //Gather result set of query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            while (ResultSet.Read())
            {
                //Access Column information by the DB column name as an index
                int ClassId = Convert.ToInt32(ResultSet["classid"]);
                string ClassCode = (string)ResultSet["classcode"];
                DateTime StartDate = (DateTime)ResultSet["startdate"];
                DateTime FinishDate = (DateTime)ResultSet["finishdate"];
                string ClassName = (string)ResultSet["classname"];


                NewClass.ClassId = ClassId;
                NewClass.ClassCode = ClassCode;
                NewClass.StartDate = StartDate;
                NewClass.FinishDate = FinishDate;
                NewClass.ClassName = ClassName;



            }
            return NewClass;
        }
    }
}

 