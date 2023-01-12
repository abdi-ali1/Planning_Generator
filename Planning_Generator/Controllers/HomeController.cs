using Logic;
using Logic.Companys;
using Logic.Employee;
using Microsoft.AspNetCore.Mvc;
using Planning_Generator.Models;

namespace Planning_Generator.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(Login_M model)
        {
            return View(model);
        }

        [HttpPost]
        public IActionResult Login(Login_M model)
        {
            Result<StaffMember> staffMemberResult = LogicRefecator.Authentication.AuthenticateCurrentStaffMember(model.Username);
            if (staffMemberResult.Success)
            {
                model.IsAuthenticated = true;
                model.AuthenticatedStaffMember = staffMemberResult.Value;
                CurrentActive<StaffMember>.Current = model.AuthenticatedStaffMember;
                Console.WriteLine(model.AuthenticatedStaffMember.Name);
            }
            else
            {
                Result<Company> companyResult = LogicRefecator.Authentication.AuthenticateCurrentCompany(model.Username);
                if (companyResult.Success)
                {
                    model.IsAuthenticated = true;
                    model.AuthenticatedCompany = companyResult.Value;

                    CurrentActive<Company>.Current = model.AuthenticatedCompany;
                }
            }
            return RedirectToAction("Index", model);
        }
    }
}
