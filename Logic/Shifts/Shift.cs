using Logic.Enum;
using DayOfWeek = Logic.Enum.DayOfWeek;

namespace Logic.Shifts
{
    [Serializable]
    public class Shift
    {
        private DayOfWeek dayOfWeek;
        private ShiftHour shiftHour;

        public DayOfWeek DayOfWeek
        {
            get { return dayOfWeek; }
        }
        public ShiftHour ShiftHour
        {
            get { return shiftHour; }
        }

        public Shift(DayOfWeek dayOfWeek, ShiftHour shiftHour)
        {
            this.dayOfWeek = dayOfWeek;
            this.shiftHour = shiftHour;
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>True if the specified object is equal to the current object, otherwise false.</returns>
        public override bool Equals(object obj)
        {
            if (obj == null || !GetType().Equals(obj.GetType()))
            {
                return false;
            }

            Shift shift = (Shift)obj;
            return (dayOfWeek == shift.DayOfWeek) && (shiftHour == shift.ShiftHour);
        }
    }
}
