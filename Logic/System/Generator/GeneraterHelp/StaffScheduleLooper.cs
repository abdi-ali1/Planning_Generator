﻿using Logic.Employee;
using Logic.Schedules.Staff;

namespace Logic.System.Generator.GeneraterHelp
{
    public class StaffScheduleLooper
    {
        /// <summary>
        /// Gets the schedule for a given staff member on a given date.
        /// </summary>
        /// <param name="staff">The staff member to get the schedule for.</param>
        /// <param name="week">The date to get the schedule for.</param>
        /// <returns>A result object containing either the schedule for the given staff member on the given date, or an exception if there was an error.</returns>
        public static Result<StaffSchedule> GetNeededStaffSchedule(StaffMember staff, int week)
        {
            try
            {
                StaffSchedule? currentSchedule = staff.StaffSchedule.First(x => x.CurrentWeek == week);

                if (currentSchedule == null)
                {
                    // Return an Fail result with a null value when there is no schedule for the specified date
                    return Result<StaffSchedule>.Fail(
                        new Exception("there are no schedule on this week")
                    );
                }

                // Return an Ok result with the current schedule when it is found
                return Result<StaffSchedule>.Ok(currentSchedule);
            }
            catch (Exception e)
            {
                // Return a Fail result when an exception occurs
                return Result<StaffSchedule>.Fail(e);
            }
        }
    }
}
