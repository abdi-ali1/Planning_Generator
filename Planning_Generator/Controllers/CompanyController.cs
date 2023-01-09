using Logic;
using Logic.Companys;
using Logic.Companys.Request;
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
        public IActionResult ViewSchedule(int week)
        {
            Company company = CurrentActive<Company>.Current;
            LogicRefecator.ScheduleGenerator.CreateCompanySchedulesForWeek(company, week);


            return Redirect("Shedule");
        }

        public IActionResult Shedule()
        {
            return View();
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
