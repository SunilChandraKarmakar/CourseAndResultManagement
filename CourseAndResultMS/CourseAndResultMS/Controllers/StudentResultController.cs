using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CourseAndResultMS.Models;

namespace CourseAndResultMS.Controllers
{
    public class StudentResultController : Controller
    {
        private CourseAndResultManagementEntities db = new CourseAndResultManagementEntities();

        [HttpGet]
        public ActionResult Create()
        {
            List<RegisterStudent> registerStudents = db.RegisterStudents.ToList();
            ViewBag.RegisterStudentList = registerStudents;

            List<GradeLetter> gradeLetters = db.GradeLetters.ToList();
            ViewBag.GradeLetterList = gradeLetters;
            return View();
        }

        public JsonResult GetRegisterStudentInfo(int registerStudentId)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<RegisterStudent> registerStudents = db.RegisterStudents.ToList();
            RegisterStudent getAStudentInfo = registerStudents.Find(r => r.RegisterStudentId == registerStudentId);
            return Json(getAStudentInfo, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDepartmentByRegistrationId(int registerStudentId)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<RegisterStudent> registerStudents = db.RegisterStudents.ToList();
            RegisterStudent getRegisterStudent = registerStudents.Find(r => r.RegisterStudentId == registerStudentId);
            int departmentId = getRegisterStudent.DepartmentId;

            List<Department> departments = db.Departments.ToList();
            Department getDepartment = departments.Find(d => d.DepartmentId == departmentId);
            string departmentName = getDepartment.Name;
            return Json(departmentName, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCourseListByRegisterStudentId(int registerStudentId)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<RegisterStudent> registerStudents = db.RegisterStudents.ToList();
            RegisterStudent getARegisterStudent = registerStudents.Find(r => r.RegisterStudentId == registerStudentId);
            int studentDepartmentId = getARegisterStudent.DepartmentId;

            List<Course> courses = db.Courses.ToList();
            List<Course> getStudentCourseByDepartmentId = courses.FindAll(c => c.DepartmentId == studentDepartmentId);
            return Json(getStudentCourseByDepartmentId, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Create(StudentResult aStudentResult)
        {
            if(ModelState.IsValid)
            {
                db.StudentResults.Add(aStudentResult);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            List<RegisterStudent> registerStudents = db.RegisterStudents.ToList();
            ViewBag.RegisterStudentList = registerStudents;

            List<GradeLetter> gradeLetters = db.GradeLetters.ToList();
            ViewBag.GradeLetterList = gradeLetters;
            return View(aStudentResult);

        }
    }
}