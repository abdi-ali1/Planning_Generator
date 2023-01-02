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
        private IGetLoopInfoWeeklyNeed getLoopInfoWeeklyNeed = new WeeklyNeedLooper();
        private IAvailibiltyChecker availibiltyChecker = new GeneratorAvailibilityChecker();
        private IAvailibiltyChecker secondeavailibilty = new GeneratorBackerChecker();

        public ScheduleGenerator(IList<StaffMember> allStaffMembers)
        {
            this.allStaffMembers = allStaffMembers;
        }


        /// <summary>
        /// Generates a schedule for a company for a specific week.
        /// </summary>
        /// <param name="company">The company for which to generate a schedule.</param>
        /// <param name="weekNeeded">The week for which to generate a schedule.</param>
        /// <returns>A schedule for the company for the specified week.</returns>
        public CompanySchedule GenerateSchedule(Company company, DateTime weekNeeded)
        {
            WeeklyNeed neededWeekData = getLoopInfoWeeklyNeed.GetInfo(company, weekNeeded);
            CompanySchedule schedule = new CompanySchedule(weekNeeded);
            List<StaffMember> staffMembersAvailibleOnDate = 
                StaffMembersAvailibleOnDate((List<StaffMember>)allStaffMembers, weekNeeded);

            foreach (NeededStaff needed in neededWeekData.NeededStaff)
            {
                foreach (StaffMember staff in staffMembersAvailibleOnDate)
                {
                    if (availibiltyChecker.MatchesNeed(needed, staff, weekNeeded))
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

        
    }
}
