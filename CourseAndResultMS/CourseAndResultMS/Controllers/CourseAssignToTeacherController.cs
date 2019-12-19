using CourseAndResultMS.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CourseAndResultMS.Controllers
{
    public class CourseAssignToTeacherController : Controller
    {
        private CourseAndResultManagementEntities db = new CourseAndResultManagementEntities();

        [HttpGet]
        public ActionResult Index()
        {
            List<CourseAssignToTeacher> courseAssignToTeachers = db.CourseAssignToTeachers.ToList();
            ViewBag.CourseAssignToTeachers = courseAssignToTeachers;
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            List<Department> departments = db.Departments.ToList();
            ViewBag.DepartmentList = departments;
            return View();
        }

        public JsonResult GetTeacherByDepartmentId(int departmentId)
        {
            db.Configuration.ProxyCreationEnabled = false;

            List<Teacher> teachers = db.Teachers.ToList();
            List<Teacher> getTeacherListByDepartmentId = teachers.FindAll(t => t.DepartmentId == departmentId);
            return Json(getTeacherListByDepartmentId, JsonRequestBehavior.AllowGet);
        }
    }
}
