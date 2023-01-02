using Logic.Companys.Request;

namespace Logic.Interface
{
    public interface IWeeklyNeed
    {
        public DateTime WeekNeeded { get;  }
        public IList<NeededStaff> NeededStaff { get;  }
        public Result<string> AddNeededStaff(NeededStaff needed);



    }
}