using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    internal class WeekManager
    {


        public static int GetWeekFromDate(DateTime dateTime)
        {
          
            CultureInfo culture = CultureInfo.CreateSpecificCulture("nl-NL");
             return  culture.Calendar.GetWeekOfYear(dateTime, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }
    }
}
