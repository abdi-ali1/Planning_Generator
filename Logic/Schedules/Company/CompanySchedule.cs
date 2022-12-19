using Logic.Employee;
using Logic.Schedules.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Schedules
{
    [Serializable]
    public class CompanySchedule
    {
        private DateTime currentWeek; 
        private List<CompanyScheduleInfo> scheduleInfos = new List<CompanyScheduleInfo>();


        public DateTime CurrentWeek { get { return currentWeek; }  }
        public IList<CompanyScheduleInfo> ScheduleInfos { get { return scheduleInfos.AsReadOnly(); } }


        public CompanySchedule(DateTime currentWeek)
        {
            this.currentWeek = currentWeek;
        }


        public CompanySchedule(DateTime currentWeek, List<CompanyScheduleInfo> scheduleInfos)
        {
            this.currentWeek = currentWeek;
            this.scheduleInfos = scheduleInfos;
        }


        public bool AddComapanySchedule(CompanyScheduleInfo scheduleInfo)
        {
            bool alreadyExist = true;
            if (!scheduleInfos.Contains(scheduleInfo))
            {
                scheduleInfos.Add(scheduleInfo);
                alreadyExist = false;
            }

            return alreadyExist;
        }

       
      

      

       

    }
}
