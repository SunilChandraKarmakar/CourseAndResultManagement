using CourseAndResultMS.Models;
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
    }
}
