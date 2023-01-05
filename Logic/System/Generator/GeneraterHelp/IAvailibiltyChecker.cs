using Logic.Companys.Request;
using Logic.Employee;
using Logic.Schedules;
using Logic.Schedules.Company;


namespace Logic.System.Generator.GeneraterHelp
{
    public interface IAvailibiltyChecker
    {
        public bool MatchesNeed(NeededStaff needed, StaffMember staff, CompanySchedule schedule);
    }
}
