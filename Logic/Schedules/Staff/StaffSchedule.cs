using Logic.Employee;
using Logic.Schedules.Staff.formules;
using Logic.Shifts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Companys;

namespace Logic.Schedules.Staff
{
    [Serializable]
    public class StaffSchedule
    {
        // fields
        private DateTime currentWeek;
        private List<Shift> allShifts = new List<Shift>();
        private Company company;


        // properties
        public DateTime CurrentWeek { get { return currentWeek; } }
        public IList<Shift> AllShifts { get { return allShifts.AsReadOnly(); } }
        public float TotalWorkingHours { get { return  WorkHour.GetTotalWeekWorkingHour(allShifts); } }
        private Company Company { get { return company; } }

        public StaffSchedule(DateTime currentWeek, Company company)
        {
            this.currentWeek = currentWeek;
            this.company = company;
        }


        /*   public StaffSchedule(DateTime currentWeek, List<Shift> allShifts, Company company):this(currentWeek, company)
           {
               this.allShifts = allShifts;

           }*/


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
