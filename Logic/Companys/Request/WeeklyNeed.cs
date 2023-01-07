namespace Logic.Companys.Request
{
    [Serializable]
    public class WeeklyNeed : IWeeklyNeed
    {
        // fields
        private DateTime weekNeeded;
        private List<NeededStaff> neededStaff = new List<NeededStaff>();

        // properties
        public DateTime WeekNeeded { get { return weekNeeded; } }
        public IList<NeededStaff> NeededStaff { get { return neededStaff.AsReadOnly(); } }

        // constructors
        public WeeklyNeed(DateTime weekNeeded, List<NeededStaff> neededStaff)
        {
            this.weekNeeded = weekNeeded;
            this.neededStaff = neededStaff;
        }

        /// <summary>
        /// Adds a needed staff member to the list of needed staff members.
        /// </summary>
        /// <param name="needed">The needed staff member to add to the list.</param>
        /// <returns>A Result object indicating the success or failure of the operation, and any error message if applicable.</returns>
        public Result<string> AddNeededStaff(NeededStaff needed)
        {
            try
            {
                if (needed == null)
                {
                    return Result<string>.Fail(new Exception("given object was null"));
                }

                neededStaff.Add(needed);
                return Result<string>.Ok("is added to the list");
            }
            catch (Exception e)
            {
                return Result<string>.Fail(e);
            }
        }
    }
}
