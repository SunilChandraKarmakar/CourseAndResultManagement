using CourseAndResultMS.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CourseAndResultMS.Controllers
{
    public class CourseController : Controller
    {
        private CourseAndResultManagementEntities db = new CourseAndResultManagementEntities();

        [HttpGet]
        public ActionResult Index()
        {
            List<Course> courses = db.Courses.ToList();
            ViewBag.CourseList = courses;
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            List<Department> departments = db.Departments.ToList();
            List<Semester> semesters = db.Semesters.ToList();
            ViewBag.DepartmentList = departments;
            ViewBag.SemesterList = semesters;
            return View();
        }
    }
}
