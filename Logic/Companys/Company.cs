using Logic.Companys.Request;
using Logic.Interface;
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


        public bool AddSchedules(CompanySchedule schedule)
        {

            bool isAdded = false;
            if (!schedules.Contains(schedule))
            {
                schedules.Add(schedule);
                isAdded = true;
            }
            return isAdded;
        }
        

       public bool AddWeeklyNeed(IWeeklyNeed weekly)
       {
            bool isAdded = false;
            if (!weeklyNeed.Contains(weekly))
            {
                weeklyNeed.Add(weekly);
                isAdded = true;
            }

            return isAdded;
        }
          


    }
}
