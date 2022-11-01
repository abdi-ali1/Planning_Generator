using Logic.Companys;
using Logic.Companys.Request;
using Logic.Employee;
using Logic.Interface;
using Logic.System.Authentication;
using Logic.System.Generator;
using Logic.System.Management;


namespace Logic.System
{
    public class MainSystem
    {
        private List<StaffMember> allStaffMembers = new();
        private List<Company> allCompany= new();
        private List<IWorkRule> allWorkRules = new();

        private AuthenticationManagement authentication;
        private ManagerSystem managerSystem;

        private StaffMember currentStaffMember;
        private Company currentCompany;
        private ScheduleGenerator generator;

        public MainSystem(List<StaffMember> allStaffMembers, List<Company> allCompany, List<IWorkRule> allWorkRules, 
            AuthenticationManagement authentication, ManagerSystem managerSystem, StaffMember currentStaffMember, 
            Company currentCompany, ScheduleGenerator generator)
        {
            this.allStaffMembers = allStaffMembers;
            this.allCompany = allCompany;
            this.allWorkRules = allWorkRules;
            this.authentication = authentication;
            this.managerSystem = managerSystem;
            this.currentStaffMember = currentStaffMember;
            this.currentCompany = currentCompany;
            this.generator = generator;
        }
    }
}
