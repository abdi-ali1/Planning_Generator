﻿using Logic.Employee;
using Logic.Schedules.Company;
using Logic.Shifts;
using Logic.WorkRules;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("UnitTest_Pl")]
namespace Logic
{
    internal class WorkRuleHelper
    {
        /// <summary>
        /// Determines if a staff member adheres to all work rules.
        /// </summary>
        /// <param name="staff">The staff member to check.</param>
        /// <param name="companyScheduleInfos">The company schedule infos for the staff member.</param>
        /// <param name="week">The date to check.</param>
        /// <param name="shift">The shift to check.</param>
        /// <returns>True if the staff member adheres to all work rules, otherwise false.</returns>
        public static bool AdheredAllWorkRules(StaffMember staff, IList<CompanyScheduleInfo> companyScheduleInfos, int week, Shift shift)
        {
            List<IWorkRuleSchedule> workRules = new List<IWorkRuleSchedule>()
            {
                new FiftyRule(companyScheduleInfos, staff, week),
                new MaxWorkHours(companyScheduleInfos, staff, week, shift)
            };

            return ExecuteWorkRules(workRules);
        }

        /// <summary>
        /// Determines if a staff member adheres to a list of work rules.
        /// </summary>
        /// <param name="rules">The list of work rules to check.</param>
        /// <returns>True if the staff member adheres to all work rules, otherwise false.</returns>
        private static bool ExecuteWorkRules(IList<IWorkRuleSchedule> rules)
        {
            return rules.All(rule => rule.IsRuleAdhered());
        }
    }
}
