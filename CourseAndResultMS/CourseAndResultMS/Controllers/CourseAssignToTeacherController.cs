using CourseAndResultMS.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace CourseAndResultMS.Controllers
{
    public class CourseAssignToTeacherController : Controller
    {
        private CourseAndResultManagementEntities db = new CourseAndResultManagementEntities();

        [HttpGet]
        public ActionResult Index()
        {
            List<Department> departments = db.Departments.ToList();
            ViewBag.DepartmentList = departments;
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

        public JsonResult GetRemainingCraditForTeacher(int teacherId)
        {
            db.Configuration.ProxyCreationEnabled = false;  
            List<Teacher> teachers = db.Teachers.ToList();
            Teacher aTeacher = teachers.Find(t => t.TeacherId == teacherId);

            List<CourseAssignToTeacher> courseAssignToTeachers = db.CourseAssignToTeachers.ToList();
            CourseAssignToTeacher courseAssignToTeacher = courseAssignToTeachers.FindLast(c => c.TeacherId == teacherId);

            if (courseAssignToTeacher == null)
                return Json(aTeacher.CraditToBeTaken, JsonRequestBehavior.AllowGet);
            else
                return Json(courseAssignToTeacher.RemainingCradit, JsonRequestBehavior.AllowGet);
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

        public JsonResult GetRemainingCraditByCourseId(int teacherId, int courseId)
        {
            db.Configuration.ProxyCreationEnabled = false;
            decimal teacherRemainingCradit = 0;
            List<CourseAssignToTeacher> courseAssignToTeachers = db.CourseAssignToTeachers.ToList();
            CourseAssignToTeacher aCourseAssignToTeacher = courseAssignToTeachers.FindLast(t => t.TeacherId == teacherId);
            
            List<Course> courses = db.Courses.ToList();
            Course aCourse = courses.Find(c => c.CourseId == courseId);
            
            List<Teacher> teachers = db.Teachers.ToList();
            Teacher aTeacher = teachers.Find(t => t.TeacherId == teacherId);

            if (aCourseAssignToTeacher == null)
            {
                decimal craditToBeTaken = aTeacher.CraditToBeTaken;
                decimal courseCradit = aCourse.Cradit;
                teacherRemainingCradit = craditToBeTaken - courseCradit; 
            }
            else
            {
                decimal remainingCradit = aCourseAssignToTeacher.RemainingCradit;
                decimal courseCradit = aCourse.Cradit;
                teacherRemainingCradit = remainingCradit - courseCradit;
            }

            return Json(teacherRemainingCradit, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCodeNameCraditByCourseId(int courseId)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<CourseAssignToTeacher> courseAssignToTeachers = db.CourseAssignToTeachers.ToList();
            CourseAssignToTeacher aCourseAssignToTeacher = courseAssignToTeachers.Find(c => c.CourseId == courseId);

            if (aCourseAssignToTeacher != null)
                return Json(1, JsonRequestBehavior.AllowGet);
            else
                return Json(0, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Create(CourseAssignToTeacher aCourseAssignToTeacher)
        {
            if (ModelState.IsValid)
            {
                db.CourseAssignToTeachers.Add(aCourseAssignToTeacher);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            List<Department> departments = db.Departments.ToList();
            List<Course> courses = db.Courses.ToList();
            ViewBag.DepartmentList = departments;
            ViewBag.CourseList = courses;
            return View(aCourseAssignToTeacher);
        }

        public JsonResult GetCourseInfoByDepartmentId(int departmentId)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<CourseInformation> courseInformation = db.CourseInformations.ToList();
            List<CourseInformation> aCourseInfo = courseInformation.FindAll(c => c.DepartmentId == departmentId);
            return Json(aCourseInfo, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult UnassignCourses()
        {
            ViewBag.CourseAssignToTeacherList = db.CourseAssignToTeachers.ToList();
            return View();
        } 
        
        [HttpGet]
        public ActionResult Delete(int? Id)
        {
            if (Id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            CourseAssignToTeacher aCourseAssignToTeacher = db.CourseAssignToTeachers.Find(Id);

            if (aCourseAssignToTeacher == null)
                return HttpNotFound();

            return View(aCourseAssignToTeacher);
        }

        [HttpPost]
        public ActionResult Delete(int Id)
        {
            CourseAssignToTeacher aCourseAssignToTeacher = db.CourseAssignToTeachers.Find(Id);
            db.CourseAssignToTeachers.Remove(aCourseAssignToTeacher);
            db.SaveChanges(); 
            return RedirectToAction("UnassignCourses");
        }
    }
}
