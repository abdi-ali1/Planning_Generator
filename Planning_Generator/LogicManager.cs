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
    public static class LogicManager
    {

        private static AuthenticationManagement authentication;
        private static ScheduleGenerator ScheduleGenerator;
        private static StaffMemberModelManager StaffMemberModelManager;
        private static CompanyModelManager CompanyModelManager;

        private static IBinarayFileManager fileManager;


        static LogicManager()
        {

            fileManager = new BinaryFileManager();

            StaffMemberModelManager = new StaffMemberModelManager(fileManager);
            CompanyModelManager = new CompanyModelManager(fileManager);


            authentication = new AuthenticationManagement(StaffMemberModelManager.AllStaffMembers, CompanyModelManager.AllCompanies);

        


        }


    }
}
