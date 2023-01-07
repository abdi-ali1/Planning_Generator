﻿using Logic;
using Logic.Companys;
using Logic.Employee;
using Logic.Employee.Degrees;
using Logic.Shifts.Availibiltiy;
using Microsoft.AspNetCore.Mvc;
using Planning_Generator.Models;

namespace Planning_Generator.Controllers
{
    public class StaffController : Controller
    {
        public IActionResult SendAvailibility(AvailabilityStaff_M availabilityStaff_M)
        {
            if (availabilityStaff_M.Company == null)
            {
               AvailabilityStaff availabilityStaff = new AvailabilityStaff
                    (
                    neededWeek: availabilityStaff_M.WeekAvailability,
                 
                   
                    )

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
