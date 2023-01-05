using Logic.Companys.Request;
using Logic.Schedules;


namespace Logic.Companys
{
    [Serializable]
    public class Company
    {
       
        private string name;
        private List<CompanySchedule> schedules = new List<CompanySchedule>();
        private List<IWeeklyNeed> weeklyNeed = new List<IWeeklyNeed>();



        public string Name { get { return name; } }
        public IList<CompanySchedule> Schedules { get => schedules.AsReadOnly();}
        public IList<WeeklyNeed> WeeklyNeed { get => (IList<WeeklyNeed>)weeklyNeed.AsReadOnly();  }

        public Company(string name)
        {
            this.name = name;

        }

        /// <summary>
        /// Adds a schedule to the list of schedules for the company.
        /// </summary>
        /// <param name="schedule">The CompanySchedule object to be added to the list.</param>
        /// <returns>
        /// A Result<string> object indicating the success or failure of the operation. If the operation is successful,
        /// the Ok variant will contain a string message indicating that the schedule was added to the list. If the 
        /// operation fails, the Fail variant will contain an Exception object with more information about the error.
        /// </returns>
        public Result<string> AddSchedules(CompanySchedule schedule)
        {
            try
            {
                if (!schedules.Any(x => x.CurrentWeek == schedule.CurrentWeek))
                {
                    schedules.Add(schedule);
                    return Result<string>.Ok("is added to list");
                }
                else
                {
                    return Result<string>.Fail(new Exception("schedule alreade exist for this week"));
                }
            }
            catch (Exception e)
            {

                return Result<string>.Fail(e);
            }
        }

        /// <summary>
        /// Adds a weekly need to the list of weekly needs for the company.
        /// </summary>
        /// <param name="weekly">The IWeeklyNeed object to be added to the list.</param>
        /// <returns>
        /// A Result<string> object indicating the success or failure of the operation. If the operation is successful,
        /// the Ok variant will contain a string message indicating that the weekly need was added to the list. If the 
        /// operation fails, the Fail variant will contain an Exception object with more information about the error.
        /// </returns>
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
                    return Result<string>.Fail(new Exception("weekly need alreade exist for this week"));
                }
            }
            catch (Exception e)
            {
                return Result<string>.Fail(e);
            }
       }


       
    }
}
