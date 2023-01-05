using Logic.Companys.Request;
using Logic.Employee;
using Logic.Schedules.Company;
using Logic.Shifts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{

   public interface IWorkRuleSchedule
   {
        // TODO: Maybe interface diversion
        public bool IsRuleAdhered(); 
   }
}
