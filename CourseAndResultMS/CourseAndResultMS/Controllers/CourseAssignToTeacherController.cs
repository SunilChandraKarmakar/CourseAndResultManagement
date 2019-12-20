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
            List<Course> courses = db.Courses.ToList();
            ViewBag.DepartmentList = departments;
            ViewBag.CourseList = courses;
            return View();
        }

        public JsonResult GetTeacherByDepartmentId(int departmentId)
        {
            db.Configuration.ProxyCreationEnabled = false;

            List<Teacher> teachers = db.Teachers.ToList();
            List<Teacher> getTeacherListByDepartmentId = teachers.FindAll(t => t.DepartmentId == departmentId);
            return Json(getTeacherListByDepartmentId, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetTeacherCradit(int teacherId)
        {
            db.Configuration.ProxyCreationEnabled = false;

            List<Teacher> teachers = db.Teachers.ToList();
            Teacher aTeacher = teachers.Find(t => t.TeacherId == teacherId);
            return Json(aTeacher, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCourseByDepartmentId(int departmentId)
        {
            db.Configuration.ProxyCreationEnabled = false;

            List<Course> courses = db.Courses.ToList();
            List<Course> getCourseByDepartmentId = courses.FindAll(c => c.DepartmentId == departmentId);
            return Json(getCourseByDepartmentId, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCourseNameAndCraditByCourseId(int courseId)
        {
            db.Configuration.ProxyCreationEnabled = false;

            List<Course> courses = db.Courses.ToList();
            Course aCourse = courses.Find(c => c.CourseId == courseId);
            return Json(aCourse, JsonRequestBehavior.AllowGet);
        }
    }
}
