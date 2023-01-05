using Logic.Companys;
using Logic.Companys.Request;
using Logic.Employee;
using Logic.Interface;
using Logic.Schedules;
using Logic.Schedules.Company;
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
            IList<StaffMember> staffMembersAvailibleOnDate = StaffMembersAvailibleOnDate(allStaffMembers, weekNeeded).Value;

            CompanySchedule schedule = FillSchedule(neededWeekData.NeededStaff, staffMembersAvailibleOnDate, weekNeeded, availabilityChecker);
            schedules.Add(schedule);

            // If there are still needed staff after the first schedule is created,
            // create another schedule with the remaining needed staff.
            if (schedule.ScheduleInfos.Count < neededWeekData.NeededStaff.Count)
            {
                // Create a new schedule for the remaining needed staff.
                CompanySchedule remainingSchedule = 
                FillSchedule(neededWeekData.NeededStaff, staffMembersAvailibleOnDate, weekNeeded, secondaryAvailabilityChecker);
                schedules.Add(remainingSchedule);
            }

            return schedules;
        }



        /// <summary>
        /// Fills a schedule with staff members who match the needed shifts.
        /// </summary>
        /// <param name="neededStaff">The needed staff for the schedule.</param>
        /// <param name="staffMembers">The available staff members.</param>
        /// <param name="date">The date for the schedule.</param>
        /// <param name="availabilityChecker">The availability checker to use.</param>
        /// <returns>The filled schedule.</returns>
        private CompanySchedule FillSchedule(
            IList<NeededStaff> neededStaff,
            IList<StaffMember> staffMembers,
            DateTime date,
            IAvailibiltyChecker availabilityChecker)
        {
            CompanySchedule schedule = new CompanySchedule(date);

            foreach (NeededStaff needed in neededStaff)
            {
                foreach (StaffMember staff in staffMembers)
                {
                    if (availabilityChecker.MatchesNeed(needed, staff, schedule))
                    {
                        schedule.AddComapanyScheduleInfo(new CompanyScheduleInfo(staff, needed.NeededShift));
                    }
                }
            }

            return schedule;
        }



        /// <summary>
        /// Gets a list of staff members who are available on a given date.
        /// </summary>
        /// <param name="staffMembers">The list of staff members to check.</param>
        /// <param name="dateTime">The date to check.</param>
        /// <returns>A list of staff members who are available on the given date, or an error if no staff members are available.</returns>
        private Result<IList<StaffMember>> StaffMembersAvailibleOnDate(IList<StaffMember> staffMembers, DateTime dateTime)
        {
            try
            {
                IList<StaffMember> availibleStaffMembers = staffMembers.Where(staff => staff.Availibilty.Any(availability => availability.WeekAvailbilty == dateTime))
                    .ToList();
                if (availibleStaffMembers.Count == 0)
                {
                    return Result<IList<StaffMember>>.Fail(new Exception("there are no staff availible"));
                }
                return Result<IList<StaffMember>>.Ok(availibleStaffMembers);
            }
            catch (Exception e)
            {
                return Result<IList<StaffMember>>.Fail(e);
            }
        }
    }

}
