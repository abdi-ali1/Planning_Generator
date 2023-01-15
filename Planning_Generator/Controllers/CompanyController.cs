using Logic;
using Logic.Companys;
using Logic.Companys.Request;
using Logic.Employee;
using Logic.Schedules;
using Logic.System.Generator.GeneraterHelp;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Planning_Generator.Models;

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
                    result = company.WeeklyNeed[index].AddNeededStaff(
                        new NeededStaff(model.Occupation, new Logic.Shifts.Shift(model.DayOfWeek, model.KindOfShift), model.DegreeLevel)
                    );
                }
                else
                {
                    IWeeklyNeed weeklyNeed = new WeeklyNeed(model.CurrentWeek);
                    company.AddWeeklyNeed(weeklyNeed);
                    result = weeklyNeed.AddNeededStaff(
                        new NeededStaff(model.Occupation, new Logic.Shifts.Shift(model.DayOfWeek, model.KindOfShift), model.DegreeLevel)
                    );
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

        public IActionResult Signout()
        {
            CurrentActive<Company>.Current = null;

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult ExampleSchedules(int week)
        {
            Company company = CurrentActive<Company>.Current;
            Result<IList<CompanySchedule>> result = LogicRefecator.ScheduleGenerator.CreateCompanySchedulesForWeek(company, week);
            Result<string> stringResult;

            if (result.Success)
            {
                stringResult = Result<string>.Ok("Created some schedules");
                SetResult<string>(stringResult);
                return View(result.Value);
            }

            stringResult = Result<string>.Fail(result.Exception);
             SetResult<string>(stringResult);
            return View();
        }

        [HttpPost]
        public IActionResult SetSchedule()
        {
            CompanySchedule schedule = @CompanyScheduleUi.Schedule;
            Company company = CurrentActive<Company>.Current;
            company.AddSchedules(schedule);
            LogicRefecator.CompanyModelManager.SaveCompany(CurrentActive<Company>.Current);

            foreach (var info in schedule.CompanyScheduleInfos)
            {
                StaffSchedueManager manager = new StaffSchedueManager(info.StaffMember, schedule.CompanyScheduleInfos, schedule.CurrentWeek);
                Result<StaffMember> result = manager.SetStaffSchedule(company);
                if (result.Success)
                {
                    LogicRefecator.StaffMemberModelManager.SaveStaffMember(result.Value);
                }
            }

            LogicRefecator.CompanyModelManager.SaveCompanies();
            LogicRefecator.StaffMemberModelManager.SaveStaffMembers();

            return View("Shedule");
        }

        public IActionResult Shedule(IList<CompanySchedule> companySchedules, List<string> viewdataList = null)
        {
            if (viewdataList != null && viewdataList.Count == 2)
            {
                ViewData["Message"] = viewdataList[0];
                ViewData["MessageType"] = viewdataList[1];
            }

            return View(companySchedules);
        }

        /// <summary>
        /// Gets the index of the element with the specified week value in the specified list.
        /// </summary>
        /// <param name="values">The list to search in.</param>
        /// <param name="week">The week value to search for.</param>
        /// <returns>The index of the element with the specified week value, or -1 if the element is not found.</returns>
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
