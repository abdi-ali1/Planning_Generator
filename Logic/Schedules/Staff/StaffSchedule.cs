using Logic.Schedules.Staff.formules;
using Logic.Shifts;

namespace Logic.Schedules.Staff
{
    [Serializable]
    public class StaffSchedule
    {
        // fields
        private int currentWeek;
        private List<Shift> shifts = new List<Shift>();
        private Companys.Company company;

        // properties
        public int CurrentWeek
        {
            get { return currentWeek; }
        }
        public IList<Shift> Shifts
        {
            get { return shifts.AsReadOnly(); }
        }
        public float TotalWorkingHours
        {
            get { return WorkHour.GetTotalWeekWorkingHour(shifts); }
        }
        public Companys.Company Company
        {
            get { return company; }
        }

        public StaffSchedule(int currentWeek, Companys.Company company)
        {
            this.currentWeek = currentWeek;
            this.company = company;
        }

        /// <summary>
        /// Adds a new shift to the list of shifts.
        /// </summary>
        /// <param name="shift">The shift to add to the list.</param>
        /// <returns>A Result object indicating the success or failure of the operation, and any error message if applicable.</returns>
        public Result<string> AddNewShift(Shift shift)
        {
            try
            {
                if (!shifts.Any(x => x.Equals(shift)))
                {
                    shifts.Add(shift);
                    return Result<string>.Ok("added to the list");
                }

                return Result<string>.Fail(new Exception("already exists"));
            }
            catch (Exception e)
            {
                return Result<string>.Fail(e);
            }
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>True if the specified object is equal to the current object, otherwise false.</returns>
        public override bool Equals(object? obj)
        {
            if (obj == null || !GetType().Equals(obj.GetType()))
            {
                return false;
            }

            StaffSchedule staffSchedule = (StaffSchedule)obj;

            return staffSchedule.company.Equals(company) && staffSchedule.CurrentWeek == currentWeek;
        }
    }
}
