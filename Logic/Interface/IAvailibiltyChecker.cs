using Logic.Companys.Request;
using Logic.Employee;
using Logic.Schedules.Company;


namespace Logic.Interface
{
    internal interface IAvailibiltyChecker
    {
        public CompanyScheduleInfo IsChosen(NeededStaff needed, StaffMember staff, DateTime date);
    }
}
