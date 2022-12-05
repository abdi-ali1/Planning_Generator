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
    internal class MaxWorkRules : IWorkRule
    {
        private int maxWeeklyHour = 16;

        // TODO
        public bool IsRuleAdhered(StaffMember staff, DateTime week)
        {
            foreach (StaffSchedule staffSchedule in staff.Schedule)
            {
                if (staffSchedule.CurrentWeek == week)
                {
                    foreach (Shift shift in staffSchedule.AllShifts)
                    {

                    }


                }
            }


            return false;
        }



     
    }
}
