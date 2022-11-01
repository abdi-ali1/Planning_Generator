using Logic.Companys;
using Logic.Companys.Request;
using Logic.Employee;
using Logic.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.System.Generator
{
    public class ScheduleGenerator
    {

        private List<StaffMember> allStaffMembers = new();
        private List<IWorkRule> allWorkRules = new();

        //constructer
        public ScheduleGenerator(List<StaffMember> allStaffMembers, List<IWorkRule> allWorkRules)
        {
            this.allStaffMembers = allStaffMembers;
            this.allWorkRules = allWorkRules;
        }




        /// <summary>
        /// will generate schedules for the company and the chosen staffmembers
        /// 
        /// </summary>
        /// <param name="weeklyNeed"> will probably be changed to a diffrent data type</param>
        public void GenerateSchedule(Company company)
        {
        }

    }
}
