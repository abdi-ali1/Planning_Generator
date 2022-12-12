using Logic.Companys.Request;
using Logic.Schedules;


namespace Logic.Companys
{
    [Serializable]
    public class Company
    {
        private string name;
        private List<CompanySchedule> schedules = new List<CompanySchedule>();
        private List<WeeklyNeed> weeklyNeed = new List<WeeklyNeed>();
 

        public string Name { get { return name; } }
        public IList<CompanySchedule> Schedules { get => schedules.AsReadOnly();}
        public IList<WeeklyNeed> WeeklyNeed { get => weeklyNeed.AsReadOnly();  }

        public Company(string name)
        {
            this.name = name;
        }
/*
        public Company(string name, List<CompanySchedule> schedules, List<WeeklyNeed> weeklyNeed):this(name)
        {
            this.schedules = schedules;
            this.weeklyNeed = weeklyNeed;
        }*/

        public void AddSchedules(CompanySchedule schedule)
        {
           
                if (!schedules.Contains(schedule))
                {
                   
                }
            
        
        }

       public void AddWeeklyNeed(WeeklyNeed weekly)
       {
            weeklyNeed.Add(weekly);
       }


    }
}
