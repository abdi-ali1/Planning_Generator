using Logic.Employee;
using Logic.Schedules.Company;
using Logic.System.Generator.GeneraterHelp;
using Logic.Schedules.Staff;

namespace Logic.WorkRules
{
    public class FiftyRule : WorkRule
    {
        private readonly IList<CompanyScheduleInfo> companyScheduleInfos;
        private readonly int week;

        public FiftyRule(IList<CompanyScheduleInfo> companyScheduleInfos, StaffMember staffMember, int date) : base(staffMember)
        {
            this.companyScheduleInfos = companyScheduleInfos;
            week = date;
        }

        /// <summary>
        /// Determines if a staff member adheres to the age and weekly hours work rule.
        /// </summary>
        /// <returns>True if the staff member adheres to the rule, otherwise false.</returns>
        public override bool IsRuleAdhered()
        {
            // Check if the staff member's age is greater than 50
            if (staffMember.Age < 50)
            {
                return true;
            }

            // Check if the number of CompanyScheduleInfo objects in the scheduleInfo list is greater than 2
            if (companyScheduleInfos.Count > 2)
            {
                return false;
            }

            // Check if the weekly hours for the staff member are higher than 16
            if (WeeklyHourHigherThan16())
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Determines if the weekly hours for a staff member are higher than 16.
        /// </summary>
        /// <returns>True if the weekly hours are higher than 16, otherwise false.</returns>
        private bool WeeklyHourHigherThan16()
        {
            Result<StaffSchedule> scheduleResult = StaffScheduleLooper.GetNeededStaffSchedule(staffMember,week);
            return scheduleResult.Success && scheduleResult.Value.TotalWorkingHours > 16;
        }
    }
}
