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

        public ScheduleGenerator(
            IList<StaffMember> staffMembers,
            IGetLoopInfoWeeklyNeed getLoopInfoWeeklyNeed,
            IAvailibiltyMatcher availabilityMatcher,
            IAvailibiltyMatcher secondaryAvailabilityMatcher
        )
        {
            this.staffMembers = staffMembers;
            this.getLoopInfoWeeklyNeed = getLoopInfoWeeklyNeed;
            this.availabilityMatcher = availabilityMatcher;
            this.secondaryAvailabilityMatcher = secondaryAvailabilityMatcher;
        }

        /// <summary>
        /// Creates a list of company schedules for the given week and company.
        /// </summary>
        /// <param name="company">The company for which to create schedules.</param>
        /// <param name="weekNeeded">The week for which to create schedules.</param>
        /// <returns>A list of company schedules for the given week and company.</returns>
        public Result<IList<CompanySchedule>> CreateCompanySchedulesForWeek(
            Company company,
            int week
        )
        {
            List<CompanySchedule> schedules = new List<CompanySchedule>();
            IWeeklyNeed neededWeekData = getLoopInfoWeeklyNeed.GetInfo(company, week).Value;
            IList<StaffMember> staffMembersAvailibleOnDate = StaffMembersAvailibleOnDate(staffMembers, week).Value;

            if (staffMembersAvailibleOnDate == null || staffMembersAvailibleOnDate.Count == 0)
            {
                return Result<IList<CompanySchedule>>.Fail(
                    new Exception("There are no availible staff members")
                );
            }

            CompanySchedule schedule = FillSchedule(
                neededWeekData.NeededStaff,
                staffMembersAvailibleOnDate,
                week,
                availabilityMatcher
            );
            schedules.Add(schedule);

            if (schedule.CompanyScheduleInfos.Count < neededWeekData.NeededStaff.Count)
            {
                CompanySchedule remainingSchedule = FillSchedule(
                    neededWeekData.NeededStaff,
                    staffMembersAvailibleOnDate,
                    week,
                    secondaryAvailabilityMatcher
                );
                schedules.Add(remainingSchedule);
            }

            if (schedules.Any(x => x.CompanyScheduleInfos.Count == 0))
            {
                return Result<IList<CompanySchedule>>.Fail(
                    new Exception("There are no staff members availible")
                );
            }

            return Result<IList<CompanySchedule>>.Ok(schedules);
        }

        /// <summary>
        /// Fills a company schedule for a given date with the available staff members.
        /// </summary>
        /// <param name="neededStaff">The list of needed staff positions for the given date.</param>
        /// <param name="staffMembers">The list of staff members available for the given date.</param>
        /// <param name="week">The date for which the schedule is being generated.</param>
        /// <param name="availabilityChecker">The availability checker to use to determine if a staff member is available for a shift.</param>
        /// <returns>A company schedule with the staff members assigned to the needed shifts.</returns>
        private CompanySchedule FillSchedule(
            IList<NeededStaff> neededStaff,
            IList<StaffMember> staffMembers,
            int week,
            IAvailibiltyMatcher availabilityChecker
        )
        {
            CompanySchedule schedule = new CompanySchedule(week);

            foreach (NeededStaff needed in neededStaff)
            {
                foreach (StaffMember staff in staffMembers)
                {
                    if (
                        availabilityChecker.MatchesNeed(
                            needed,
                            staff,
                            week,
                            schedule.CompanyScheduleInfos
                        )
                    )
                    {
                        schedule.AddComapanyScheduleInfo(
                            new CompanyScheduleInfo(staff, needed.NeededShift)
                        );
                    }
                }
            }

            return schedule;
        }

        /// <summary>
        /// Gets a list of staff members who are available on a given date.
        /// </summary>
        /// <param name="staffMembers">The list of staff members to check for availability.</param>
        /// <param name="week">The date to check for availability.</param>
        /// <returns>A result object containing either a list of staff members who are available on the given date, or an exception if there was an error.</returns>
        private Result<IList<StaffMember>> StaffMembersAvailibleOnDate(
            IList<StaffMember> staffMembers,
            int week
        )
        {
            try
            {
                IList<StaffMember> availibleStaffMembers = staffMembers
                    .Where(
                        staff =>
                            staff.AvailabilityStaff.Any(
                                availability => availability.WeekAvailability == week
                            )
                    )
                    .ToList();
                if (availibleStaffMembers.Count == 0)
                {
                    return Result<IList<StaffMember>>.Fail(
                        new Exception("there is no staff available")
                    );
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
