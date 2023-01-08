using Logic.System;
using DTO_BinaryFile.Manager;
using Logic;
using Logic.System.Authentication;
using Logic.Interface;
using DTO_BinaryFile;
using Logic.System.ModelManager;
using Logic.System.Generator;

namespace Planning_Generator
{
    public class LogicRefecator
    {
        private static IBinaryFileManager fileManager;

        private static AuthenticationManagement authentication;
        private static ScheduleGenerator scheduleGenerator;
        private static StaffMemberModelManager staffMemberModelManager;
        private static CompanyModelManager companyModelManager;
        
        public static ScheduleGenerator ScheduleGenerator { get { return scheduleGenerator; } }
        public static StaffMemberModelManager StaffMemberModelManager { get { return staffMemberModelManager; } }
        public static CompanyModelManager CompanyModelManager { get { return companyModelManager; } }
        public static AuthenticationManagement Authentication { get { return authentication; } }
     


        static LogicRefecator()
        {
            fileManager = new BinaryFileManager();
            staffMemberModelManager = new StaffMemberModelManager(fileManager);
            companyModelManager = new CompanyModelManager(fileManager);
            authentication = new AuthenticationManagement(staffMemberModelManager.StaffMembers, companyModelManager.Companies);
            scheduleGenerator = new ScheduleGenerator(staffMemberModelManager.StaffMembers);
        }


    }
}
