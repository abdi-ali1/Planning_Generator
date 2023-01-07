using Microsoft.AspNetCore.Mvc;
using Planning_Generator.Models;

namespace Planning_Generator.Controllers
{
    public class CompanyController : Controller
    {
        public IActionResult RequestStaff(AvailabilityStaff_M availabilityStaff_M)
        {




            return View();
        }

        public IActionResult Shedule()
        {
            return View();
        }
    }
}
