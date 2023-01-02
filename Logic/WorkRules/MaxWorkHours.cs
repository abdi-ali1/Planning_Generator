using Logic.Companys.Request;
using Logic.Employee;
using Logic.Schedules.Staff;
using Logic.Shifts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.WorkRules
{
    internal class MaxWorkHours : IWorkRule
    {
        public bool IsRuleAdhered(StaffMember staff, NeededStaff needed)
        {
            return true;
        }
    }
}
