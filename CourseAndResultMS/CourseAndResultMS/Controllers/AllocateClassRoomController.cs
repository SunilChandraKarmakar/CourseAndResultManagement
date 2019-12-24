using CourseAndResultMS.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CourseAndResultMS.Controllers
{
    public class AllocateClassRoomController : Controller
    {
        private CourseAndResultManagementEntities db = new CourseAndResultManagementEntities();

        [HttpGet]
        public ActionResult Index()
        {
            List<AllocateClassRoom> allocateClassRooms = db.AllocateClassRooms.ToList();
            ViewBag.AllocateClassRoom = allocateClassRooms;
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            List<Department> departments = db.Departments.ToList();
            List<Course> courses = db.Courses.ToList();
            List<ClassRoom> classRooms = db.ClassRooms.ToList();
            List<Week> weeks = db.Weeks.ToList();

            ViewBag.DepartmentList = departments;
            ViewBag.CourseList = courses;
            ViewBag.ClassRoomList = classRooms;
            ViewBag.WeekList = weeks;

            return View();
        }
    }
}
