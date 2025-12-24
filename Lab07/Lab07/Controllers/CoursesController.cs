using Microsoft.AspNetCore.Mvc;

namespace Lab07.Controllers
{
    public class CoursesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

