﻿using Logic.Companys.Request;
using Logic.Employee;
using Logic.Schedules;
using Logic.Schedules.Company;
using Logic.Shifts;
using Logic.Shifts.Availibiltiy;
using Logic.System.Generator.GeneraterHelp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.System.Generator
{
    internal class GeneratorBackerChecker : IAvailibiltyChecker
    {
        private WorkRuleHelper workRuleHelper = new WorkRuleHelper();

        public bool MatchesNeed(NeededStaff needed, StaffMember staff, CompanySchedule schedule)
        {
            bool matches = false;
            foreach (AvailibiltyStaff availibilty in staff.Availibilty)
            {
                foreach (Shift shift in availibilty.Shifts)
                {
                    if (needed.NeededShift.Equals(shift) && workRuleHelper.AdheredAllWorkRules(staff, needed))
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
