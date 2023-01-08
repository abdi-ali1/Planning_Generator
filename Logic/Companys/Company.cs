using Logic.Companys.Request;
using Logic.Schedules;

namespace Logic.Companys
{
    [Serializable]
    public class Company
    {
        private string name;
        private List<CompanySchedule> companySchedules = new List<CompanySchedule>();
        private List<IWeeklyNeed> weeklyNeed = new List<IWeeklyNeed>();

        public string Name { get { return name; } }
        public IList<CompanySchedule> Schedules { get { return companySchedules.AsReadOnly(); } }
        public IList<IWeeklyNeed> WeeklyNeed { get { return weeklyNeed.AsReadOnly(); } }

        public Company(string name)
        {
            this.name = name;
            companySchedules = new List<CompanySchedule>();
            weeklyNeed = new List<IWeeklyNeed>();
        }

        /// <summary>
        /// Adds a schedule to the list of schedules.
        /// </summary>
        /// <param name="schedule">The schedule to add to the list.</param>
        /// <returns>A Result object indicating the success or failure of the operation, and any error message if applicable.</returns>
        public Result<string> AddSchedules(CompanySchedule schedule)
        {
            try
            {
                if (!companySchedules.Any(x => x.CurrentWeek == schedule.CurrentWeek))
                {
                    companySchedules.Add(schedule);
                    return Result<string>.Ok("is added to list");
                }
                else
                {
                    return Result<string>.Fail(new Exception("schedule already exists for this week"));
                }
            }
            catch (Exception e)
            {
                return Result<string>.Fail(e);
            }
        }

        /// <summary>
        /// Adds a weekly need to the list of weekly needs.
        /// </summary>
        /// <param name="weekly">The weekly need to add to the list.</param>
        /// <returns>A Result object indicating the success or failure of the operation, and any error message if applicable.</returns>
        public Result<string> AddWeeklyNeed(IWeeklyNeed weekly)
        {
            try
            {
                if (!weeklyNeed.Any(x => x.WeekNeeded == weekly.WeekNeeded))
                {
                    weeklyNeed.Add(weekly);
                    return Result<string>.Ok("is added to list");
                }
                else
                {
                    return Result<string>.Fail(new Exception("weekly need already exists for this week"));
                }
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

            Company company = (Company)obj;
            return (name == company.name);
        }
    }
}
