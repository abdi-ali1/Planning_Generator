using System.Xml.Linq;

namespace Logic.Companys.Request
{
    [Serializable]
    public class WeeklyNeed : IWeeklyNeed
    {
        // fields
        private int weekNeeded;
        private List<NeededStaff> neededStaff = new List<NeededStaff>();

        // properties
        public int WeekNeeded { get { return weekNeeded; } }
        public IList<NeededStaff> NeededStaff { get { return neededStaff.AsReadOnly(); } }

        public WeeklyNeed(int weekNeeded)
        {
            this.weekNeeded = weekNeeded;
        }


        // constructors
        public WeeklyNeed(int weekNeeded, List<NeededStaff> neededStaff):this(weekNeeded)
        {
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



        public override bool Equals(object? obj)
        {
            if (obj == null || !GetType().Equals(obj.GetType()))
            {
                return false;
            }

            WeeklyNeed weeklyNeed = (WeeklyNeed)obj;
            return (weeklyNeed.weekNeeded == weekNeeded);
        }
    }
}
