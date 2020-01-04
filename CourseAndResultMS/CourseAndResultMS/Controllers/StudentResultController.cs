using CourseAndResultMS.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace CourseAndResultMS.Controllers
{
    public class StudentResultController : Controller
    {
        private CourseAndResultManagementEntities db = new CourseAndResultManagementEntities();

        [HttpGet]
        public ActionResult Index()
        {
            return View(db.StudentResults.ToList());
        }

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

        public JsonResult GetEnrollCourseByRegisterStudentId(int registerStudentId)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<EnrollCourse> getAllEnrollCourse = db.EnrollCourses.ToList();
            List<EnrollCourse> getMatchEnrollStudent = getAllEnrollCourse.FindAll(e => e.RegisterStudentId == registerStudentId);
            return Json(getMatchEnrollStudent, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Create(StudentResult aStudentResult)
        {
            if (ModelState.IsValid)
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

        [HttpGet]
        public ActionResult Edit(int? Id)
        {     
            if (Id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            StudentResult aStudentResult = db.StudentResults.Find(Id);

            if (aStudentResult == null)
                return HttpNotFound();

            ViewBag.RegisterStudentList = db.RegisterStudents.ToList();
            ViewBag.GradeLetterList = db.GradeLetters.ToList();
            return View(aStudentResult);
        }

        [HttpPost]
        public ActionResult Edit(StudentResult aStudentResult)
        {
            if(ModelState.IsValid)
            {
                db.Entry(aStudentResult).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RegisterStudentList = db.RegisterStudents.ToList();
            ViewBag.GradeLetterList = db.GradeLetters.ToList();
            return View(aStudentResult);
        }

        [HttpGet]
        public ActionResult ViewResult()
        {
            ViewBag.RegisterStudentList = db.RegisterStudents.ToList();
            return View();
        }

        public JsonResult GetStudentInfoByRegisterStudentId(int registerStudentId)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<RegisterStudent> getRegisterStudent = db.RegisterStudents.ToList();
            RegisterStudent getMatchRegisterStudent = getRegisterStudent.Find(r => r.RegisterStudentId == registerStudentId);
            return Json(getMatchRegisterStudent, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDepartmentByRegisterStudentId(int registerStudentId)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<RegisterStudent> getRegisterStudent = db.RegisterStudents.ToList();
            RegisterStudent getMatchRegisterStudent = getRegisterStudent.Find(r => r.RegisterStudentId == registerStudentId);
                        
            List<Department> getAllDepartment = db.Departments.ToList();
            Department getDepartmentName = getAllDepartment.Find(d => d.DepartmentId == getMatchRegisterStudent.DepartmentId);
            return Json(getDepartmentName.Name, JsonRequestBehavior.AllowGet);
        }

        //public JsonResult GetStudentResultByRegisterStudentId(int registerStudentId)
        //{
        //    List<StudentResultInfo> getStudentResultInfo = db.StudentResultInfoes.ToList();
        //    List<StudentResultInfo> getMatchStudentResultInfo = getMatchStudentResultInfo.FindAll(s=>s.)
        //}
    }
}
