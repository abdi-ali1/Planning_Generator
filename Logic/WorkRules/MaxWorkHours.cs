using Logic.Employee;
using Logic.Schedules.Company;
using Logic.Schedules.Staff;
using Logic.Shifts;
using Logic.System.Generator.GeneraterHelp;
using DayOfWeek = Logic.Enum.DayOfWeek;

namespace Logic.WorkRules
{
    internal class MaxWorkHours : WorkRule
    {
        private readonly IList<CompanyScheduleInfo> scheduleInfo;
        private readonly DateTime date;

        public MaxWorkHours(IList<CompanyScheduleInfo> scheduleInfos, StaffMember staff, DateTime date):base(staff)
        {
            this.scheduleInfo = scheduleInfos;
            this.date = date;
        
        }

        public override bool IsRuleAdhered()
        {

            Result<StaffSchedule> result = StaffScheduleLooper.GetNeededStaffSchedule(staff, date);
            if (result.Success && result.Exception != null)
            {

                foreach (Shift shift in result.Value.AllShifts)
                {
                  
                  
                    
                }

            }
            else
            {

            }
        }


        private DayOfWeek DayOfBefore(Shift shift)
        {
            DayOfWeek dayBefore;
            if (scheduleInfo. != DayOfWeek.Monday)
            {
                 dayBefore = shift.Day - 1;
            }


           
        }
     


       
    }
}
