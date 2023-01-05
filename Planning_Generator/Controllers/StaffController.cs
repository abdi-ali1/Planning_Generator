using Logic.Companys;
using Logic.Employee;
using Logic.Employee.Degrees;
using Microsoft.AspNetCore.Mvc;

namespace Planning_Generator.Controllers
{
    public class StaffController : Controller
    {
        public IActionResult SendAvailibility()
        {
            return View();
        }

        public IActionResult Shedule()
        {
            return View();
        }

        public IActionResult AddCompany(FormCollection data)
        {
                
            return View();
        }

        public IActionResult AddStaff()
        {
           

  
            return View();
        }

        [HttpPost]
        public IActionResult AddStaff(IFormCollection collection)
        {
           /* Degree degree = new Degree(nameOfDegree, int.Parse(levelOfDegree));
            StaffMember staff = new StaffMember(userNameOfStaff, nameOfStaff, (Logic.Enum.Gender)int.Parse(gender),
               (Logic.Enum.CompanyRole)int.Parse(companyRole), (Logic.Enum.Occaption)int.Parse(occupation),
                DateTime.Parse(birthDate), degree);*/

           
            return View();
        }

    }
}
