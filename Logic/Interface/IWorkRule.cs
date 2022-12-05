using Logic.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{

   public interface IWorkRule
   {
        // TODO: Maybe interface diversion
        public bool IsRuleAdhered(StaffMember staff, DateTime week); 
   }
}
