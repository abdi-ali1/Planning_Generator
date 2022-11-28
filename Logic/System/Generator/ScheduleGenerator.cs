using Logic.Companys;
using Logic.Companys.Request;
using Logic.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.System.Generator
{
    public class ScheduleGenerator
    {

        private IModelManager modelManager;
        private List<IWorkRule> workRule;

        public ScheduleGenerator(IModelManager modelManager, List<IWorkRule> workRule)
        {
            this.modelManager = modelManager;
            this.workRule = workRule;
        }



        /// <summary>
        /// will generate schedules for the company and the chosen staffmembers
        /// 
        /// </summary>
        /// <param name="weeklyNeed"> will probably be changed to a diffrent data type</param>
        public void GenerateSchedule(ICompany company)
        {

            foreach (WeeklyNeed weekly in company.WeeklyNeed)
            {
                if (true)
                {

                }
            }
        }

        private bool GetCurrentWeek(WeeklyNeed weekly)
        {
            // check if it is current week

            return true;
        }


        #region to do
        private void SetStaffSchedules()
        {
            // to do sets the chosen staff schedules
        }

        private void SetCompanySchedule()
        {
            // todo sets the schedule for company (maybe this isnt the smartes way)
        }
        #endregion

    }
}
