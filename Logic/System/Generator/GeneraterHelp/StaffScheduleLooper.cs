using Logic.Employee;
using Logic.Schedules.Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.System.Generator.GeneraterHelp
{
    public class StaffScheduleLooper
    {
        public static Result<StaffSchedule> GetNeededStaffSchedule(StaffMember staff, DateTime date)
        {
            try
            {
                StaffSchedule? currentSchedule = staff.Schedule.First(x => x.CurrentWeek == date);

                if (currentSchedule == null)
                {
                    // Return an Ok result with a null value when there is no schedule for the specified date
                    return Result<StaffSchedule>.Ok(null);
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
