using Logic.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.WorkRules
{
    public abstract class WorkRule : IWorkRuleSchedule
    {
        protected StaffMember staff;
     

        public WorkRule(StaffMember staff)
        {
            this.staff = staff;
       
        }

        public abstract bool IsRuleAdhered();

       
    }

}
