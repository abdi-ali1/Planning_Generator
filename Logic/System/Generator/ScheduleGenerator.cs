using Logic.Companys;
using Logic.Companys.Request;
using Logic.Employee;
using Logic.Interface;
using Logic.Schedules;
using Logic.Schedules.Company;
using Logic.Shifts.Availibiltiy;
using Logic.System.Generator.GeneraterHelp;

namespace Logic.System.Generator
{
    public class ScheduleGenerator
    {

        private IList<StaffMember> allStaffMembers;
        private IList<IWorkRule> workRules = (IList<IWorkRule>)RuleManager.GetLoadableTypes();
        private IGetLoopInfoWeeklyNeed getLoopInfoWeeklyNeed = new WeeklyNeedLooper();
        private IAvailibiltyChecker availibiltyChecker = new GeneratorAvailibilityChecker();
        private IAvailibiltyChecker Secondeavailibilty = new GeneratorLoserChecker();


        public ScheduleGenerator(IList<StaffMember> allStaffMembers)
        {
            this.allStaffMembers = allStaffMembers;
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
            List<StaffMember> staffMembersAvailibleOnDate = StaffMembersAvailibleOnDate((List<StaffMember>)allStaffMembers, weekNeeded);

            foreach (NeededStaff needed in neededWeekData.NeededStaff)
            {
                foreach (StaffMember staff in staffMembersAvailibleOnDate)
                {
                    if (availibiltyChecker.MatchesNeed(needed, staff, weekNeeded) && 
                            AdheredAllWorkRules(staff, weekNeeded))
                    {
                        schedule.AddComapanyScheduleInfo(new CompanyScheduleInfo(staff, needed.NeededShift));
                    }
                }
            }

            return schedule;
        }


        public CompanySchedule GenerateBackUpSchedule(Company company, DateTime weekNeeded)
        {
            WeeklyNeed neededWeekData = getLoopInfoWeeklyNeed.GetInfo(company, weekNeeded);
            CompanySchedule schedule = new CompanySchedule(weekNeeded);
            List<StaffMember> staffMembersAvailibleOnDate = StaffMembersAvailibleOnDate((List<StaffMember>)allStaffMembers, weekNeeded);

            foreach (NeededStaff needed in neededWeekData.NeededStaff)
            {
                foreach (StaffMember staff in staffMembersAvailibleOnDate)
                {
                    if (availibiltyChecker.MatchesNeed(needed, staff, weekNeeded) &&
                            AdheredAllWorkRules(staff, weekNeeded))
                    {
                        schedule.AddComapanyScheduleInfo(new CompanyScheduleInfo(staff, needed.NeededShift));
                    }
                }
            }

            return schedule;
        }

        private List<StaffMember> StaffMembersAvailibleOnDate(List<StaffMember> staffMembers, DateTime dateTime)
        {
            List<StaffMember> staffMembersAvailible = new List<StaffMember>();
            foreach (StaffMember staff in staffMembers)
            {
                foreach (AvailibiltyStaff availibilty in staff.Availibilty)
                {
                    if (availibilty.WeekAvailbilty == dateTime)
                    {
                        staffMembersAvailible.Add(staff);
                    }
                }
            }
            return staffMembersAvailible;
        }

        private bool AdheredAllWorkRules(StaffMember staff, DateTime date)
        {
            bool adheredRule = true;
            foreach (IWorkRule rule in workRules)
            {
                if(!rule.IsRuleAdhered(staff, date))
                {
                   adheredRule = false;
                    break;
                }
            }

            return adheredRule; 
        }

        
    }
}
