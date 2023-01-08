using Logic.Companys;
using Logic.Companys.Request;
using Logic.Employee;
using Logic.Interface;
using Logic.Schedules;
using Logic.Schedules.Company;
using Logic.System.Generator.GeneraterHelp.AvailibiltyMatcher;

namespace Logic.System.Generator
{
    public class ScheduleGenerator
    {
        private readonly IList<StaffMember> staffMembers;
        private readonly IGetLoopInfoWeeklyNeed getLoopInfoWeeklyNeed;
        private readonly IAvailibiltyMatcher availabilityMatcher;
        private readonly IAvailibiltyMatcher secondaryAvailabilityMatcher;

        public ScheduleGenerator(IList<StaffMember> staffMembers)
        {
            this.staffMembers = staffMembers;
      
        }

        /// <summary>
        /// Creates a list of company schedules for the given week and company.
        /// </summary>
        /// <param name="company">The company for which to create schedules.</param>
        /// <param name="weekNeeded">The week for which to create schedules.</param>
        /// <returns>A list of company schedules for the given week and company.</returns>
        public List<CompanySchedule> CreateCompanySchedulesForWeek(Company company, DateTime weekNeeded)
        {
            List<CompanySchedule> schedules = new List<CompanySchedule>();

            IWeeklyNeed neededWeekData = getLoopInfoWeeklyNeed.GetInfo(company, weekNeeded).Value;
            IList<StaffMember> staffMembersAvailibleOnDate = StaffMembersAvailibleOnDate(staffMembers, weekNeeded).Value;

            CompanySchedule schedule = FillSchedule(neededWeekData.NeededStaff, staffMembersAvailibleOnDate, weekNeeded, availabilityMatcher);
            schedules.Add(schedule);

            // If there are still needed staff after the first schedule is created,
            // create another schedule with the remaining needed staff.
            if (schedule.CompanyScheduleInfos.Count < neededWeekData.NeededStaff.Count)
            {
                // Create a new schedule for the remaining needed staff.
                CompanySchedule remainingSchedule =
                FillSchedule(neededWeekData.NeededStaff, staffMembersAvailibleOnDate, weekNeeded, secondaryAvailabilityMatcher);
                schedules.Add(remainingSchedule);
            }

            return schedules;
        }

        /// <summary>
        /// Fills a company schedule for a given date with the available staff members.
        /// </summary>
        /// <param name="neededStaff">The list of needed staff positions for the given date.</param>
        /// <param name="staffMembers">The list of staff members available for the given date.</param>
        /// <param name="date">The date for which the schedule is being generated.</param>
        /// <param name="availabilityChecker">The availability checker to use to determine if a staff member is available for a shift.</param>
        /// <returns>A company schedule with the staff members assigned to the needed shifts.</returns>
        private CompanySchedule FillSchedule(
            IList<NeededStaff> neededStaff,
            IList<StaffMember> staffMembers,
            DateTime date,
            IAvailibiltyMatcher availabilityChecker)
        {
            CompanySchedule schedule = new CompanySchedule(date);

            foreach (NeededStaff needed in neededStaff)
            {
                foreach (StaffMember staff in staffMembers)
                {
                    if (availabilityChecker.MatchesNeed(needed, staff, date, schedule.CompanyScheduleInfos))
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
        /// <param name="staffMembers">The list of staff members to check for availability.</param>
        /// <param name="dateTime">The date to check for availability.</param>
        /// <returns>A result object containing either a list of staff members who are available on the given date, or an exception if there was an error.</returns>
        private Result<IList<StaffMember>> StaffMembersAvailibleOnDate(IList<StaffMember> staffMembers, DateTime dateTime)
        {
            try
            {
                IList<StaffMember> availibleStaffMembers = staffMembers.Where(staff => staff.AvailabilityStaff.Any(availability => availability.WeekAvailability == dateTime))
                    .ToList();
                if (availibleStaffMembers.Count == 0)
                {
                    return Result<IList<StaffMember>>.Fail(new Exception("there is no staff available"));
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