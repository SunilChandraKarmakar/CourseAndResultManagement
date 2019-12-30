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

        public JsonResult GetStudentInfoByRegStudentId(int registrationStudentId)
        {
            db.Configuration.ProxyCreationEnabled = false;

            List<RegisterStudent> registerStudents = db.RegisterStudents.ToList();
            RegisterStudent aRegisterStudent = registerStudents.Find(r => r.RegisterStudentId == registrationStudentId);                    
            return Json(aRegisterStudent, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDepartmentByRegStudentId(int registrationStudentId)
        {
            db.Configuration.ProxyCreationEnabled = false;

            List<RegisterStudent> registerStudents = db.RegisterStudents.ToList();
            RegisterStudent aRegisterStudent = registerStudents.Find(r => r.RegisterStudentId == registrationStudentId);
            int departmentId = aRegisterStudent.DepartmentId;

            List<Department> departments = db.Departments.ToList();
            Department aDepartment = departments.Find(d => d.DepartmentId == departmentId);
            string departmentName = aDepartment.Name;                                    
            return Json(departmentName, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCourseByDepartmentId(int registrationStudentId)
        {
            db.Configuration.ProxyCreationEnabled = false;

            List<RegisterStudent> registerStudents = db.RegisterStudents.ToList();
            RegisterStudent aRegisterStudent = registerStudents.Find(s => s.RegisterStudentId == registrationStudentId);
            int studentDepartmentId = aRegisterStudent.DepartmentId;

            List<Course> courses = db.Courses.ToList();
            List<Course> departmentCourse = courses.FindAll(c => c.DepartmentId == studentDepartmentId);
            return Json(departmentCourse, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Create(EnrollCourse aEnrollCourse)
        {
            if(ModelState.IsValid)
            {
                db.EnrollCourses.Add(aEnrollCourse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            List<RegisterStudent> registerStudents = db.RegisterStudents.ToList();
            ViewBag.RegisterStudentList = registerStudents;
            return View(aEnrollCourse);
        }
    }
}