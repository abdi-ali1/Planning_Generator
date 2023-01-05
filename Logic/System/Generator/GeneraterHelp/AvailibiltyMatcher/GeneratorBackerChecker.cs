using Logic.Companys.Request;
using Logic.Employee;
using Logic.Schedules;
using Logic.Schedules.Company;
using Logic.Shifts;
using Logic.Shifts.Availibiltiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.System.Generator.GeneraterHelp.AvailibiltyMatcher
{
    internal class GeneratorBackerChecker : IAvailibiltyMatcher
    {


        public bool MatchesNeed(NeededStaff needed, StaffMember staff, DateTime date, IList<CompanyScheduleInfo> scheduleInfos)
        {
            bool matches = false;
            foreach (AvailibiltyStaff availibilty in staff.Availibilty)
            {
                foreach (Shift shift in availibilty.Shifts)
                {
                    if (needed.NeededShift.Equals(shift) && WorkRuleHelper.AdheredAllWorkRules(staff, scheduleInfos, date, needed.NeededShift))
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
