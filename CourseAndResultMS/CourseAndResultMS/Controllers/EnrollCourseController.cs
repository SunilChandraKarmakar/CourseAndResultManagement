using CourseAndResultMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CourseAndResultMS.Controllers
{
    public class EnrollCourseController : Controller
    {
        private CourseAndResultManagementEntities db = new CourseAndResultManagementEntities();

        [HttpGet]
        public ActionResult Index()
        {
            List<EnrollCourse> enrollCourses = db.EnrollCourses.ToList();
            ViewBag.EnrollCourseList = enrollCourses;
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            List<RegisterStudent> registerStudents = db.RegisterStudents.ToList();
            ViewBag.RegisterStudentList = registerStudents;
            return View();
        }
    }
}