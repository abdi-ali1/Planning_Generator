using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Shifts;


namespace Logic.Schedules.Staff.formules
{
    [Serializable]
    internal static class WorkHour
    {
       public static float GetTotalWeekWorkingHour(List<Shift> shifts) 
       {
            float totalWeekWorkingHour =  shifts.Count *  8;
            return totalWeekWorkingHour;
       }
    }
}
