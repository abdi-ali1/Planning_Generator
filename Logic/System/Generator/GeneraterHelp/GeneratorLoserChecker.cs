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

namespace Logic.System.Generator.GeneraterHelp
{
    internal class GeneratorLoserChecker : IAvailibiltyChecker
    {
        public bool IsChosen(NeededStaff needed, StaffMember staff, DateTime date)
        {
            bool isChosen = false;
            foreach (AvailibiltyStaff availibilty in staff.Availibilty)
            {
                if (availibilty.WeekAvailbilty == date)
                {
                    foreach (Shift shift in availibilty.Shifts)
                    {
                        if (needed.NeededShift.Equals(shift) && needed.Occaption.Equals(staff.Occaption))
                        {
                            if (needed.Occaption.Equals(staff.Occaption) && needed.DegreeLevel.Equals(staff.Degree.DegreeLevel))
                            {
                                isChosen = true;
                                break;
                            }
                        }
                    }
                }
            }
            return isChosen;
        }
    }
}
