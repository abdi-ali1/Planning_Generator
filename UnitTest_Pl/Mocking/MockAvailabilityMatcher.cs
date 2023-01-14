using Logic.Companys.Request;
using Logic.Employee;
using Logic.Schedules.Company;
using Logic;

namespace UnitTest_Pl.Mocking
{
    internal class MockAvailabilityMatcher : IAvailibiltyMatcher
    {
        public bool MatchesNeed(NeededStaff needed, Logic.Employee.StaffMember staff, int week, IList<CompanyScheduleInfo> scheduleInfos)
        {
            return true;
        }
    }
}
