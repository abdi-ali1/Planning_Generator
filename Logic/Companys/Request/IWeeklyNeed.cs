namespace Logic.Companys.Request
{
    public interface IWeeklyNeed
    {
        public DateTime WeekNeeded { get; }
        public IList<NeededStaff> NeededStaff { get; }
        public Result<string> AddNeededStaff(NeededStaff needed);



    }
}