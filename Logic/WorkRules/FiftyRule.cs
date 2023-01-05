using Logic.Employee;
using Logic.Schedules.Company;
using System.Reflection;
using System.Collections.Generic;
using Logic.System.Generator.GeneraterHelp;
using Logic.Schedules.Staff;

namespace Logic.WorkRules
{
    public class FiftyRule : WorkRule
    {
        private readonly IList<CompanyScheduleInfo> scheduleInfo;
        private readonly DateTime date;

        public FiftyRule(IList<CompanyScheduleInfo> scheduleInfo, StaffMember staff, DateTime date):base(staff)
        {
            this.scheduleInfo = scheduleInfo;
            this.date = date;
         
        }

        public override bool IsRuleAdhered()
        {
            // Check if the staff member's age is greater than 50
       
            if (staff.Age > 50)
            {
                return false;
            }

            // Check if the number of CompanyScheduleInfo objects in the scheduleInfo list is greater than 2
            if (scheduleInfo.Count > 2)
            {
                // Check if the weekly hours for the staff member are higher than 16
                if (WeeklyHourHigherThan16())
                {
                    return false;
                }
            }

            return true;
        }

        protected override bool WeeklyHourHigherThan16()
        {
            Result<StaffSchedule> result = StaffScheduleLooper.GetNeededStaffSchedule(staff, date);
            if (result.Success && result.Exception != null && result.Value.TotalWorkingHours > 16)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }


}

