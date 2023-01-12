using Logic.Companys;

namespace Logic.Shifts.Availibiltiy
{
    [Serializable]
    public class AvailabilityStaff
    {
        // fields
        private int weekAvailability;
        private Company company;
        private List<Shift> shifts = new List<Shift>();

        // properties
        public int WeekAvailability
        {
            get { return weekAvailability; }
        }
        public Company Company
        {
            get { return company; }
        }
        public IList<Shift> Shifts
        {
            get { return shifts.AsReadOnly(); }
        }

        public AvailabilityStaff(int neededWeek, Company company)
        {
            weekAvailability = neededWeek;
            this.company = company;
        }

        public AvailabilityStaff(int neededWeek, Company company, List<Shift> shifts)
            : this(neededWeek, company)
        {
            this.shifts = shifts;
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
                    return Result<string>.Ok("Added to the list");
                }

                return Result<string>.Fail(new Exception("shift already exists"));
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

            AvailabilityStaff availibiltyStaff = (AvailabilityStaff)obj;

            return availibiltyStaff.WeekAvailability == weekAvailability;
        }
    }
}
