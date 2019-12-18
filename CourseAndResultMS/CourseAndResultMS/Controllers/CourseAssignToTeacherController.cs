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
    }
}
