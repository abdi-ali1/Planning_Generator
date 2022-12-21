using Logic.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.System.Generator.GeneraterHelp
{
    internal class WorRuleHelper
    {

        private IList<IWorkRule> workRules;


        public WorRuleHelper()
        {
            workRules = (IList<IWorkRule>)RuleManager.GetLoadableTypes();
        }


        public bool AdheredAllWorkRules(StaffMember staff, DateTime date)
        {
            bool adheredRule = true;
            foreach (IWorkRule rule in workRules)
            {
                if (!rule.IsRuleAdhered(staff, date))
                {
                    adheredRule = false;
                    break;
                }
            }

            return adheredRule;
        }

    }
}
