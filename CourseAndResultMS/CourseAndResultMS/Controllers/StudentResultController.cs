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
    }
}