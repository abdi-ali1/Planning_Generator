using Logic;
using Logic.Companys;
using Logic.Companys.Request;
using Logic.Employee;
using Logic.Schedules;
using Logic.Schedules.Company;
using Logic.System.Generator.GeneraterHelp;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Planning_Generator.Models;
using System.Collections.Generic;
using System.Linq;

namespace Planning_Generator.Controllers
{
    public class CompanyController : Controller
    {
        public IActionResult RequestStaff(WeeklyNeed_M model)
        {
            if (model.CurrentWeek != 0)
            {

                Result<string> result;
                Company company = CurrentActive<Company>.Current;
                int index = Getindex(company.WeeklyNeed, model.CurrentWeek);
                if (index > -1)
                {
                  result =  company.WeeklyNeed[index].AddNeededStaff(new NeededStaff
                        (
                            model.Occupation,
                            new Logic.Shifts.Shift(model.DayOfWeek, model.KindOfShift),
                            model.DegreeLevel
                        ));
                }
                else
                {
                    IWeeklyNeed weeklyNeed = new WeeklyNeed(model.CurrentWeek);
                    company.AddWeeklyNeed(weeklyNeed);
                    result =  weeklyNeed.AddNeededStaff(new NeededStaff
                        (
                            model.Occupation,
                            new Logic.Shifts.Shift(model.DayOfWeek, model.KindOfShift),
                            model.DegreeLevel
                        ));
                }

                if (result.Success)
                {
                    CurrentActive<Company>.Current = company;
                    LogicRefecator.CompanyModelManager.SaveCompany(company);
                    LogicRefecator.CompanyModelManager.SaveCompanies();
                }

                SetResult<string>(result);
            }
           
            return View();
        }



        [HttpPost]
        public IActionResult GenereteShedules(int week)
        {
            Company company = CurrentActive<Company>.Current;
            Result<List<CompanySchedule>> result = LogicRefecator.ScheduleGenerator.CreateCompanySchedulesForWeek(company, week);
            Result<string> stringResult;

            if (result.Success)
            {
                stringResult = Result<string>.Ok("Created some schedules");
                SetResult<string>(stringResult);
                return RedirectToAction("Shedule", result.Value);
            }


            stringResult = Result<string>.Fail(result.Exception);
            SetResult<string>(stringResult);
            return Redirect("Shedule");
        }

        [HttpPost]
        public IActionResult SetSchedule(CompanySchedule companySchedule)
        {
            var company = CurrentActive<Company>.Current;
            company.AddSchedules(companySchedule);
            LogicRefecator.CompanyModelManager.SaveCompany(CurrentActive<Company>.Current);

            foreach (var info in companySchedule.CompanyScheduleInfos)
            {
                var manager = new StaffSchedueManager(info.StaffMember, companySchedule.CompanyScheduleInfos, companySchedule.CurrentWeek);
                var result = manager.SetStaffSchedule(company);
                if (result.Success)
                {
                    LogicRefecator.StaffMemberModelManager.SaveStaffMember(result.Value);
                }
            }

            LogicRefecator.CompanyModelManager.SaveCompanies();
            LogicRefecator.StaffMemberModelManager.SaveStaffMembers();

            return Redirect("Schedule");
        }

        public IActionResult Shedule(IList<Logic.Schedules.CompanySchedule> companySchedules)
        {
            
            return View(companySchedules);
        }

        private int Getindex(IList<IWeeklyNeed> values, int week)
        {
            int index = -1;  
            if (values.Count == 0)
            {
                return index;
            }
            for (int i = 0; i < values.Count; i++)
            {
                if (values[i].WeekNeeded == week)
                {
                    index = i;
                    break;
                }
            }

            return index;
        }

      
        public void SetResult<T>(Result<T> result)
        {
            if (result == null) return;

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
