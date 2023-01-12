namespace Logic.Companys.Request
{
    public interface IWeeklyNeed
    {
        public int WeekNeeded { get; }
        public IList<NeededStaff> NeededStaff { get; }
        public Result<string> AddNeededStaff(NeededStaff needed);
    }
}
