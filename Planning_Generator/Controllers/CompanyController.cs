using Microsoft.AspNetCore.Mvc;

namespace Planning_Generator.Controllers
{
    public class CompanyController : Controller
    {
        public IActionResult RequestStaff()
        {
            return View();
        }

        public IActionResult Shedule()
        {
            return View();
        }
    }
}
