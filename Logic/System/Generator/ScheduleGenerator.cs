using Logic.Companys;
using Logic.Companys.Request;
using Logic.Employee;
using Logic.Interface;
using Logic.Schedules;
using Logic.Schedules.Company;
using Logic.Schedules.Staff;
using Logic.System.Generator.GeneraterHelp;

namespace Logic.System.Generator
{
    public class ScheduleGenerator
    {

        private IList<StaffMember> allStaffMembers;
        private IList<IWorkRule> workRules;
        private IGetLoopInfoWeeklyNeed getLoopInfoWeeklyNeed = new WeeklyNeedLooper();
        private IAvailibiltyChecker availibiltyChecker = new GeneratorAvailibilityChecker();
        private IAvailibiltyChecker loserAvailibilty = new GeneratorLoserChecker();


        public ScheduleGenerator(IList<StaffMember> allStaffMembers)
        {
            this.allStaffMembers = allStaffMembers;
            this.workRules = (IList<IWorkRule>)RuleManager.GetLoadableTypes();
        }


        //TODO interface that Uses This Method
        /// <summary>
        /// will generate schedules for the company and the chosen staffmembers
        /// </summary>
        /// <param name="weeklyNeed"> will probably be changed to a diffrent data type</param>
        public CompanySchedule GenerateSchedule(Company company, DateTime weekNeeded)
        {
            WeeklyNeed neededWeekData = getLoopInfoWeeklyNeed.GetInfo(company, weekNeeded);
            CompanySchedule schedule = new CompanySchedule(weekNeeded);

            foreach (NeededStaff needed in neededWeekData.NeededStaff)
            {
                foreach (StaffMember staff in allStaffMembers)
                {
                    CompanyScheduleInfo scheduleInfo = availibiltyChecker.IsChosen(needed, staff, weekNeeded);
                    if (scheduleInfo != null)
                    {
                       schedule.AddComapanySchedule(scheduleInfo);
                    }
                }
            }

            return schedule;
        }






      

      
  

    }
}
