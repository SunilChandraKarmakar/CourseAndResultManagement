using CourseAndResultMS.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CourseAndResultMS.Controllers
{
    public class DepartmentController : Controller
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
            return View();
        }

        public JsonResult isExistCode(string code)
        {
            Department checkCode = db.Departments.FirstOrDefault(c => c.Code == code);

            if (checkCode != null)
                return Json(1);
            else
                return Json(0);
        }

        [HttpPost]
        public ActionResult Create(Department aDepartment)
        {
            if (ModelState.IsValid)
            {
                db.Departments.Add(aDepartment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aDepartment);
        }
    }
}
