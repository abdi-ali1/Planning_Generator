using Logic.Shifts;

namespace Logic.Schedules.Staff.formules
{
    internal class WorkHour
    {
        /// <summary>
        /// Gets the total number of working hours for a week based on a list of shifts.
        /// </summary>
        /// <param name="shifts">A List of Shift objects representing the shifts worked in a week.</param>
        /// <returns>A float value representing the total number of working hours in a week.</returns>
        public static float GetTotalWeekWorkingHour(List<Shift> shifts)
        {
            float totalWeekWorkingHour = shifts.Count * 8;
            return totalWeekWorkingHour;
        }
    }
}
