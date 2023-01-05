using Logic.Companys.Request;
using Logic.Employee;
using Logic.Schedules;
using Logic.Schedules.Company;


namespace Logic.System.Generator.GeneraterHelp.AvailibiltyMatcher
{
    public interface IAvailibiltyMatcher
    {
        public bool MatchesNeed(NeededStaff needed, StaffMember staff, DateTime date, IList<CompanyScheduleInfo> scheduleInfos);
    }
}
