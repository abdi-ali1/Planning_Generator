using Logic.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interface
{
   public interface IWorkRule
   {
        public bool IsRuleAdhered(StaffMember[] staffMembers); 
   }
}
