using DTO_BinaryFile.Manager;
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
       
        private AuthenticationManagement authentication;
        private ManagerSystem managerSystem;

        private StaffMember currentStaffMember;
        private Company currentCompany;
        private ScheduleGenerator generator;


   
        public AuthenticationManagement Authentication { get => authentication;  }
        public ManagerSystem ManagerSystem { get => managerSystem;  }
        public StaffMember CurrentStaffMember { get => currentStaffMember;  }
        public Company CurrentCompany { get => currentCompany; }
        public ScheduleGenerator Generator { get => generator;  }


        public MainSystem()
        {
        }
    }
}
