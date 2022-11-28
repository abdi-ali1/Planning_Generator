using Logic.Schedules.Staff;
using Company = Logic.Companys.Company;
using StaffMember = Logic.Employee.StaffMember;
using Shift = Logic.Shifts.Shift;
using DayOfWeek = Logic.Enum.DayOfWeek;
using Logic.Shifts.Availibiltiy;
using Logic.Companys.Request;
using Logic.Schedules.Company;
using Logic.Employee.Degrees;

namespace Logic.System.Management
{
    [Serializable]
    public class ModelManager: IModelManager
    {
        private List<IStaff> allStaffMembers = new List<IStaff>();
        private List<ICompany> allCompanies = new List<ICompany>();

        public List<IStaff> AllStaffMembers { get { return allStaffMembers; } }
        public List<ICompany> AllCompanies { get { return allCompanies; } }


        public void AddCompany(ICompany company)
        {
            bool exist = false;
            foreach (Company c in AllCompanies)
            {
                if (company.Equals(c))
                {
                    exist = true;
                   break;
                }
            }

            if (!exist) allCompanies.Add(company);
        }

        public void AddStaffMember(IStaff staffMember)
        {
            bool exist = false;
            foreach (StaffMember staff in allStaffMembers)
            {
                if (staffMember.Equals(staff))
                {
                    exist = true;
                    break;
                }
            }

            if (!exist) AllStaffMembers.Add(staffMember);

        }

     /*   public void SampleObject()
        {
            List<StaffMember> staffMembers = new();
            List<Shift> shifts = new();
            Shift shift = new(DayOfWeek.Friday, Enum.ShiftHour.EveningShift);
            Shift shift1 = new(Enum.DayOfWeek.Tuesday, Enum.ShiftHour.EveningShift);
            Shift shift2 = new(Enum.DayOfWeek.Thursday, Enum.ShiftHour.AfternoonShift);
            Shift shift3 = new(Enum.DayOfWeek.Monday, Enum.ShiftHour.MorningShift);
            shifts.Add(shift1);
            shifts.Add(shift2);
            shifts.Add(shift3);
            Company company = new("ciratum");

            StaffMember staff = new("AbdiAli", "abdi", Enum.Gender.Male, Enum.CompanyRole.StaffMember, Enum.Occaption.Mechinic, DateTime.Now, new Degree("Hbo ICt", 5),
                new StaffSchedule(DateTime.Now, shifts), new AvailibiltyStaff(DateTime.Now, company, shift));

            StaffMember staff2 = new("Ricka", "Firka", Enum.Gender.Male, Enum.CompanyRole.StaffMember, Enum.Occaption.Mechinic, DateTime.Now, new Degree("Hbo ICt", 5),
                  new StaffSchedule(DateTime.Now, shifts), new AvailibiltyStaff(DateTime.Now, company, shift));

            staffMembers.Add(staff);
            staffMembers.Add(staff2);

            List<WeeklyNeed> weeklies = new List<WeeklyNeed>();
            List<NeededStaff> neededStaff = new();
            NeededStaff needed = new(Enum.Occaption.Driver, shift1);
            NeededStaff needed1 = new(Enum.Occaption.Picker, shift2);
            neededStaff.Add(needed);
            neededStaff.Add(needed1);
            WeeklyNeed weekly = new WeeklyNeed(DateTime.Now, neededStaff);
            List<CompanySchedule> companySchedules = new List<CompanySchedule>();
            CompanySchedule schedule = new(DateTime.Now, staffMembers);
            companySchedules.Add(schedule);
            Company mosa = new Company("mosa", companySchedules, weeklies);



            AddCompany(mosa);
            AddCompany(company);
            AddStaffMember(staff);
            AddStaffMember(staff2);

        }*/





    }
}
