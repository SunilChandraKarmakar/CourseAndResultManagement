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

        public JsonResult GetTeacherCradit(int teacherId)
        {
            db.Configuration.ProxyCreationEnabled = false;

            List<Teacher> teachers = db.Teachers.ToList();
            Teacher aTeacher = teachers.Find(t => t.TeacherId == teacherId);
            return Json(aTeacher, JsonRequestBehavior.AllowGet);
        }

        public JsonResult RemainingCraditForTeacher(int teacherId)
        {
            db.Configuration.ProxyCreationEnabled = false;

            List<Teacher> teacherList = db.Teachers.ToList();
            Teacher aTeacher = teacherList.Find(t => t.TeacherId == teacherId);

            List<CourseAssignToTeacher> courseAssignToTeacherList = db.CourseAssignToTeachers.ToList();
            CourseAssignToTeacher aCourseAssignToTeacher = (CourseAssignToTeacher)courseAssignToTeacherList.Where(c => c.TeacherId == teacherId);

            decimal teacherCradit = aTeacher.CraditToBeTaken;
            decimal assiginTeacherCradit = aCourseAssignToTeacher.RemainingCradit;
            decimal remainingCradit = teacherCradit - assiginTeacherCradit;

            return Json(remainingCradit, JsonRequestBehavior.AllowGet);
        }
    }
}
