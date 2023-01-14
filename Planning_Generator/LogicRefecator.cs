using DTO_BinaryFile.Manager;
using Logic.System.Authentication;
using Logic.Interface;
using Logic.System.ModelManager;
using Logic.System.Generator;
using Logic;

namespace Planning_Generator
{
    public class LogicRefecator
    {
        private static IBinaryFileManager fileManager;

        private static AuthenticationManagement authentication;
        private static ScheduleGenerator scheduleGenerator;
        private static StaffMemberModelManager staffMemberModelManager;
        private static CompanyModelManager companyModelManager;

        private static IGetLoopInfoWeeklyNeed loopInfoWeeklyNeed = new WeeklyNeedLooper();
        private static IAvailibiltyMatcher availibiltyMatcher = new GeneratorAvailibilityMatcher();
        private static IAvailibiltyMatcher limitedMatcher = new GeneratorBackerMatcher();

        /// <summary>
        /// Gets the schedule generator.
        /// </summary>
        /// <returns>The schedule generator.</returns>
        public static ScheduleGenerator ScheduleGenerator
        {
            get { return scheduleGenerator; }
        }

        /// <summary>
        /// Gets the staff member model manager.
        /// </summary>
        /// <returns>The staff member model manager.</returns>
        public static StaffMemberModelManager StaffMemberModelManager
        {
            get { return staffMemberModelManager; }
        }

        /// <summary>
        /// Gets the company model manager.
        /// </summary>
        /// <returns>The company model manager.</returns>
        public static CompanyModelManager CompanyModelManager
        {
            get { return companyModelManager; }
        }


        /// <summary>
        /// Gets the authentication management.
        /// </summary>
        /// <returns>The authentication management.</returns>
        public static AuthenticationManagement Authentication
        {
            get { return authentication; }
        }

        static LogicRefecator()
        {
            fileManager = new BinaryFileManager();
            staffMemberModelManager = new StaffMemberModelManager(fileManager);
            companyModelManager = new CompanyModelManager(fileManager);
            authentication = new AuthenticationManagement(
                staffMemberModelManager.StaffMembers,
                companyModelManager.Companies
            );
            scheduleGenerator = new ScheduleGenerator(
                staffMemberModelManager.StaffMembers,
                loopInfoWeeklyNeed,
                availibiltyMatcher,
                limitedMatcher
            );
        }
    }
}
