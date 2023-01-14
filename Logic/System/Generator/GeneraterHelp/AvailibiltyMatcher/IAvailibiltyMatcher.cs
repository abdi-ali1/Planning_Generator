using Logic.Companys.Request;
using Logic.Employee;
using Logic.Schedules.Company;

namespace Logic
{
    public interface IAvailibiltyMatcher
    {
        public bool MatchesNeed(NeededStaff needed, StaffMember staff, int week, IList<CompanyScheduleInfo> scheduleInfos);
    }
}
