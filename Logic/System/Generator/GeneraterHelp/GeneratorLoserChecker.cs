using Logic.Companys.Request;
using Logic.Employee;
using Logic.Interface;
using Logic.Schedules.Company;
using Logic.Shifts;
using Logic.Shifts.Availibiltiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.System.Generator
{
    internal class GeneratorLoserChecker : IAvailibiltyChecker
    {
        public bool MatchesNeed(NeededStaff needed, StaffMember staff, DateTime date)
        {
            bool matches = false;
            foreach (AvailibiltyStaff availibilty in staff.Availibilty)
            {
                foreach (Shift shift in availibilty.Shifts)
                {
                    if (needed.NeededShift.Equals(shift))
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
