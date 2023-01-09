using Logic.Employee;
using Logic.Schedules.Company;
using Logic.Shifts;
using Logic.System.Generator.GeneraterHelp;
using DayOfWeek = Logic.Enum.DayOfWeek;

namespace Logic.WorkRules
{
    internal class MaxWorkHours : WorkRule
    {
        private readonly IList<CompanyScheduleInfo> scheduleInfo;
        private readonly int week;
        private readonly Shift newShift;

        public MaxWorkHours(IList<CompanyScheduleInfo> scheduleInfos, StaffMember staff, int  week, Shift newShift)
            : base(staff)
        {
            this.scheduleInfo = scheduleInfos;
            this.week = week;
            this.newShift = newShift;
        }

        /// <summary>
        /// Determines if a staff member adheres to the shift work rule.
        /// </summary>
        /// <returns>True if the staff member adheres to the rule, otherwise false.</returns>
        public override bool IsRuleAdhered()
        {
            var result = StaffScheduleLooper.GetNeededStaffSchedule(staffMember, week);
            IList<Shift> companySchedeluShifts = GetScheduleShifts();
            if (result.Success)
            {
                return CanAddShift(result.Value.Shifts) && CanAddShift(companySchedeluShifts);
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Determines if a new shift can be added to a list of existing shifts.
        /// </summary>
        /// <param name="shifts">The list of existing shifts.</param>
        /// <returns>True if the new shift can be added, otherwise false.</returns>
        private bool CanAddShift(IList<Shift> shifts)
        {
            // Check if there is a 16-hour gap between the new shift and each of the existing shifts
            return !shifts.Any(shift =>
            {
                if (shift.DayOfWeek == newShift.DayOfWeek)
                {
                    // If the new shift and the existing shift are on the same day, check if there is a 16-hour gap between them
                    int gap = ((int)newShift.ShiftHour - (int)shift.ShiftHour) * 8;
                    return gap < 16;
                }
                else
                {
                    // If the new shift and the existing shift are on different days, check if there is
                    // a 16-hour gap between them accounting for the end of one day and the start of the next
                    int gap;
                    if (shift.DayOfWeek == DayOfWeek.Friday && newShift.DayOfWeek == DayOfWeek.Monday)
                    {
                        gap = 0;
                    }
                    else
                    {
                        gap = ((int)newShift.ShiftHour - (int)shift.ShiftHour + 2) * 8;
                    }
                    return gap < 16;
                }
            });
        }

        /// <summary>
        /// Gets the shifts for the current company schedule.
        /// </summary>
        /// <returns>The list of shifts for the current company schedule.</returns>
        private IList<Shift> GetScheduleShifts()
        {
            return scheduleInfo.Select(x => x.Shift).ToList();
        }
    }
}