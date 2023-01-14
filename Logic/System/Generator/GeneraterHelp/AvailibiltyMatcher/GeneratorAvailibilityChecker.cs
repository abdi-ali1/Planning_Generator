using Logic.Companys.Request;
using Logic.Employee;
using Logic.Schedules.Company;
using Logic.Shifts;
using Logic.Shifts.Availibiltiy;

namespace Logic
{
    public class GeneratorAvailibilityMatcher : IAvailibiltyMatcher
    {
        /// <summary>
        /// Determines if a staff member is eligible to work a needed shift on a given date.
        /// </summary>
        /// <param name="needed">The needed shift to match against the staff member's availability.</param>
        /// <param name="staff">The staff member to check for availability.</param>
        /// <param name="week">The date to check for availability.</param>
        /// <param name="scheduleInfos">The list of current schedule infos for the company.</param>
        /// <returns>True if the staff member is available to work the needed shift on the given date, otherwise false.</returns>
        public bool MatchesNeed(NeededStaff needed, StaffMember staff, int week, IList<CompanyScheduleInfo> scheduleInfos)
        {
            bool matches = false;

            AvailabilityStaff availibilty = staff.AvailabilityStaff.First(
                availibilty => availibilty.WeekAvailability == week
            );
            foreach (Shift shift in availibilty.Shifts)
            {
                if (
                    needed.NeededShift.Equals(shift)
                    && IsEligible(needed, staff)
                    && WorkRuleHelper.AdheredAllWorkRules(
                        staff,
                        scheduleInfos,
                        week,
                        needed.NeededShift
                    )
                )
                {
                    matches = true;
                    break;
                }
            }

            return matches;
        }

        /// <summary>
        /// Determines if a staff member is eligible to work a needed shift based on their occupation and degree level.
        /// </summary>
        /// <param name="neededStaff">The needed shift to match against the staff member's qualifications.</param>
        /// <param name="staff">The staff member to check for eligibility.</param>
        /// <returns>True if the staff member is eligible to work the needed shift, otherwise false.</returns>
        private bool IsEligible(NeededStaff neededStaff, StaffMember staff)
        {
            if (neededStaff.Occaption.Equals(staff.Occaption) && neededStaff.DegreeLevel.Equals(staff.Degree.DegreeLevel))
            {
                return true;
            }
            return false;
        }
    }
}
