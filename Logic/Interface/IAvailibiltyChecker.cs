using Logic.Companys.Request;
using Logic.Employee;
using Logic.Schedules.Company;


namespace Logic.Interface
{
    public interface IAvailibiltyChecker
    {
        public bool MatchesNeed(NeededStaff needed, StaffMember staff, DateTime date);
    }
}
