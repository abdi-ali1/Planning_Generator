﻿using Logic;
using Logic.Companys;
using Logic.Employee;
using Logic.Employee.Degrees;
using Logic.Shifts;
using Logic.Shifts.Availibiltiy;
using Microsoft.AspNetCore.Mvc;
using Planning_Generator.Models;

namespace Planning_Generator.Controllers
{
    public class StaffController : Controller
    {
        public IActionResult SendAvailibility(AvailabilityStaff_M model)
        {
            if (model.WeekAvailability != 0)
            {
                Result<string> result;
                StaffMember staff = CurrentActive<StaffMember>.Current;
                int index = Getindex(staff.AvailabilityStaff, model.WeekAvailability);
                if (index > -1)
                {
                    result = staff.AvailabilityStaff[index].AddNewShift(
                        new Shift(model.DayOfWeek, model.KindOfShift)
                    );
                }
                else
                {
                    Result<Company> companyResult = LogicRefecator.CompanyModelManager.GetCompanyByName(model.Company_Name);
                    AvailabilityStaff availability = new AvailabilityStaff(
                        model.WeekAvailability,
                        companyResult.Value
                    );
                    result = availability.AddNewShift(
                        new Shift(model.DayOfWeek, model.KindOfShift)
                    );
                    staff.AddAvailibilty(availability);
                }

                if (result.Success)
                {
                    CurrentActive<StaffMember>.Current = staff;
                    LogicRefecator.StaffMemberModelManager.SaveStaffMember(staff);
                    LogicRefecator.StaffMemberModelManager.SaveStaffMembers();
                }

                SetResult<string>(result);
            }

            return View();
        }

        public IActionResult Shedule()
        {
            return View();
        }

        public IActionResult Signout()
        {
            CurrentActive<StaffMember>.Current = null;

            return RedirectToAction("Index", "Home");
        }

        public IActionResult AddStaff(StaffMemeber_M staffMemeber_M)
        {
            if (staffMemeber_M != null && staffMemeber_M.PropertiesAreNotNull())
            {
                StaffMember staffMember = new StaffMember(
                    username: staffMemeber_M.Username,
                    name: staffMemeber_M.Name,
                    gender: staffMemeber_M.Gender,
                    companyRole: staffMemeber_M.Role,
                    occupation: staffMemeber_M.Occaption,
                    birthDate: staffMemeber_M.BirthDate,
                    degree: new Degree(
                        staffMemeber_M.Degree_M.NameOfDegree,
                        staffMemeber_M.Degree_M.DegreeLevel
                    )
                );

                Result<string> result = LogicRefecator.StaffMemberModelManager.AddNewStaff(
                    staffMember
                );
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

        /// <summary>
        /// Retrieves the index of the element in the given list whose WeekAvailability
        /// property matches the specified week.
        /// </summary>
        /// <param name="values">The list to search.</param>
        /// <param name="week">The week to search for.</param>
        /// <returns>The index of the element with a matching WeekAvailability property,
        /// or -1 if no such element is found or the list is empty.</returns>
        private int Getindex(IList<AvailabilityStaff> values, int week)
        {
            int index = -1;
            if (values.Count == 0)
            {
                return index;
            }
            for (int i = 0; i < values.Count; i++)
            {
                if (values[i].WeekAvailability == week)
                {
                    index = i;
                    break;
                }
            }

            return index;
        }

        /// <summary>
        /// Sets the view data based on the success or failure of the given result.
        /// </summary>
        /// <typeparam name="T">The type of the result value.</typeparam>
        /// <param name="result">The result to process.</param>
        public void SetResult<T>(Result<T> result)
        {
            if (result == null)
                return;

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
    }
}
