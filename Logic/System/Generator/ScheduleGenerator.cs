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
        private readonly IList<StaffMember> allStaffMembers;
        private readonly IGetLoopInfoWeeklyNeed getLoopInfoWeeklyNeed;
        private readonly IAvailibiltyChecker availabilityChecker;
        private readonly IAvailibiltyChecker secondaryAvailabilityChecker;

        public ScheduleGenerator(
            IList<StaffMember> allStaffMembers,
            IGetLoopInfoWeeklyNeed getLoopInfoWeeklyNeed,
            IAvailibiltyChecker availabilityChecker,
            IAvailibiltyChecker secondaryAvailabilityChecker)
        {
            this.allStaffMembers = allStaffMembers;
            this.getLoopInfoWeeklyNeed = getLoopInfoWeeklyNeed;
            this.availabilityChecker = availabilityChecker;
            this.secondaryAvailabilityChecker = secondaryAvailabilityChecker;
        }

        /// <summary>
        /// Creates a schedule for a given company and week.
        /// </summary>
        /// <param name="company">The company for which to create the schedule.</param>
        /// <param name="weekNeeded">The week for which to create the schedule.</param>
        /// <returns>A schedule for the given company and week.</returns
        public List<CompanySchedule> CreateCompanySchedulesForWeek(Company company, DateTime weekNeeded)
        {
            List<CompanySchedule> schedules = new List<CompanySchedule>();

            WeeklyNeed neededWeekData = getLoopInfoWeeklyNeed.GetInfo(company, weekNeeded).Value;
            CompanySchedule schedule = new CompanySchedule(weekNeeded);
            IList<StaffMember> staffMembersAvailibleOnDate = StaffMembersAvailibleOnDate(allStaffMembers, weekNeeded);

            FillSchedule(schedule, neededWeekData.NeededStaff, staffMembersAvailibleOnDate, weekNeeded, availabilityChecker);

            if (schedule.ScheduleInfos.Count < neededWeekData.NeededStaff.Count)
            {
                schedules.Add(schedule);
                schedule = new CompanySchedule(weekNeeded);
                FillSchedule(schedule, neededWeekData.NeededStaff, staffMembersAvailibleOnDate, weekNeeded, secondaryAvailabilityChecker);
            }

            schedules.Add(schedule);

            return schedules;
        }


        private void FillSchedule(
            CompanySchedule schedule,
            IEnumerable<NeededStaff> neededStaff,
            IEnumerable<StaffMember> staffMembers,
            DateTime date,
            IAvailibiltyChecker availabilityChecker)
        {
            foreach (NeededStaff needed in neededStaff)
            {
                foreach (StaffMember staff in staffMembers)
                {
                    if (availabilityChecker.MatchesNeed(needed, staff, date))
                    {
                        schedule.AddComapanyScheduleInfo(new CompanyScheduleInfo(staff, needed.NeededShift));
                    }
                }
            }
        }

        
        private IList<StaffMember> StaffMembersAvailibleOnDate(IList<StaffMember> staffMembers, DateTime dateTime)
        {
            return staffMembers
                .Where(staff => staff.Availibilty.Any(availability => availability.WeekAvailbilty == dateTime))
                .ToList();
        }

    }

}
