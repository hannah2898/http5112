using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using n01626469_Assignment3.Models;


namespace n01626469_Assignment3.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }

        //Get: Teacher/List 
        public ActionResult List()
        {   
            TeacherDataController controller = new TeacherDataController();
            IEnumerable<Teacher> Teachers = controller.ListTeachers();
            return View(Teachers);
        }

        //GET: Teacher/Show/{id}
        public ActionResult Show(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            Teacher NewTeacher = controller.FindTeacher(id);

            return View(NewTeacher);
        }

        //GET: /Teacher/DeleteConfirm/{id}
        public ActionResult DeleteConfirm(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            Teacher NewTeacher = controller.FindTeacher(id);

            return View(NewTeacher);
        }

        //POST: /Teacher/Delete/{id}
        public ActionResult Delete(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            controller.DeleteAuthor(id);
            return RedirectToAction("List");
        }
        //GET: /Teacher/new
        public ActionResult New()
        {
            return View();
        }
        //POST : /Author/Create
        [HttpPost]
        public ActionResult Create(string TeacherFname, string TeacherLname, string EmployeeNumber, DateTime HireDate, Decimal Salary)
        {
            //Identify that this method is running
            //Identify the inputs provided from the form

            Debug.WriteLine("I have accessed the create method");
            Debug.WriteLine(TeacherFname);
            Debug.WriteLine(TeacherLname);
            Debug.WriteLine(EmployeeNumber);
            Debug.WriteLine(HireDate);
            Debug.WriteLine(Salary);

            Teacher NewTeacher = new Teacher();
            NewTeacher.TeacherFname= TeacherFname;
            NewTeacher.TeacherLname= TeacherLname;
            NewTeacher.EmployeeNumber= EmployeeNumber;
            NewTeacher.HireDate= HireDate;
            NewTeacher.Salary= Salary;

            TeacherDataController controllor=new TeacherDataController();
            controllor.AddTeacher(NewTeacher);

            return RedirectToAction("List");
        }
    }
}