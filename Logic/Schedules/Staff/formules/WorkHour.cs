using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Shifts;


namespace Logic.Schedules.Staff.formules
{
    internal class WorkHour
    {
       public float GetTotalWeekWorkingHour(List<Shift> shifts) 
       {
            float totalWeekWorkingHour =  shifts.Count *  8;
            return totalWeekWorkingHour;
       }
    }
}
