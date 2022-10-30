using Logic.Schedules.Staff.formules;
using Logic.Shifts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Schedules.Staff
{
    public class StaffSchedule
    {
        // fields
        private DateTime currentWeek;
        private List<Shift> allShifts = new();

        // properties
        public DateTime CurrentWeek { get { return currentWeek; } }
        public IList<Shift> AllShifts { get { return allShifts.AsReadOnly(); } }
        public float TotalWorkingHours { get { return new WorkHour().GetTotalWeekWorkingHour(allShifts); } }

        public StaffSchedule(DateTime currentWeek, List<Shift> shifts)
        {
            this.currentWeek = currentWeek;
            this.allShifts = shifts;
        }

        public StaffSchedule(DateTime currentWeek, Shift shift)
        {
            this.currentWeek = currentWeek;
            allShifts.Add(shift);
        }

    }
}
