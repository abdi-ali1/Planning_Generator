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
        private readonly DateTime date;
        private readonly Shift newShift;

        public MaxWorkHours(IList<CompanyScheduleInfo> scheduleInfos, StaffMember staff, DateTime date, Shift newShift)
            : base(staff)
        {
            this.scheduleInfo = scheduleInfos;
            this.date = date;
            this.newShift = newShift;
        }

        /// <summary>
        /// Determines whether the rule is adhered.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if the rule is adhered; otherwise, <c>false</c>.
        /// </returns>
        public override bool IsRuleAdhered()
        {
            var result = StaffScheduleLooper.GetNeededStaffSchedule(staff, date);
            IList<Shift> companySchedeluShifts = GetScheduleShifts();
            if (result.Success)
            {
                return CanAddShift(result.Value.AllShifts) && CanAddShift(companySchedeluShifts);
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Determines whether a new shift can be added.
        /// </summary>
        /// <param name="shifts">The existing shifts.</param>
        /// <returns>
        ///   <c>true</c> if a new shift can be added; otherwise, <c>false</c>.
        /// </returns>
        private bool CanAddShift(IList<Shift> shifts)
        {
            // Check if there is a 16-hour gap between the new shift and each of the existing shifts
            return !shifts.Any(shift =>
            {
            if (shift.Day == newShift.Day)
            {
                // If the new shift and the existing shift are on the same day, check if there is a 16-hour gap between them
                int gap = ((int)newShift.KindOfShift - (int)shift.KindOfShift) * 8;
                return gap < 16;
            }
            else
            {
                    // If the new shift and the existing shift are on different days, check if there is
                    // a 16-hour gap between them accounting for the end of one day and the start of the next
                    int gap;
                    if (shift.Day == DayOfWeek.Friday && newShift.Day == DayOfWeek.Monday)
                    {
                        gap = 0;
                    }
                    else
                    {
                        gap = ((int)newShift.KindOfShift - (int)shift.KindOfShift + 2) * 8;
                    }
                    return gap < 16;
                }
            });
        }

        /// <summary>
        /// Gets the schedule shifts.
        /// </summary>
        /// <returns>The schedule shifts.</returns>
        private IList<Shift> GetScheduleShifts()
        {
            return scheduleInfo.Select(x => x.Shift).ToList();
        }
    }
}

