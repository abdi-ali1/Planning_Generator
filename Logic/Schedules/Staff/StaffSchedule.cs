using Logic.Employee;
using Logic.Schedules.Staff.formules;
using Logic.Shifts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Schedules.Staff
{
    [Serializable]
    public class StaffSchedule
    {
        // fields
        private DateTime currentWeek;
        private List<Shift> allShifts = new();

        // properties
        public DateTime CurrentWeek { get { return currentWeek; } }
        public IList<Shift> AllShifts { get { return allShifts.AsReadOnly(); } }
        public float TotalWorkingHours { get { return  WorkHour.GetTotalWeekWorkingHour(allShifts); } }

        public StaffSchedule(DateTime currentWeek)
        {
            this.currentWeek = currentWeek;
        }

        public StaffSchedule(DateTime currentWeek, List<Shift> allShifts) : this(currentWeek)
        {
            this.allShifts = allShifts;
        }

        public bool AddNewShift(Shift shift)
        {
            bool doesntExist = true;
            foreach (Shift s in AllShifts)
            {
                if (s.Equals(shift))
                {
                    doesntExist = false;
                    break;
                }
            }
            if (doesntExist) allShifts.Add(shift);

            return doesntExist;
        }

    

    }
}
