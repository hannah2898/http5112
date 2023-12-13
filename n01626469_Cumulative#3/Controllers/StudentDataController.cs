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
    /// <summary>
    /// The database context class which allows us to access students our MySQL Database
    /// </summary>
    ///<example> GET api/StudentData/ListStudents</example>
    public class StudentDataController : ApiController
    {
        private SchoolDBContext SchoolDB = new SchoolDBContext();
        [HttpGet]

        public IEnumerable<Student> ListStudents()
        {
            //Create an instance of a connection
            MySqlConnection Conn = SchoolDB.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL Query
            cmd.CommandText = "Select * from students";

            //Gather result set of query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            //Create an empty list of Student Names
            List<Student> Students = new List<Student> { };

            //Loop through each row
            while (ResultSet.Read())
            {
                //Access Column information by the DB column name as an index
                int StudentId = Convert.ToInt32(ResultSet["studentid"]);
                string StudentFname = (string)ResultSet["studentfname"];
                string StudentLname = (string)ResultSet["studentlname"];
                string StudentNumber = (string)ResultSet["studentnumber"];
                DateTime Enroldate = (DateTime)ResultSet["enroldate"];

                Student NewStudent = new Student();

                NewStudent.StudentId = StudentId;
                NewStudent.StudentFname = StudentFname;
                NewStudent.StudentLname = StudentLname;
                NewStudent.StudentId = StudentId;
                NewStudent.StudentNumber = StudentNumber;
                NewStudent.Enroldate = Enroldate;


                //Add the Student Name to the List
                Students.Add(NewStudent);
            }

            //Close the connection between MySQL Database and the WebServer
            Conn.Close();

            //Return the final list of Student names
            return Students;
        }
        ///<example> GET api/StudentData/FindStudent/1</example>
        [HttpGet]
        public Student FindStudent(int id)
        {
            Student NewStudent = new Student();

            //Create an instance of a connection
            MySqlConnection Conn = SchoolDB.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL Query
            cmd.CommandText = "Select * from students where studentid= " + id;

            //Gather result set of query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            while (ResultSet.Read())
            {
                //Access Column information by the DB column name as an index
                int StudentId = Convert.ToInt32(ResultSet["studentid"]);
                string StudentFname = (string)ResultSet["studentfname"];
                string StudentLname = (string)ResultSet["studentlname"];
                string StudentNumber = (string)ResultSet["studentnumber"];
                DateTime Enroldate = (DateTime)ResultSet["enroldate"];

                NewStudent.StudentId = StudentId;
                NewStudent.StudentFname = StudentFname;
                NewStudent.StudentLname=StudentLname;
                NewStudent.StudentId = StudentId;
                NewStudent.StudentNumber = StudentNumber;
                NewStudent.Enroldate = Enroldate;


            }
            return NewStudent;
        }
    }
}
