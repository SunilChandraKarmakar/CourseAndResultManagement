using System.Web.Mvc;

namespace CourseAndResultMS.Controllers
{
    public class RegisterStudentController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}
