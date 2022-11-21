namespace DTO_BinaryFile.Manager
{
    [Serializable]
    public class ModelManager
    {
        private List<StaffMember> allStaffMembers = new List<StaffMember>();
        private List<Company> allCompanies = new List<Company>();
        private BinaryFileManager binaryFileManager;

        public List<StaffMember> AllStaffMembers { get { return allStaffMembers; } }
        public List<Company> AllCompanies { get { return allCompanies; } }



        public void Add(StaffMember staffMember)
        {
            allStaffMembers.Add(staffMember);
        }

        public void Add(Company company)
        {
            allCompanies.Add(company);
        }


        /*
                private void SampleObject()
                {
                    List<StaffMember> staffMembers = new();
                    List<Shift> shifts = new();
                    Shift shift =  new(2, 2);
                    Shift shift1 = new(3, 3);
                    Shift shift2 = new(3, 1);
                    Shift shift3 = new(1, 2);
                    shifts.Add(shift1);
                    shifts.Add(shift2);
                    shifts.Add(shift3);
                    Company company = new("ciratum");

                    StaffMember staff = new("abdi", 2, 1, 2, DateTime.Now, new Degree("Hbo ICt", 5),
                        new StaffMemeberSchedule(DateTime.Now, shifts), new AvailibiltyStaff(DateTime.Now, company, shift));

                    StaffMember staff2 = new("Rik", 2, 1, 2, DateTime.Now, new Degree("Hbo ICt", 5),
                        new StaffMemeberSchedule(DateTime.Now, shifts), new AvailibiltyStaff(DateTime.Now, company, shift));

                    staffMembers.Add(staff);
                    staffMembers.Add(staff2);

                    List<WeeklyNeed> weeklies = new List<WeeklyNeed>();
                    List<NeededStaff> neededStaff = new();
                    NeededStaff needed = new(2, 2);
                    NeededStaff needed1 = new(1, 3);
                    neededStaff.Add(needed);
                    neededStaff.Add(needed1);
                    WeeklyNeed weekly = new WeeklyNeed(DateTime.Now, neededStaff);
                    List<CompanySchedule> companySchedules = new List<CompanySchedule>();
                    CompanySchedule schedule = new(DateTime.Now, staffMembers);
                    companySchedules.Add(schedule);
                    Company mosa = new Company("mosa", companySchedules, weeklies);

                    Add(mosa);
                    Add(company);
                    Add(staff);
                    Add(staff2);



                }*/


    }
}