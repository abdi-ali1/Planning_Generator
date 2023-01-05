using System.Collections.Generic;
using System.Linq;
using System;
using Logic.Employee;
using Logic.Schedules.Company;
using Logic.System.Generator.GeneraterHelp;
using Logic.Schedules.Staff;

namespace Logic.WorkRules
{
    public class FiftyRule : WorkRule
    {
        private readonly IList<CompanyScheduleInfo> scheduleInfo;
        private readonly DateTime date;

        public FiftyRule(IList<CompanyScheduleInfo> scheduleInfo, StaffMember staff, DateTime date)
            : base(staff)
        {
            this.scheduleInfo = scheduleInfo;
            this.date = date;
        }

        /// <summary>
        /// Determines whether the rule is adhered.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if the rule is adhered; otherwise, <c>false</c>.
        /// </returns>
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

        /// <summary>
        /// Determines whether the weekly hours for the staff member are higher than 16.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if the weekly hours for the staff member are higher than 16; otherwise, <c>false</c>.
        /// </returns>
        private bool WeeklyHourHigherThan16()
        {
            Result<StaffSchedule> scheduleResult = StaffScheduleLooper.GetNeededStaffSchedule(staff, date);
            return scheduleResult.Success && scheduleResult.Value.TotalWorkingHours > 16;
        }
    }
}
