using Logic.Companys.Request;
using Logic.Employee;
using Logic.Schedules;
using Logic.Schedules.Company;
using Logic.Shifts;
using Logic.Shifts.Availibiltiy;

namespace Logic.System.Generator.GeneraterHelp.AvailibiltyMatcher
{
    internal class GeneratorAvailibilityChecker : IAvailibiltyChecker
    {



        public bool MatchesNeed(NeededStaff needed, StaffMember staff, DateTime date, IList<CompanyScheduleInfo> scheduleInfos)
        {
            bool matches = false;

            AvailibiltyStaff availibilty = staff.Availibilty.First(availibilty => availibilty.WeekAvailbilty == date);
            foreach (Shift shift in availibilty.Shifts)
            {
                if (needed.NeededShift.Equals(shift) && IsEligible(needed, staff) &&
                    WorkRuleHelper.AdheredAllWorkRules(staff, scheduleInfos, date, needed.NeededShift))
                {
                    matches = true;
                    break;
                }
            }

            return matches;
        }

        /// <summary>
        /// checks if the current staffmember  
        /// </summary>
        /// <param name="neededStaff"></param>
        /// <param name="staff"></param>
        /// <returns> 
        /// <c>True or False</c></c>
        /// </returns>
        private bool IsEligible(NeededStaff neededStaff, StaffMember staff)
        {
            if (neededStaff.Occaption.Equals(staff.Occaption) &&
                        neededStaff.DegreeLevel.Equals(staff.Degree.DegreeLevel))

            {
                return true;
            }
            return false;
        }






    }
}
