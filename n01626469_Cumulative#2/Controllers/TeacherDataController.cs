using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using n01626469_Assignment3.Models;

namespace n01626469_Assignment3.Controllers
{
    public class TeacherDataController : ApiController
    {
        /// <summary>
        /// The database context class which allows us to access our MySQL Database
        /// </summary>
        ///<example> GET api/TeacherData/ListTeachers</example>
       
        private SchoolDBContext SchoolDB = new SchoolDBContext();
        [HttpGet]

        public IEnumerable<Teacher> ListTeachers()
        {
            //Create an instance of a connection
            MySqlConnection Conn = SchoolDB.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL Query
            cmd.CommandText = "Select * from teachers";

            //Gather result set of query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            //Create an empty list of Teacher Names
            List<Teacher> Teachers = new List<Teacher> { };

            //Loop through each row
            while (ResultSet.Read())
            {
                //Access Column information by the DB column name as an index
                int TeacherId = Convert.ToInt32(ResultSet["teacherid"]);
                string TeacherFname = (string)ResultSet["teacherfname"];
                string TeacherLname = (string)ResultSet["teacherlname"];
                string EmployeeNumber = (string)ResultSet["employeenumber"];
                DateTime HireDate = (DateTime)ResultSet["hiredate"];
                Decimal Salary = (Decimal)ResultSet["salary"];

                Teacher NewTeacher = new Teacher();

                NewTeacher.TeacherId = TeacherId;
                NewTeacher.TeacherFname = TeacherFname;
                NewTeacher.TeacherLname = TeacherLname;
                NewTeacher.EmployeeNumber = EmployeeNumber;
                NewTeacher.HireDate = HireDate;
                NewTeacher.Salary = Salary;

                //Add the Teacher Name to the List
                Teachers.Add(NewTeacher);
            }

            //Close the connection between MySQL Database and the WebServer
            Conn.Close();

            //Return the final list of teacher names
            return Teachers;
        }
        ///<example> GET api/TeacherData/FindTeacher/</example>
        [HttpGet]
        public Teacher FindTeacher(int id)
        {
            Teacher NewTeacher = new Teacher();

            //Create an instance of a connection
            MySqlConnection Conn = SchoolDB.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL Query
            cmd.CommandText = "Select * from teachers where teacherid= " + id;

            //Gather result set of query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            while (ResultSet.Read())
            {
                //Access Column information by the DB column name as an index
                int TeacherId = Convert.ToInt32(ResultSet["teacherid"]);
                string TeacherFname = (string)ResultSet["teacherfname"];
                string TeacherLname = (string)ResultSet["teacherlname"];
                string EmployeeNumber = (string)ResultSet["employeenumber"];
                DateTime HireDate = (DateTime)ResultSet["hiredate"];
                Decimal Salary = (Decimal)ResultSet["salary"];

                NewTeacher.TeacherId = TeacherId;
                NewTeacher.TeacherFname = TeacherFname;
                NewTeacher.TeacherLname = TeacherLname;
                NewTeacher.EmployeeNumber = EmployeeNumber;
                NewTeacher.HireDate = HireDate;
                NewTeacher.Salary = Salary;

                
            }
            return NewTeacher;
        }
        /// <summary>
        /// 
        ///</summary>
        ///<param name="id"></param>
        ///<example>POST: /api/AuthorData/DeleteAuthor/3</example>

        [HttpPost]
        public void DeleteAuthor(int id)
        {
            //Create an instance of a connection
            MySqlConnection Conn = SchoolDB.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            cmd.CommandText = "Delete from teachers where teacherid=@id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Prepare();

            cmd.ExecuteNonQuery();

            Conn.Close();
        }

        [HttpPost]
        public void AddTeacher([FromBody]Teacher Newteacher)
        {
            //Create an instance of a connection
            MySqlConnection Conn = SchoolDB.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            cmd.CommandText = "insert into teachers(teacherfname,teacherlname,employeenumber,hiredate,salary)values(@TeacherFname,@TeacherLname,@EmployeeNumber,@HireDate,@Salary)";
            cmd.Parameters.AddWithValue("@TeacherFname", Newteacher.TeacherFname);
            cmd.Parameters.AddWithValue("@TeacherLname", Newteacher.TeacherLname);
            cmd.Parameters.AddWithValue("@EmployeeNumber", Newteacher.EmployeeNumber);
            cmd.Parameters.AddWithValue("@HireDate", Newteacher.HireDate);
            cmd.Parameters.AddWithValue("@Salary", Newteacher.Salary);
            cmd.Prepare();

            cmd.ExecuteNonQuery();

            Conn.Close();
        }
    }
}
