using Logic.Companys.Request;
using Logic.Employee;
using Logic.Schedules.Company;
using Logic.Shifts;
using Logic.WorkRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    internal class WorkRuleHelper
    {
       
        /// <summary>
        /// Determines whether all work rules are adhered for the specified staff member and company schedule information.
        /// </summary>
        /// <param name="staff">The staff member.</param>
        /// <param name="companyScheduleInfos">The company schedule information.</param>
        /// <param name="date">The date of the shift.</param>
        /// <param name="shift">The shift.</param>
        /// <returns>
        ///   <c>true</c> if all work rules are adhered; otherwise, <c>false</c>.
        /// </returns>
        public static bool AdheredAllWorkRules(StaffMember staff, IList<CompanyScheduleInfo> companyScheduleInfos, DateTime date, Shift shift)
        {
            var workRules = new List<IWorkRuleSchedule>
        {
            new FiftyRule(companyScheduleInfos, staff, date),
            new MaxWorkHours(companyScheduleInfos, staff, date, shift)
        };

            return ExecuteWorkRules(workRules);
        }

        /// <summary>
        /// Executes the specified work rules and returns a boolean value indicating whether all of the rules are adhered.
        /// </summary>
        /// <param name="rules">The work rules to execute.</param>
        /// <returns>
        ///   <c>true</c> if all of the rules are adhered; otherwise, <c>false</c>.
        /// </returns>
        private static bool ExecuteWorkRules(IList<IWorkRuleSchedule> rules)
        {
            return rules.All(rule => rule.IsRuleAdhered());
        }
    }

}
