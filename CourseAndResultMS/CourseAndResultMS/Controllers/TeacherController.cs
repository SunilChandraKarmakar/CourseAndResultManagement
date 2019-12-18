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

        public JsonResult EmailIsExist(string checkEmail)
        {
            Teacher aTeacherEmail = db.Teachers.FirstOrDefault(e => e.Email == checkEmail);

            if (aTeacherEmail != null)
                return Json(1);
            else
                return Json(0);
        }

        public JsonResult ContactIsExist(string checkContact)
        {
            Teacher aTeacherContact = db.Teachers.FirstOrDefault(c => c.ContactNo == checkContact);

            if (aTeacherContact != null)
                return Json(1);
            else
                return Json(0);
        }
    }
}
