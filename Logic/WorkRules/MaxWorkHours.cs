using Logic.Employee;
using Logic.Schedules.Company;
using Logic.Schedules.Staff;
using Logic.Shifts;
using Logic.System.Generator.GeneraterHelp;
using System.Runtime.CompilerServices;
using DayOfWeek = Logic.Enum.DayOfWeek;

[assembly: InternalsVisibleTo("UnitTest_Pl")]
namespace Logic.WorkRules
{
 
    internal class MaxWorkHours : WorkRule
    {
        private readonly IList<CompanyScheduleInfo> scheduleInfo;
        private readonly int week;
        private readonly Shift newShift;

        public MaxWorkHours(IList<CompanyScheduleInfo> scheduleInfos, StaffMember staff, int week, Shift newShift) : base(staff)
        {
            scheduleInfo = scheduleInfos;
            this.week = week;
            this.newShift = newShift;
        }

        public override bool IsRuleAdhered()
        {
            Result<StaffSchedule> resultStaffSchedule = StaffScheduleLooper.GetNeededStaffSchedule(staffMember, week);
            Result<IList<Shift>> companyScheduledShifts = GetScheduleShifts();

            if (resultStaffSchedule.Success)
            {
                if (companyScheduledShifts.Success)
                {
                    return CanAddShift(resultStaffSchedule.Value.Shifts)
                        && CanAddShift(companyScheduledShifts.Value);
                }

                return CanAddShift(resultStaffSchedule.Value.Shifts);
            }
            else if (resultStaffSchedule.Value == null)
            {
                if (companyScheduledShifts.Success)
                {
                    return CanAddShift(companyScheduledShifts.Value);
                }
            }

            return true;
        }

        /// <summary>
        /// Determines if a new shift can be added to a list of existing shifts.
        /// </summary>
        /// <param name="shifts">The list of existing shifts.</param>
        /// <returns>True if the new shift can be added, otherwise false.</returns>
        private bool CanAddShift(IList<Shift> shifts)
        {
            // Check if there is a 16-hour gap between the new shift and each of the existing shifts
            return !shifts.Any(
                shift =>
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
                        if (
                            shift.DayOfWeek == DayOfWeek.Friday
                            && newShift.DayOfWeek == DayOfWeek.Monday
                        )
                        {
                            gap = 0;
                        }
                        else
                        {
                            gap = ((int)newShift.ShiftHour - (int)shift.ShiftHour + 2) * 8;
                        }
                        return gap < 16;
                    }
                }
            );
        }

        /// <summary>
        /// Gets the shifts for the current company schedule.
        /// </summary>
        /// <returns>The list of shifts for the current company schedule.</returns>
        private Result<IList<Shift>> GetScheduleShifts()
        {
            IList<Shift> scheduleInfoList = new List<Shift>();

            foreach (CompanyScheduleInfo info in scheduleInfo)
            {
                if (info.StaffMember.Equals(staffMember))
                {
                    scheduleInfoList.Add(info.Shift);
                }
            }

            if (scheduleInfoList.Count > 0)
            {
                return Result<IList<Shift>>.Ok(scheduleInfoList);
            }
            return Result<IList<Shift>>.Fail(new Exception("doesnt have any in list"));
        }
    }
}
