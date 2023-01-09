using Logic.Companys.Request;
using Logic.Employee;
using Logic.Schedules.Company;
using Logic.Shifts;
using Logic.Shifts.Availibiltiy;

namespace Logic.System.Generator.GeneraterHelp.AvailibiltyMatcher
{
    public class GeneratorBackerMatcher : IAvailibiltyMatcher
    {
        /// <summary>
        /// Determines if a staff member is available to work a needed shift on a given date.
        /// </summary>
        /// <param name="needed">The needed shift to match against the staff member's availability.</param>
        /// <param name="staff">The staff member to check for availability.</param>
        /// <param name="week">The date to check for availability.</param>
        /// <param name="scheduleInfos">The list of current schedule infos for the company.</param>
        /// <returns>True if the staff member is available to work the needed shift on the given date, otherwise false.</returns>
        public bool MatchesNeed(NeededStaff needed, StaffMember staff, int week, IList<CompanyScheduleInfo> scheduleInfos)
        {
            bool matches = false;
            foreach (AvailabilityStaff availibilty in staff.AvailabilityStaff)
            {
                foreach (Shift shift in availibilty.Shifts)
                {
                    if (needed.NeededShift.Equals(shift) && WorkRuleHelper.AdheredAllWorkRules(staff, scheduleInfos, week, needed.NeededShift))
                    {
                        matches = true;
                        break;
                    }
                }
            }

            return matches;
        }
    }
}
