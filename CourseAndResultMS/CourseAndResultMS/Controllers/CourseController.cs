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

        public JsonResult CodeIsExist(string code)
        {
            Course course = db.Courses.FirstOrDefault(c => c.Code == code);

            if (course != null)
                return Json(1);
            else
                return Json(0);
        }

        public JsonResult NameIsExist(string name)
        {
            Course course = db.Courses.FirstOrDefault(c => c.Name == name);

            if (course != null)
                return Json(1);
            else
                return Json(0);
        }

        [HttpPost]
        public ActionResult Create(Course aCourse)
        {
            if (ModelState.IsValid)
            {
                db.Courses.Add(aCourse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            List<Department> departments = db.Departments.ToList();
            List<Semester> semesters = db.Semesters.ToList();
            ViewBag.DepartmentList = departments;
            ViewBag.SemesterList = semesters;
            return View(aCourse);
        }
    }
}
