using Logic.Enum;
using DayOfWeek = Logic.Enum.DayOfWeek;

namespace Planning_Generator.Models
{
    public class WeeklyNeed_M
    {
        public int CurrentWeek { get; set; }
        public Occupation Occupation { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public ShiftHour KindOfShift { get; set; }
        public int DegreeLevel { get; set; }
    }
}
