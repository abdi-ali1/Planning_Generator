using Logic.Companys.Request;
using Logic.Employee;
using Logic.Interface;
using Logic.Schedules.Company;
using Logic.Shifts;
using Logic.Shifts.Availibiltiy;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.System.Generator.GeneraterHelp
{
    internal class GeneratorAvailibilityChecker: IAvailibiltyChecker
    {
        public bool MatchesNeed(NeededStaff needed, StaffMember staff, DateTime date)
        {
            bool matches = false;
            foreach (AvailibiltyStaff availibilty in staff.Availibilty)
            {
                foreach (Shift shift in availibilty.Shifts)
                {
                    if (needed.NeededShift.Equals(shift) && IsEligible(needed, staff))
                    {
                        matches = true;
                        break;
                    }
                }
            }
            return matches;
        }

        /// <summary>
        /// checks if the current staffmember  
        /// </summary>
        /// <param name="neededStaff"></param>
        /// <param name="staff"></param>
        /// <returns></returns>
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
