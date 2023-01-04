using Logic.Companys.Request;
using Logic.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.System.Generator.GeneraterHelp
{
    internal class WorkRuleHelper
    {

        private IList<IWorkRule> workRules;


        public WorkRuleHelper()
        {
            workRules = (IList<IWorkRule>)RuleManager.GetLoadableTypes();
        }

        //TO DO split the work rules use interface splitting
        public bool AdheredAllWorkRules(StaffMember staff, NeededStaff needed)
        {
            bool adheredRule = true;
            foreach (IWorkRule rule in workRules)
            {
                if (!rule.IsRuleAdhered(staff, needed))
                {
                    adheredRule = false;
                    break;
                }
            }

            return adheredRule;
        }


       
    }
}
