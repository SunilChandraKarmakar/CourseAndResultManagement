using CourseAndResultMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CourseAndResultMS.Controllers
{
    public class RegisterStudentController : Controller
    {
        private CourseAndResultManagementEntities db = new CourseAndResultManagementEntities();

        [HttpGet]
        public ActionResult Index()
        {
            List<RegisterStudent> registerStudents = db.RegisterStudents.ToList();
            ViewBag.RegisterStudentList = registerStudents;
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            List<Department> departments = db.Departments.ToList();
            ViewBag.DepartmentList = departments;
            return View();
        }

        public JsonResult GetEmailIsExist(string checkEmail)
        {
            db.Configuration.ProxyCreationEnabled = false;

            List<RegisterStudent> registerStudents = db.RegisterStudents.ToList();
            RegisterStudent aRegisterStudent = registerStudents.Find(r => r.Email == checkEmail);

            if (aRegisterStudent != null)
                return Json(1, JsonRequestBehavior.AllowGet);
            else
                return Json(0, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDepCodeById(int departmentId)
        {
            db.Configuration.ProxyCreationEnabled = false;

            List<Department> departments = db.Departments.ToList();
            Department aDepartment = departments.Find(d => d.DepartmentId == departmentId);

            string currentYear = DateTime.Now.Year.ToString();
            string departmentCodeWithCurrentYear = aDepartment.Code + "-" + currentYear;

            List<RegisterStudent> registerStudents = db.RegisterStudents.ToList();
            RegisterStudent registerStudentByDepartment = registerStudents.FindLast(r => r.DepartmentId == departmentId);

            string registrationNumber = "";

            if (registerStudentByDepartment == null)
            {
                int coutnStudent = 101;
                registrationNumber = departmentCodeWithCurrentYear + "-" + coutnStudent.ToString();
            }
            else
            {
                string storeRegistrationNumber = registerStudentByDepartment.RegistrationNumber;
                string findSerial = storeRegistrationNumber.Substring(9);
                int storeSerialInInt = Convert.ToInt32(findSerial);
                registrationNumber = departmentCodeWithCurrentYear + "-" + (storeSerialInInt + 1).ToString();
            }

            return Json(registrationNumber, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Create(RegisterStudent aRegisterStudent)
        {
            if (ModelState.IsValid)
            {
                db.RegisterStudents.Add(aRegisterStudent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            List<Department> departments = db.Departments.ToList();
            ViewBag.DepartmentList = departments;
            return View(aRegisterStudent);
        }
    }
}
