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

        /// <summary>
        /// Adds a CompanyScheduleInfo object to the list of ScheduleInfos for the CompanySchedule.
        /// </summary>
        /// <param name="scheduleInfo">The scheduleInfo object to be added to the list.</param>
        /// <returns>
        /// A Result<string> object indicating the success or failure of the operation. If the operation is successful,
        /// the Ok variant will contain a string message indicating that the StaffSchedule object was added to the list. 
        /// If the operation fails, the Fail variant will contain an Exception object with more information about the 
        /// error.
        /// </returns>
        public Result<bool> AddComapanyScheduleInfo(CompanyScheduleInfo scheduleInfo)
        {
            try
            {
                if (!scheduleInfos.Any(x => x.Staff == scheduleInfo.Staff && x.Shift == scheduleInfo.Shift))
                {
                    scheduleInfos.Add(scheduleInfo);
                    return Result<bool>.Ok(true);
                }
                return Result<bool>.Fail(new Exception("already exist"));
            }
            catch (Exception e)
            {
                return Result<bool>.Fail(e);
            
            }        
        }





      


    }
}
