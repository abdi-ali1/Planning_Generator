using System.Globalization;

namespace Logic
{
    internal class WeekManager
    {
        /// <summary>
        /// Gets the week of the year from the given date.
        /// </summary>
        /// <param name="dateTime">The date to get the week of the year from.</param>
        /// <returns>The week of the year for the given date.</returns>
        public static int GetWeekFromDate(DateTime dateTime)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture("nl-NL");
            return culture.Calendar.GetWeekOfYear(
                dateTime,
                CalendarWeekRule.FirstFourDayWeek,
                DayOfWeek.Monday
            );
        }
    }
}
