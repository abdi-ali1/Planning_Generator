using Logic.Companys;
using Logic.Enum;
using Logic.Shifts;
using DayOfWeek = Logic.Enum.DayOfWeek;

namespace Planning_Generator.Models
{
    public class AvailabilityStaff_M
    {
        public int WeekAvailability { get; set; }
        public string Company_Name { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public ShiftHour KindOfShift { get; set; }
    


    }

}
