using Logic.Schedules;

namespace Planning_Generator
{
    // a class that holds the companyschedule for the ui
    public class CompanyScheduleUi
    {
        private static CompanySchedule companySchedule;

        public static CompanySchedule Schedule
        {
            get { return companySchedule; }
            set { companySchedule = value; }
        }


    }
}
