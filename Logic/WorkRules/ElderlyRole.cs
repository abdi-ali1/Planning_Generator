using Logic.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.WorkRules
{
    internal class ElderlyRole : IWorkRule
    {
     
        /// <summary>
        /// 
        /// </summary>
        /// <param name="staff"></param>
        /// <returns></returns>
        public bool IsRuleAdhered(StaffMember staff)
        {
            if (staff.Age > 50){ return true;}
            return false;   
        }
    }
}
