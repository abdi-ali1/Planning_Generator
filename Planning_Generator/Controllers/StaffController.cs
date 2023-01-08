using Logic;
using Logic.Companys;
using Logic.Employee;
using Logic.Employee.Degrees;
using Logic.Enum;
using Logic.Shifts;
using Logic.Shifts.Availibiltiy;
using Microsoft.AspNetCore.Mvc;
using Planning_Generator.Models;
using DayOfWeek = Logic.Enum.DayOfWeek;

namespace Planning_Generator.Controllers
{
    public class StaffController : Controller
    {
      
        public IActionResult SendAvailibility(AvailabilityStaff_M model)
        {
            if (ModelState.IsValid)
            {
                var company = LogicRefecator.CompanyModelManager.Companies.FirstOrDefault(x => x.Name == model.Company_Name);
                var shifts = new List<Shift>();

                foreach (DayOfWeek day in Enum.GetValues(typeof(DayOfWeek)))
                {
                    if (!string.IsNullOrEmpty(model.GetType().GetProperty("DayOfWeek" + day)?.GetValue(model)?.ToString()))
                    {
                        var shiftHour = (ShiftHour)Enum.Parse(typeof(ShiftHour), model.GetType().GetProperty("KindOfShift" + day)?.GetValue(model)?.ToString());
                        shifts.Add(new Shift(day, shiftHour));
                    }
                }

                var availabilityStaff = new AvailabilityStaff(model.WeekAvailability, company, shifts);

                // do something with the availabilityStaff object
                // ...

                return RedirectToAction("Success");
            }

            return View(model);
        }

        public IActionResult Shedule()
        {
            return View();
        }


        public IActionResult AddStaff(StaffMemeber_M staffMemeber_M)
        {
            if (staffMemeber_M != null && staffMemeber_M.PropertiesAreNotNull())
            {
                StaffMember staffMember = new StaffMember
                (
                    username: staffMemeber_M.Username,
                    name: staffMemeber_M.Name,
                    gender: staffMemeber_M.Gender,
                    companyRole: staffMemeber_M.Role,
                    occupation: staffMemeber_M.Occaption,
                    birthDate: staffMemeber_M.BirthDate,
                    degree: new Degree(staffMemeber_M.Degree_M.NameOfDegree, staffMemeber_M.Degree_M.DegreeLevel)
                );

                Result<string> result = LogicRefecator.StaffMemberModelManager.AddNewStaff(staffMember);
                if (result.Success)
                {
                    ViewData["Message"] = result.Value;
                    ViewData["MessageType"] = "success";
                }
                else
                {
                    if (result.IsExceptionType<Exception>())
                    {
                        ViewData["Message"] = result.Exception.Message;
                    }
                    else
                    {
                        ViewData["Message"] = "something went wrong try again!";
                    }
                    ViewData["MessageType"] = "danger";
                }
            }
         
            return View();
        }


        public IActionResult AddCompany(Company_M company_M)
        {
            Result<string> result;
            if (company_M.Name != null)
            {
                Company company = new Company(company_M.Name);
                result = LogicRefecator.CompanyModelManager.AddNewCompany(company);
    
                
                if (result.Success)
                {
                    ViewData["Message"] = result.Value;
                    ViewData["MessageType"] = "success"; 
                }
                else
                {
                    if (result.IsExceptionType<Exception>())
                    {
                        ViewData["Message"] = result.Exception.Message;
                    }
                    else
                    {
                        ViewData["Message"] = "something went wrong try again!";
                    }
                    ViewData["MessageType"] = "danger";
                }
            }
            return View();
        }
    }
}
