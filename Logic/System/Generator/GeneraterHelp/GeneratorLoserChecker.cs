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
        public CompanyScheduleInfo IsChosen(NeededStaff needed, StaffMember staff, DateTime date)
        {
            CompanyScheduleInfo companyScheduleInfo = null;
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
                                companyScheduleInfo = new CompanyScheduleInfo(staff, shift);
                                break;
                            }
                        }
                    }
                }
            }
            return companyScheduleInfo;
        }

  
    }
}
