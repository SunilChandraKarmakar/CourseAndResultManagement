using CourseAndResultMS.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CourseAndResultMS.Controllers
{
    public class TeacherController : Controller
    {
        private CourseAndResultManagementEntities db = new CourseAndResultManagementEntities();

        [HttpGet]
        public ActionResult Index()
        {
            List<Teacher> teachers = db.Teachers.ToList();
            ViewBag.TeacherList = teachers;
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            List<Designation> designations = db.Designations.ToList();
            List<Department> departments = db.Departments.ToList();
            ViewBag.DesignationList = designations;
            ViewBag.DepartmentList = departments;

            return View();
        }
    }
}
