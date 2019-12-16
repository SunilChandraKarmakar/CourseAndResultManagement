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
    }
}
