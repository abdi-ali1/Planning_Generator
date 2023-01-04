using Logic.Companys.Request;
using Logic.Employee;
using Logic.Schedules.Staff;
using Logic.Shifts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.WorkRules
{
    internal class MaxWorkHours : IWorkRule
    {
        private DateTime weekNeeded;
        private Shift latestShift;
        private NeededStaff neededStaff;

        public MaxWorkHours(DateTime weekNeeded, Shift latestShift, NeededStaff neededStaff)
        {
            this.weekNeeded = weekNeeded;
            this.latestShift = latestShift;
            this.neededStaff = neededStaff;
        }


        public bool IsRuleAdhered(StaffMember staff)
        {
            StaffSchedule staffSchedule = staff.Schedule.First(x => x.CurrentWeek == weekNeeded);

            if (staffSchedule == null)
            {
                return false;
            }

           

        }
    }
}
